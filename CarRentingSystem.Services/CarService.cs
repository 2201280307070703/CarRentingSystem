namespace CarRentingSystem.Services
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using CarRentingSystem.Services.Contracts;
    using CarRentingSystem.Web.Data;
    using CarRentingSystem.Web.ViewModels.Car;
    using CarRentingSystem.Data.Models;

    public class CarService : ICarService
    {
        private readonly CarRentingDbContext dbContext;
        private readonly IMapper mapper;

        public CarService(CarRentingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<string> AddCarAndReturnIdAsync(AddCarFormModel model, string dealerId)
        {
            Car newCar = this.mapper.Map<Car>(model);
            newCar.DealerId = Guid.Parse(dealerId.ToUpper());

            await dbContext.AddAsync(newCar);
            await dbContext.SaveChangesAsync();

            return newCar.Id.ToString();
        }

        public async Task<ICollection<CarCardViewModel>> GetAllCarsByUserIdAsync(string userId)
        {
            return await dbContext.Cars.Where(c => c.Dealer.UserId.ToString() == userId)
                .ProjectTo<CarCardViewModel>(this.mapper.ConfigurationProvider).ToArrayAsync();
                
        }
    }
}
