namespace CarRentingSystem.Services.Contracts
{
    using CarRentingSystem.Web.ViewModels.Dealer;

    public interface IDealerService
    {
        Task<bool> DealerExistsByUserIdAsync(string userId);

        Task<bool> DealerExistsByPhoneNumberAsync(string phoneNumber);

        Task Create(string userId, BecomeDealerFormModel model);
    }
}
