using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystem.Data.Migrations
{
    public partial class AddIsDeletedForCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("2b9dd71a-1df6-4785-8df2-64b49eef807d"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("7fb67f6d-0de7-462f-9748-11f1935198b5"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c24070fc-b155-466d-aa9b-46b926308b00"));

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isDeleted" },
                values: new object[] { new Guid("1d10a2d7-2a5b-4687-9c63-5bfad7c561a5"), 5, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://www.freecarmag.com/wp-content/uploads/2022/09/Qashqai_e-PWR2022_Dynamics_High_044.JPG-copy.jpg", "Nissan", "Quashqai", 350m, 2023, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isDeleted" },
                values: new object[] { new Guid("342bc5ec-3b75-4038-ac63-bc6d02dcd766"), 1, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAooom4xC8D6ubV1tBYeiitLGSj79CeekoIxYHsc_M9g&s", "BMW", "E46", 300m, 2011, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isDeleted" },
                values: new object[] { new Guid("b465831e-6ca9-418d-bd4c-474161e76a02"), 2, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://getrentacar.com/storage/cache/images/960-640-100-fit-141446.jpeg", "VW", "Polo", 200m, 2020, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("1d10a2d7-2a5b-4687-9c63-5bfad7c561a5"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("342bc5ec-3b75-4038-ac63-bc6d02dcd766"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("b465831e-6ca9-418d-bd4c-474161e76a02"));

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isAvailable" },
                values: new object[] { new Guid("2b9dd71a-1df6-4785-8df2-64b49eef807d"), 2, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://getrentacar.com/storage/cache/images/960-640-100-fit-141446.jpeg", "VW", "Polo", 200m, 2020, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isAvailable" },
                values: new object[] { new Guid("7fb67f6d-0de7-462f-9748-11f1935198b5"), 1, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAooom4xC8D6ubV1tBYeiitLGSj79CeekoIxYHsc_M9g&s", "BMW", "E46", 300m, 2011, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isAvailable" },
                values: new object[] { new Guid("c24070fc-b155-466d-aa9b-46b926308b00"), 5, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://www.freecarmag.com/wp-content/uploads/2022/09/Qashqai_e-PWR2022_Dynamics_High_044.JPG-copy.jpg", "Nissan", "Quashqai", 350m, 2023, false });
        }
    }
}
