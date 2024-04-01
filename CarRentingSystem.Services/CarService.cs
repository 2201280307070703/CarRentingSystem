namespace CarRentingSystem.Services
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using CarRentingSystem.Services.Contracts;
    using CarRentingSystem.Web.Data;
    using CarRentingSystem.Web.ViewModels.Car;

    public class CarService : ICarService
    {
        private readonly CarRentingDbContext dbContext;
        private readonly IMapper mapper;

        public CarService(CarRentingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ICollection<CarCardViewModel>> GetAllCarsByUserIdAsync(string userId)
        {
            return await dbContext.Cars.Where(c => c.Dealer.UserId.ToString() == userId)
                .ProjectTo<CarCardViewModel>(this.mapper.ConfigurationProvider).ToArrayAsync();
                
        }
    }
}
