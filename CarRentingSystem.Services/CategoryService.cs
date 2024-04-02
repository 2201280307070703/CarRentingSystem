namespace CarRentingSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using CarRentingSystem.Web.Data;
    using CarRentingSystem.Services.Data.Contracts;
    using CarRentingSystem.Web.ViewModels.Category;

    public class CategoryService : ICategoryService
    {
        private readonly CarRentingDbContext dbContext;
        private readonly IMapper mapper;

        public CategoryService(CarRentingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<bool> CategoryExistsByIdAsync(int id)
        {
            return await this.dbContext.Categories.AnyAsync(c => c.Id == id);
        }

        public async Task<ICollection<CategoryViewModel>> GetAllCategoriesAsync()
        {
            return await this.dbContext.Categories.ProjectTo<CategoryViewModel>(this.mapper.ConfigurationProvider).ToArrayAsync();
        }
    }
}
