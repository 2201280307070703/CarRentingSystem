namespace CarRentingSystem.Web.ViewModels.Dealer
{
    public class DealerDetailsViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
    }
}
