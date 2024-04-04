namespace CarRentingSystem.Services
{
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;

    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Web.ViewModels.Dealer;
    using CarRentingSystem.Services.Contracts;
    using CarRentingSystem.Web.Data;
    using AutoMapper.QueryableExtensions;

    public class DealerService : IDealerService
    {
        private readonly CarRentingDbContext dbContext;
        private readonly IMapper mapper;

        public DealerService(CarRentingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task Create(string userId, BecomeDealerFormModel model)
        {
            Dealer newDealer = this.mapper.Map<Dealer>(model);
            newDealer.UserId = Guid.Parse(userId);

            await dbContext.AddAsync(newDealer);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> DealerExistsByIdAsync(string dealerId)
        {
            return await this.dbContext.Dealers.AnyAsync(d => d.Id.ToString() == dealerId);
        }

        public async Task<bool> DealerExistsByPhoneNumberAsync(string phoneNumber)
        {
            return await dbContext.Dealers.AnyAsync(d => d.PhoneNumber == phoneNumber);
        }

        public async Task<bool> DealerExistsByUserIdAsync(string userId)
        {
            return await dbContext.Dealers.AnyAsync(d => d.UserId.ToString() == userId);
        }

        public Task<DealerDetailsViewModel> GetDealerDetailsByIdAsync(string dealerId)
        {
            return dbContext.Dealers.Where(d => d.Id.ToString() == dealerId)
                .ProjectTo<DealerDetailsViewModel>(this.mapper.ConfigurationProvider).FirstAsync();
        }

        public async Task<string> TakeDealerIdByUserId(string userId)
        {
            Dealer? dealer = await this.dbContext.Dealers.FirstOrDefaultAsync(d => d.UserId.ToString() == userId);

            if (dealer == null)
            {
                return null!;
            }

            return dealer.Id.ToString();
        }
    }
}
