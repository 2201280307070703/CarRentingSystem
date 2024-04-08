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

        public async Task<string> AddCarAndReturnIdAsync(CarFormModel model, string dealerId)
        {
            Car newCar = this.mapper.Map<Car>(model);
            newCar.DealerId = Guid.Parse(dealerId.ToUpper());

            await dbContext.AddAsync(newCar);
            await dbContext.SaveChangesAsync();

            return newCar.Id.ToString();
        }

        public async Task<bool> CarExistsByIdAsync(string carId)
        {
            return await this.dbContext.Cars.Where(c => c.isDeleted == false).AnyAsync(c => c.Id.ToString() == carId);
        }

        public async Task DeleteCarByIdAsync(string carId)
        {
            Car carForDelete = await this.dbContext.Cars.FirstAsync(c => c.isDeleted == false && c.Id.ToString() == carId);

            carForDelete.isDeleted = true;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditCarByIdAsync(string carId, CarFormModel model)
        {
            Car carForEdit = await this.dbContext.Cars.FirstAsync(c => c.isDeleted == false && c.Id.ToString() == carId);

            mapper.Map(model, carForEdit);

            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<CarCardViewModel>> GetAllCarsAsync()
        {
            return await this.dbContext.Cars.Where(c => c.isDeleted == false).ProjectTo<CarCardViewModel>(this.mapper.ConfigurationProvider).ToArrayAsync();
        }

        public async Task<ICollection<CarCardViewModel>> GetAllCarsByDealerIdAsync(string dealerId)
        {
            return await this.dbContext.Cars.Where(c => c.isDeleted == false && c.DealerId.ToString() == dealerId)
                .ProjectTo<CarCardViewModel>(this.mapper.ConfigurationProvider).ToArrayAsync();
        }

        public async Task<CarDetailsViewModel> GetCarDetailsByIdAsync(string carId)
        {
            return await this.dbContext.Cars.Where(c => c.isDeleted == false && c.Id.ToString() == carId)
                .ProjectTo<CarDetailsViewModel>(this.mapper.ConfigurationProvider).FirstAsync();
        }

        public async Task<DeleteCarViewModel> GetCarForDeleteByIdAsync(string carId)
        {
            return await this.dbContext.Cars.Where(c => c.isDeleted == false && carId.ToString() == carId)
                .ProjectTo<DeleteCarViewModel>(this.mapper.ConfigurationProvider).FirstAsync();
        }

        public async Task<CarFormModel> GetCarForEditByIdAsync(string carId)
        {
            return await this.dbContext.Cars.Where(c => c.isDeleted == false && c .Id.ToString() == carId)
                .ProjectTo<CarFormModel>(this.mapper.ConfigurationProvider).FirstAsync();
        }
    }
}
