namespace CarRentingSystem.Web.ViewModels.Car
{
    using System.ComponentModel.DataAnnotations;

    using CarRentingSystem.Web.ViewModels.Category;
    using static CarRentingSystem.Common.EntityValidationConstants.Car;

    public class AddCarFormModel
    {
        public AddCarFormModel()
        {
            this.Categories = new HashSet<CategoryViewModel>();
        }

        [Required]
        [StringLength(MakeMaxLength, MinimumLength = MakeMinLength)]
        public string Make { get; set; } = null!;

        [Required]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        [Range(typeof(int), MinYear, MaxYear)]
        public int Year { get; set; }

        [Range(typeof(decimal), PricePerDayMinValue, PricePerDayMaxValue)]
        [Display(Name = "Daily Price")]
        public decimal PricePerDay { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; } = null!;

    }
}
