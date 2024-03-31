namespace CarRentingSystem.Web.ViewModels.Car
{
    public class CarCardViewModel
    {
        public Guid Id { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

    }
}
