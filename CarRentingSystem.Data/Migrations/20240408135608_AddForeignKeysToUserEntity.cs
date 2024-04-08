using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystem.Data.Migrations
{
    public partial class AddForeignKeysToUserEntity : Migration
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
                keyValue: new Guid("ba53c65a-ef1f-4494-9931-7b2a7b862129"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("df8babad-b4e5-4ab9-b8f8-51836f2da4fb"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("f5bf18df-be01-44f7-8da6-bb6d7d81af2a"));

            migrationBuilder.AddColumn<Guid>(
                name: "DealerId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RentedCarId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isDeleted" },
                values: new object[] { new Guid("5f6a178e-6915-4c45-956c-5a0e27bf1fba"), 2, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://getrentacar.com/storage/cache/images/960-640-100-fit-141446.jpeg", "VW", "Polo", 200m, 2020, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isDeleted" },
                values: new object[] { new Guid("8f6d493a-efea-41c0-950a-1b5d4b8c24c9"), 5, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://www.freecarmag.com/wp-content/uploads/2022/09/Qashqai_e-PWR2022_Dynamics_High_044.JPG-copy.jpg", "Nissan", "Quashqai", 350m, 2023, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isDeleted" },
                values: new object[] { new Guid("ea281ee5-9455-4563-a2c8-e373600fd600"), 1, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAooom4xC8D6ubV1tBYeiitLGSj79CeekoIxYHsc_M9g&s", "BMW", "E46", 300m, 2011, false });

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_UserId",
                table: "Dealers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CurrentRenterId",
                table: "Cars",
                column: "CurrentRenterId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DealerId",
                table: "AspNetUsers",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RentedCarId",
                table: "AspNetUsers",
                column: "RentedCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cars_RentedCarId",
                table: "AspNetUsers",
                column: "RentedCarId",
                principalTable: "Cars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Dealers_DealerId",
                table: "AspNetUsers",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cars_RentedCarId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Dealers_DealerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Dealers_UserId",
                table: "Dealers");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CurrentRenterId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DealerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RentedCarId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("5f6a178e-6915-4c45-956c-5a0e27bf1fba"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("8f6d493a-efea-41c0-950a-1b5d4b8c24c9"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("ea281ee5-9455-4563-a2c8-e373600fd600"));

            migrationBuilder.DropColumn(
                name: "DealerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RentedCarId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isAvailable", "isDeleted" },
                values: new object[] { new Guid("ba53c65a-ef1f-4494-9931-7b2a7b862129"), 5, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://www.freecarmag.com/wp-content/uploads/2022/09/Qashqai_e-PWR2022_Dynamics_High_044.JPG-copy.jpg", "Nissan", "Quashqai", 350m, 2023, false, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isAvailable", "isDeleted" },
                values: new object[] { new Guid("df8babad-b4e5-4ab9-b8f8-51836f2da4fb"), 1, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAooom4xC8D6ubV1tBYeiitLGSj79CeekoIxYHsc_M9g&s", "BMW", "E46", 300m, 2011, false, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CurrentRenterId", "DealerId", "Description", "ImageUrl", "Make", "Model", "PricePerDay", "Year", "isAvailable", "isDeleted" },
                values: new object[] { new Guid("f5bf18df-be01-44f7-8da6-bb6d7d81af2a"), 2, null, new Guid("dd2954bb-5bf3-4db5-a0d4-cb43bb47c4ff"), "Some description.", "https://getrentacar.com/storage/cache/images/960-640-100-fit-141446.jpeg", "VW", "Polo", 200m, 2020, false, false });

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
    }
}
