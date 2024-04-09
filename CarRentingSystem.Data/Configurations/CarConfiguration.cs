namespace CarRentingSystem.Data.Configurations
{ 
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using CarRentingSystem.Data.Models;
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasOne(c => c.Category)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Dealer)
                .WithMany(d => d.OwnedCars)
                .HasForeignKey(c => c.DealerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.CurrentRenter)
                .WithOne(u => u.RentedCar)
                .HasForeignKey<User>(c => c.RentedCarId);

            builder.Property(p => p.PricePerDay)
                .HasPrecision(18, 2);

            builder.Property(a => a.isAvailable)
                .HasDefaultValue(true);

            builder.HasData(GenerateCars());
        }

        private List<Car> GenerateCars()
        {
            List<Car> cars = new List<Car>();

            Car car;

            car = new Car()
            {
                Make = "VW",
                Model = "Polo",
                Description = "Some description.",
                ImageUrl = "https://getrentacar.com/storage/cache/images/960-640-100-fit-141446.jpeg",
                Year = 2020,
                PricePerDay = 200,
                CategoryId = 2,
                DealerId = Guid.Parse("DD2954BB-5BF3-4DB5-A0D4-CB43BB47C4FF"),
            };
            cars.Add(car);

            car = new Car()
            {
                Make = "BMW",
                Model = "E46",
                Description = "Some description.",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAooom4xC8D6ubV1tBYeiitLGSj79CeekoIxYHsc_M9g&s",
                Year = 2011,
                PricePerDay = 300,
                CategoryId = 1,
                DealerId = Guid.Parse("DD2954BB-5BF3-4DB5-A0D4-CB43BB47C4FF"),
            };
            cars.Add(car);

            car = new Car()
            {
                Make = "Nissan",
                Model = "Quashqai",
                Description = "Some description.",
                ImageUrl = "https://www.freecarmag.com/wp-content/uploads/2022/09/Qashqai_e-PWR2022_Dynamics_High_044.JPG-copy.jpg",
                Year = 2023,
                PricePerDay = 350,
                CategoryId = 5,
                DealerId = Guid.Parse("DD2954BB-5BF3-4DB5-A0D4-CB43BB47C4FF"),
            };
            cars.Add(car);

            return cars;
        }
    }
}
