namespace CarRentingSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityValidationConstants.Car;
    public class Car
    {
        public Car()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(MakeMaxLength)]
        public string Make { get; set; } = null!;

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public int Year { get; set; }

        public decimal PricePerDay { get; set; }

        public bool isAvailable { get; set; }

        public bool isDeleted { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        [ForeignKey(nameof(Dealer))]
        public Guid DealerId { get; set; }

        public virtual Dealer Dealer { get; set; } = null!;

        [ForeignKey(nameof(CurrentRenter))]
        public Guid? CurrentRenterId { get; set; }

        public virtual User? CurrentRenter { get; set; }
    }
}
