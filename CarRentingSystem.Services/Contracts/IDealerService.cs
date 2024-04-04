namespace CarRentingSystem.Services.Contracts
{
    using CarRentingSystem.Web.ViewModels.Dealer;

    public interface IDealerService
    {
        Task<bool> DealerExistsByUserIdAsync(string userId);

        Task<bool> DealerExistsByPhoneNumberAsync(string phoneNumber);

        Task Create(string userId, BecomeDealerFormModel model);

        Task<string> TakeDealerIdByUserId(string userId);

        Task<DealerDetailsViewModel> GetDealerDetailsByIdAsync(string dealerId);

        Task<bool> DealerExistsByIdAsync(string dealerId);
    }
}
