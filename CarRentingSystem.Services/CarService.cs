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

        public async Task<bool> CarExistsByIdAsync(string carId)
        {
            return await this.dbContext.Cars.AnyAsync(c => c.Id.ToString() == carId);
        }

        public async Task<ICollection<CarCardViewModel>> GetAllCarsAsync()
        {
            return await this.dbContext.Cars.Where(c => c.isAvailable == true).ProjectTo<CarCardViewModel>(this.mapper.ConfigurationProvider).ToArrayAsync();
        }

        public async Task<ICollection<CarCardViewModel>> GetAllCarsByDealerIdAsync(string dealerId)
        {
            return await this.dbContext.Cars.Where(c => c.DealerId.ToString() == dealerId)
                .ProjectTo<CarCardViewModel>(this.mapper.ConfigurationProvider).ToArrayAsync();
        }

        public async Task<CarDetailsViewModel> GetCarDetailsByIdAsync(string carId)
        {
            return await this.dbContext.Cars.Where(c => c.Id.ToString() == carId)
                .ProjectTo<CarDetailsViewModel>(this.mapper.ConfigurationProvider).FirstAsync();
        }
    }
}
