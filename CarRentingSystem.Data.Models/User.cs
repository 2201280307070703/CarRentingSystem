namespace CarRentingSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class User: IdentityUser<Guid>
    {
        [ForeignKey(nameof(RentedCar))]
        public Guid? RentedCarId { get; set; }
        public virtual Car? RentedCar { get; set; } = null!;
    }
}
