#nullable disable

namespace CarRentingSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class SeedCarsAndCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cars",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sedan" },
                    { 2, "Hatchback" },
                    { 3, "Coupe" },
                    { 4, "Wagon" },
                    { 5, "Crossover" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isAvailable" },
                values: new object[] { new Guid("426ecc51-cf24-406a-a4e0-a4fbcee7d2ca"), 2, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://getrentacar.com/storage/cache/images/960-640-100-fit-141446.jpeg", "VW", "Polo", 200m, 2020, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isAvailable" },
                values: new object[] { new Guid("81e9eace-6d55-4db0-a7fc-6e898c400830"), 1, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAooom4xC8D6ubV1tBYeiitLGSj79CeekoIxYHsc_M9g&s", "BMW", "E46", 300m, 2011, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isAvailable" },
                values: new object[] { new Guid("86d4858d-64a8-415b-9c8d-dffe8ee1f726"), 5, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://www.freecarmag.com/wp-content/uploads/2022/09/Qashqai_e-PWR2022_Dynamics_High_044.JPG-copy.jpg", "Nissan", "Quashqai", 350m, 2023, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("426ecc51-cf24-406a-a4e0-a4fbcee7d2ca"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("81e9eace-6d55-4db0-a7fc-6e898c400830"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("86d4858d-64a8-415b-9c8d-dffe8ee1f726"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cars",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
