using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterHelperAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddOwnerIdToAnimalsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "AnimalsDb",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "AnimalsDb");
        }
    }
}
