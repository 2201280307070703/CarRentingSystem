namespace CarRentingSystem.Services.Data.Contracts
{
    public interface IUserService
    {
        Task<bool> UserHasRentedCarByIdAsync(string userId);
    }
}
