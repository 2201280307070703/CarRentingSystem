namespace CarRentingSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using CarRentingSystem.Data.Models;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(GenerateCategories());
        }

        private List<Category> GenerateCategories()
        {
            List<Category> categories = new List<Category>();

            Category category;

            category = new Category()
            {
                Id = 1,
                Name = "Sedan"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Hatchback"
            };
            categories.Add(category);

            category = new Category()
            { 
                Id = 3,
                Name = "Coupe"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Wagon"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 5,
                Name = "Crossover"
            };
            categories.Add(category);

            return categories;
        } 
    }
}
