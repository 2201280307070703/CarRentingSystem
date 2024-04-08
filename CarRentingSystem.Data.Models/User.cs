namespace CarRentingSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User: IdentityUser<Guid>
    {
        [ForeignKey(nameof(Dealer))]
        public Guid? DealerId { get; set; }
        public virtual Dealer? Dealer { get; set; } = null!;

        [ForeignKey(nameof(RentedCar))]
        public Guid? RentedCarId { get; set; }
        public virtual Car? RentedCar { get; set; } = null!;
    }
}
