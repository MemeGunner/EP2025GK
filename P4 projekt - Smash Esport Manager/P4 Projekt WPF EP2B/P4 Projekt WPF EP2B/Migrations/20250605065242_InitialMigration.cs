using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P4_Projekt_WPF_EP2B.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    playerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    playerName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    playerPrefix = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    playerPronouns = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    playerDifficulty = table.Column<int>(type: "int", nullable: false),
                    playerCountry = table.Column<string>(type: "nvarchar(56)", maxLength: 56, nullable: false),
                    playerJoinDate = table.Column<DateOnly>(type: "date", nullable: false),
                    playerLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAccountless = table.Column<bool>(type: "bit", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.playerId);
                });

            migrationBuilder.CreateTable(
                name: "Tourneys",
                columns: table => new
                {
                    tourneyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tourneyName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    whichSite = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    siteLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tourneyStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    tourneyEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    isOnline = table.Column<bool>(type: "bit", nullable: false),
                    adress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    city = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    zipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    country = table.Column<string>(type: "nvarchar(56)", maxLength: 56, nullable: false),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourneys", x => x.tourneyId);
                });

            migrationBuilder.CreateTable(
                name: "PlayersInTourneys",
                columns: table => new
                {
                    pitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tourneyId = table.Column<int>(type: "int", nullable: false),
                    playerId = table.Column<int>(type: "int", nullable: false),
                    isPlaying = table.Column<bool>(type: "bit", nullable: false),
                    isTO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersInTourneys", x => x.pitId);
                    table.ForeignKey(
                        name: "FK_PlayersInTourneys_Players_playerId",
                        column: x => x.playerId,
                        principalTable: "Players",
                        principalColumn: "playerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayersInTourneys_Tourneys_tourneyId",
                        column: x => x.tourneyId,
                        principalTable: "Tourneys",
                        principalColumn: "tourneyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayersInTourneys_playerId",
                table: "PlayersInTourneys",
                column: "playerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersInTourneys_tourneyId",
                table: "PlayersInTourneys",
                column: "tourneyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersInTourneys");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Tourneys");
        }
    }
}
