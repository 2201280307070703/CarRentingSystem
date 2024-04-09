namespace CarRentingSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using CarRentingSystem.Data.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.RentedCar)
                .WithOne(c => c.CurrentRenter)
                .HasForeignKey<Car>(c => c.CurrentRenterId);
        }
    }
}
