using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P4_Projekt_WPF_EP2B.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayersInTourneys_Tourneys_tourneyId",
                table: "PlayersInTourneys");

            migrationBuilder.RenameColumn(
                name: "tourneyStartDate",
                table: "Tourneys",
                newName: "tStartDate");

            migrationBuilder.RenameColumn(
                name: "tourneyName",
                table: "Tourneys",
                newName: "tName");

            migrationBuilder.RenameColumn(
                name: "tourneyEndDate",
                table: "Tourneys",
                newName: "tEndDate");

            migrationBuilder.RenameColumn(
                name: "tourneyId",
                table: "Tourneys",
                newName: "tId");

            migrationBuilder.RenameColumn(
                name: "tourneyId",
                table: "PlayersInTourneys",
                newName: "tourneytId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayersInTourneys_tourneyId",
                table: "PlayersInTourneys",
                newName: "IX_PlayersInTourneys_tourneytId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersInTourneys_Tourneys_tourneytId",
                table: "PlayersInTourneys",
                column: "tourneytId",
                principalTable: "Tourneys",
                principalColumn: "tId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayersInTourneys_Tourneys_tourneytId",
                table: "PlayersInTourneys");

            migrationBuilder.RenameColumn(
                name: "tStartDate",
                table: "Tourneys",
                newName: "tourneyStartDate");

            migrationBuilder.RenameColumn(
                name: "tName",
                table: "Tourneys",
                newName: "tourneyName");

            migrationBuilder.RenameColumn(
                name: "tEndDate",
                table: "Tourneys",
                newName: "tourneyEndDate");

            migrationBuilder.RenameColumn(
                name: "tId",
                table: "Tourneys",
                newName: "tourneyId");

            migrationBuilder.RenameColumn(
                name: "tourneytId",
                table: "PlayersInTourneys",
                newName: "tourneyId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayersInTourneys_tourneytId",
                table: "PlayersInTourneys",
                newName: "IX_PlayersInTourneys_tourneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersInTourneys_Tourneys_tourneyId",
                table: "PlayersInTourneys",
                column: "tourneyId",
                principalTable: "Tourneys",
                principalColumn: "tourneyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
