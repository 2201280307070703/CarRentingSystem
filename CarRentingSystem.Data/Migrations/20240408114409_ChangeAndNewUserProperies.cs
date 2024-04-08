using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystem.Data.Migrations
{
    public partial class ChangeAndNewUserProperies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dealers_UserId",
                table: "Dealers");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CurrentRenterId",
                table: "Cars");

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

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isDeleted" },
                values: new object[] { new Guid("ba53c65a-ef1f-4494-9931-7b2a7b862129"), 5, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://www.freecarmag.com/wp-content/uploads/2022/09/Qashqai_e-PWR2022_Dynamics_High_044.JPG-copy.jpg", "Nissan", "Quashqai", 350m, 2023, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isDeleted" },
                values: new object[] { new Guid("df8babad-b4e5-4ab9-b8f8-51836f2da4fb"), 1, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAooom4xC8D6ubV1tBYeiitLGSj79CeekoIxYHsc_M9g&s", "BMW", "E46", 300m, 2011, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isDeleted" },
                values: new object[] { new Guid("f5bf18df-be01-44f7-8da6-bb6d7d81af2a"), 2, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://getrentacar.com/storage/cache/images/960-640-100-fit-141446.jpeg", "VW", "Polo", 200m, 2020, false });

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_UserId",
                table: "Dealers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CurrentRenterId",
                table: "Cars",
                column: "CurrentRenterId",
                unique: true,
                filter: "[CurrentRenterId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dealers_UserId",
                table: "Dealers");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CurrentRenterId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("ba53c65a-ef1f-4494-9931-7b2a7b862129"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("df8babad-b4e5-4ab9-b8f8-51836f2da4fb"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("f5bf18df-be01-44f7-8da6-bb6d7d81af2a"));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isAvailable", "isDeleted" },
                values: new object[] { new Guid("1d10a2d7-2a5b-4687-9c63-5bfad7c561a5"), 5, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://www.freecarmag.com/wp-content/uploads/2022/09/Qashqai_e-PWR2022_Dynamics_High_044.JPG-copy.jpg", "Nissan", "Quashqai", 350m, 2023, false, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isAvailable", "isDeleted" },
                values: new object[] { new Guid("342bc5ec-3b75-4038-ac63-bc6d02dcd766"), 1, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAooom4xC8D6ubV1tBYeiitLGSj79CeekoIxYHsc_M9g&s", "BMW", "E46", 300m, 2011, false, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isAvailable", "isDeleted" },
                values: new object[] { new Guid("b465831e-6ca9-418d-bd4c-474161e76a02"), 2, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://getrentacar.com/storage/cache/images/960-640-100-fit-141446.jpeg", "VW", "Polo", 200m, 2020, false, false });

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_UserId",
                table: "Dealers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CurrentRenterId",
                table: "Cars",
                column: "CurrentRenterId");
        }
    }
}
