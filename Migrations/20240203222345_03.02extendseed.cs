using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShelterHelperAPI.Migrations
{
    /// <inheritdoc />
    public partial class _0302extendseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "AccessoryId", "AccessoryName", "Quantity" },
                values: new object[,]
                {
                    { 2, "halter", 7 },
                    { 3, "brush", 15 }
                });

            migrationBuilder.InsertData(
                table: "Bedding",
                columns: new[] { "BeddingId", "BeddingName", "Quantity_kg" },
                values: new object[] { 2, "straw", 143 });

            migrationBuilder.InsertData(
                table: "Diet",
                columns: new[] { "DietId", "DietName", "Quantity_kg" },
                values: new object[] { 2, "hay", 452 });

            migrationBuilder.InsertData(
                table: "Toy",
                columns: new[] { "ToyId", "Quantity", "ToyName" },
                values: new object[,]
                {
                    { 2, 5, "salt block" },
                    { 3, 3, "big ball" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "SpeciesId", "AccessoryId", "BeddingId", "DietId", "SpeciesName", "ToyId" },
                values: new object[,]
                {
                    { 2, 2, 2, 2, "cow", 2 },
                    { 3, 3, 2, 2, "horse", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accessory",
                keyColumn: "AccessoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accessory",
                keyColumn: "AccessoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bedding",
                keyColumn: "BeddingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Diet",
                keyColumn: "DietId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Toy",
                keyColumn: "ToyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Toy",
                keyColumn: "ToyId",
                keyValue: 3);
        }
    }
}
