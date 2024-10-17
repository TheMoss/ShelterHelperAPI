using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterHelperAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAssignmentIsInProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInProgress",
                table: "Assignment",
                type: "boolean",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 1,
                column: "IsInProgress",
                value: false);

            migrationBuilder.InsertData(
                table: "Assignment",
                columns: new[] { "AssignmentId", "CreationDate", "CreatorId", "Description", "IsCompleted", "IsInProgress", "Priority", "Title" },
                values: new object[] { 2, null, 153094, null, false, true, 3, "Patch leaky roof" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "IsInProgress",
                table: "Assignment");
        }
    }
}
