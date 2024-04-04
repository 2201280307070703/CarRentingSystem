namespace CarRentingSystem.Services.Contracts
{
    using CarRentingSystem.Web.ViewModels.Car;

    public interface ICarService
    {
        Task<ICollection<CarCardViewModel>> GetAllCarsByDealerIdAsync(string dealerId);

        Task<string> AddCarAndReturnIdAsync(AddCarFormModel model, string dealerId);

        Task<CarDetailsViewModel> GetCarDetailsByIdAsync(string carId);

        Task<bool> CarExistsByIdAsync(string carId);
    }
}
