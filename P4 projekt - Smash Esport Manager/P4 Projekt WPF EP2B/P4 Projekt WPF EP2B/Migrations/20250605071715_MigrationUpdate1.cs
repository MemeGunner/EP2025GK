using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P4_Projekt_WPF_EP2B.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "notes",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "playerNotes",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "playerNotes",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "notes",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
