namespace CarRentingSystem.Services.Contracts
{
    using CarRentingSystem.Web.ViewModels.Car;

    public interface ICarService
    {
        Task<ICollection<CarCardViewModel>> GetAllCarsByDealerIdAsync(string dealerId);

        Task<ICollection<CarCardViewModel>> GetAllCarsAsync();

        Task<string> AddCarAndReturnIdAsync(CarFormModel model, string dealerId);

        Task<CarDetailsViewModel> GetCarDetailsByIdAsync(string carId);

        Task<bool> CarExistsByIdAsync(string carId);

        Task<CarFormModel> GetCarForEditByIdAsync(string carId);

        Task EditCarByIdAsync(string carId, CarFormModel model);

        Task<DeleteCarViewModel> GetCarForDeleteByIdAsync(string carId);

        Task DeleteCarByIdAsync(string carId);
    }
}
