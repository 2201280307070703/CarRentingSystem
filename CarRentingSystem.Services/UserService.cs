namespace CarRentingSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;

    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Services.Data.Contracts;
    using CarRentingSystem.Web.Data;

    public class UserService : IUserService
    {
        private readonly CarRentingDbContext dbContext;
        private readonly IMapper mapper;

        public UserService(CarRentingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<bool> UserHasRentedCarByIdAsync(string userId)
        {
            User user = await this.dbContext.Users.FirstAsync(u => u.Id.ToString() == userId);

            return !string.IsNullOrWhiteSpace(user.RentedCarId.ToString());
        }
    }
}
