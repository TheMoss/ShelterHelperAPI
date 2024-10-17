using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShelterHelperAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAssignmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalsDb_Species_SpeciesId",
                table: "AnimalsDb");

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "AnimalsDb",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "AnimalsDb",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Health",
                table: "AnimalsDb",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: false),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.AssignmentId);
                });

            migrationBuilder.InsertData(
                table: "Assignment",
                columns: new[] { "AssignmentId", "CreationDate", "CreatorId", "Description", "IsCompleted", "Priority", "Title" },
                values: new object[] { 1, null, 142095, null, false, 2, "Clean the floors" });

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalsDb_Species_SpeciesId",
                table: "AnimalsDb",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalsDb_Species_SpeciesId",
                table: "AnimalsDb");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "AnimalsDb",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "AnimalsDb",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Health",
                table: "AnimalsDb",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalsDb_Species_SpeciesId",
                table: "AnimalsDb",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "SpeciesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
