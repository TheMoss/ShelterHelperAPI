using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterHelperAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddChipNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "ChipNumber",
                table: "AnimalsDb",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AnimalsDb_SpeciesId",
                table: "AnimalsDb",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalsDb_Species_SpeciesId",
                table: "AnimalsDb",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "SpeciesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalsDb_Species_SpeciesId",
                table: "AnimalsDb");

            migrationBuilder.DropIndex(
                name: "IX_AnimalsDb_SpeciesId",
                table: "AnimalsDb");

            migrationBuilder.DropColumn(
                name: "ChipNumber",
                table: "AnimalsDb");

            migrationBuilder.DropColumn(
                name: "SpeciesId",
                table: "AnimalsDb");

            migrationBuilder.AddColumn<string>(
                name: "Species",
                table: "AnimalsDb",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
