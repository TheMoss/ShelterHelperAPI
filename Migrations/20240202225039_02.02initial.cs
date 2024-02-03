using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShelterHelperAPI.Migrations
{
    /// <inheritdoc />
    public partial class _0202initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessory",
                columns: table => new
                {
                    AccessoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccessoryName = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessory", x => x.AccessoryId);
                });
                       

            migrationBuilder.CreateTable(
                name: "Bedding",
                columns: table => new
                {
                    BeddingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BeddingName = table.Column<string>(type: "text", nullable: false),
                    Quantity_kg = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedding", x => x.BeddingId);
                });

            migrationBuilder.CreateTable(
                name: "Diet",
                columns: table => new
                {
                    DietId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DietName = table.Column<string>(type: "text", nullable: false),
                    Quantity_kg = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diet", x => x.DietId);
                });

            migrationBuilder.CreateTable(
                name: "Toy",
                columns: table => new
                {
                    ToyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ToyName = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toy", x => x.ToyId);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    SpeciesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpeciesName = table.Column<string>(type: "text", nullable: false),
                    DietId = table.Column<int>(type: "integer", nullable: false),
                    BeddingId = table.Column<int>(type: "integer", nullable: false),
                    ToyId = table.Column<int>(type: "integer", nullable: false),
                    AccessoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.SpeciesId);
                    table.ForeignKey(
                        name: "FK_Species_Accessory_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessory",
                        principalColumn: "AccessoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Species_Bedding_BeddingId",
                        column: x => x.BeddingId,
                        principalTable: "Bedding",
                        principalColumn: "BeddingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Species_Diet_DietId",
                        column: x => x.DietId,
                        principalTable: "Diet",
                        principalColumn: "DietId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Species_Toy_ToyId",
                        column: x => x.ToyId,
                        principalTable: "Toy",
                        principalColumn: "ToyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "AccessoryId", "AccessoryName", "Quantity" },
                values: new object[] { 1, "collar", 14 });

            migrationBuilder.InsertData(
                table: "Bedding",
                columns: new[] { "BeddingId", "BeddingName", "Quantity_kg" },
                values: new object[] { 1, "blanket", 9 });

            migrationBuilder.InsertData(
                table: "Diet",
                columns: new[] { "DietId", "DietName", "Quantity_kg" },
                values: new object[] { 1, "dog food", 157 });

            migrationBuilder.InsertData(
                table: "Toy",
                columns: new[] { "ToyId", "Quantity", "ToyName" },
                values: new object[] { 1, 20, "ball" });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "SpeciesId", "AccessoryId", "BeddingId", "DietId", "SpeciesName", "ToyId" },
                values: new object[] { 1, 1, 1, 1, "dog", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Species_AccessoryId",
                table: "Species",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_BeddingId",
                table: "Species",
                column: "BeddingId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_DietId",
                table: "Species",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_ToyId",
                table: "Species",
                column: "ToyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalsDb");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Accessory");

            migrationBuilder.DropTable(
                name: "Bedding");

            migrationBuilder.DropTable(
                name: "Diet");

            migrationBuilder.DropTable(
                name: "Toy");
        }
    }
}
