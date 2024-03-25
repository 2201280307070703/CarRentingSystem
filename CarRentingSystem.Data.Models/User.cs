namespace CarRentingSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User: IdentityUser<Guid>
    {
        public User() 
        {
            this.RentedCars = new HashSet<Car>();
        }

        public virtual ICollection<Car> RentedCars { get; set; }
    }
}
