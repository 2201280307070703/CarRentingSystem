namespace CarRentingSystem.Web.ViewModels.Dealer
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Dealer;

    public class BecomeDealerFormModel
    {
        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = null!;
    }
}
