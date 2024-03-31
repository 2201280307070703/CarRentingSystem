using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystem.Data.Migrations
{
    public partial class SetDefaultValueForCarIsAvailable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("1a186e35-228d-41b7-9441-8176b16993c0"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("4d332dd3-2e63-4134-a5bf-044f69e20644"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("e8174945-abbb-42ad-9960-2757c0da209c"));

            migrationBuilder.AlterColumn<bool>(
                name: "isAvailable",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year" },
                values: new object[] { new Guid("2b9dd71a-1df6-4785-8df2-64b49eef807d"), 2, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://getrentacar.com/storage/cache/images/960-640-100-fit-141446.jpeg", "VW", "Polo", 200m, 2020 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year" },
                values: new object[] { new Guid("7fb67f6d-0de7-462f-9748-11f1935198b5"), 1, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAooom4xC8D6ubV1tBYeiitLGSj79CeekoIxYHsc_M9g&s", "BMW", "E46", 300m, 2011 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year" },
                values: new object[] { new Guid("c24070fc-b155-466d-aa9b-46b926308b00"), 5, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://www.freecarmag.com/wp-content/uploads/2022/09/Qashqai_e-PWR2022_Dynamics_High_044.JPG-copy.jpg", "Nissan", "Quashqai", 350m, 2023 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "isAvailable",
                table: "Cars",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isAvailable" },
                values: new object[] { new Guid("1a186e35-228d-41b7-9441-8176b16993c0"), 5, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://www.freecarmag.com/wp-content/uploads/2022/09/Qashqai_e-PWR2022_Dynamics_High_044.JPG-copy.jpg", "Nissan", "Quashqai", 350m, 2023, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isAvailable" },
                values: new object[] { new Guid("4d332dd3-2e63-4134-a5bf-044f69e20644"), 1, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAooom4xC8D6ubV1tBYeiitLGSj79CeekoIxYHsc_M9g&s", "BMW", "E46", 300m, 2011, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isAvailable" },
                values: new object[] { new Guid("e8174945-abbb-42ad-9960-2757c0da209c"), 2, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://getrentacar.com/storage/cache/images/960-640-100-fit-141446.jpeg", "VW", "Polo", 200m, 2020, false });
        }
    }
}
