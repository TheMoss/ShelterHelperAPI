using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterHelperAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAnimalsDbFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AddForeignKey(
				name: "FK_AnimalsDb_Employee_EmployeeId",
				table: "AnimalsDb",
				column: "EmployeeId",
				principalTable: "Employee",
				principalColumn: "EmployeeId",
				onDelete: ReferentialAction.Cascade);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropForeignKey(
			   name: "FK_AnimalsDb_Employee_EmployeeId",
			   table: "AnimalsDb");
		}
    }
}
