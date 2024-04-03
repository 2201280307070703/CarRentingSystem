namespace CarRentingSystem.Web.ViewModels.Car
{
    using CarRentingSystem.Web.ViewModels.Dealer;

    public class CarDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Year { get; set; }

        public decimal PricePerDay { get; set; }

        public string Category { get; set; } = null!;

        public Guid DealerId { get; set; }
    }
}
