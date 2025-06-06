using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P4_Projekt_WPF_EP2B.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pitSeeding",
                table: "PlayersInTourneys",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pMainName",
                table: "Players",
                type: "nvarchar(18)",
                maxLength: 18,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pitSeeding",
                table: "PlayersInTourneys");

            migrationBuilder.DropColumn(
                name: "pMainName",
                table: "Players");
        }
    }
}
