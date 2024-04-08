namespace CarRentingSystem.Web.ViewModels.Car
{
    public class DeleteCarViewModel
    {
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Year { get; set; }
    }
}
