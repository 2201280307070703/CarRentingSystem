namespace CarRentingSystem.Services.Data.Contracts
{
    using CarRentingSystem.Web.ViewModels.Category;

    public interface ICategoryService
    {
        Task<ICollection<CategoryViewModel>> GetAllCategoriesAsync();
    }
}
