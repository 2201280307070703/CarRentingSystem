namespace CarRentingSystem.Services
{
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;

    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Web.ViewModels.Dealer;
    using CarRentingSystem.Services.Contracts;
    using CarRentingSystem.Web.Data;


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

        public async Task<bool> DealerExistsByPhoneNumberAsync(string phoneNumber)
        {
            return await dbContext.Dealers.AnyAsync(d => d.PhoneNumber == phoneNumber);
        }

        public async Task<bool> DealerExistsByUserIdAsync(string userId)
        {
            return await dbContext.Dealers.AnyAsync(d => d.UserId.ToString() == userId);
        }

        public async Task<string> TakeDealerIdByUserId(string userId)
        {
            Dealer dealer = await this.dbContext.Dealers.FirstAsync();

            return dealer.Id.ToString();
        }
    }
}
