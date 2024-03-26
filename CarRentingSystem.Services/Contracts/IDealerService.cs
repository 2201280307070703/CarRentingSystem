namespace CarRentingSystem.Services.Contracts
{
    public interface IDealerService
    {
        Task<bool> DealerExistsByUserIdAsync(string userId);

        Task<bool> DealerExistsByPhoneNumberAsync(string phoneNumber);
    }
}
