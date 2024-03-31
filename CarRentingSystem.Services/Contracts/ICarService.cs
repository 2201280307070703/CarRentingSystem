namespace CarRentingSystem.Services.Contracts
{
    using CarRentingSystem.Web.ViewModels.Car;

    public interface ICarService
    {
        Task<ICollection<CarCardViewModel>> GetAllCarsByUserIdAsync(string userId);
    }
}
