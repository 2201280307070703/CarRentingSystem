namespace CarRentingSystem.Services
{
    using Microsoft.EntityFrameworkCore;

    using CarRentingSystem.Web.Data;
    using CarRentingSystem.Services.Contracts;

    public class DealerService : IDealerService
    {
        private readonly CarRentingDbContext dbContext;

        public DealerService(CarRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> DealerExistsByPhoneNumberAsync(string phoneNumber)
        {
            return await dbContext.Dealers.AnyAsync(d => d.PhoneNumber == phoneNumber);
        }

        public async Task<bool> DealerExistsByUserIdAsync(string userId)
        {
            return await dbContext.Dealers.AnyAsync(d => d.UserId.ToString() == userId);
        }
    }
}
