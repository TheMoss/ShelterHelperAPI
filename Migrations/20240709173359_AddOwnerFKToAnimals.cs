using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterHelperAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddOwnerFKToAnimals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AnimalsDb_OwnerId",
                table: "AnimalsDb",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalsDb_Owner_OwnerId",
                table: "AnimalsDb",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalsDb_Owner_OwnerId",
                table: "AnimalsDb");

            migrationBuilder.DropIndex(
                name: "IX_AnimalsDb_OwnerId",
                table: "AnimalsDb");
        }
    }
}
