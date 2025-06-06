using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P4_Projekt_WPF_EP2B.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayersInTourneys_Players_playerId",
                table: "PlayersInTourneys");

            migrationBuilder.DropColumn(
                name: "adress",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "city",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "country",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "notes",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "siteLink",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "zipCode",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "playerCountry",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "playerDifficulty",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "playerJoinDate",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "playerLink",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "playerPrefix",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "playerPronouns",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "whichSite",
                table: "Tourneys",
                newName: "tWhichSite");

            migrationBuilder.RenameColumn(
                name: "isOnline",
                table: "Tourneys",
                newName: "tIsOnline");

            migrationBuilder.RenameColumn(
                name: "playerId",
                table: "PlayersInTourneys",
                newName: "playerpId");

            migrationBuilder.RenameColumn(
                name: "isTO",
                table: "PlayersInTourneys",
                newName: "pitIsTO");

            migrationBuilder.RenameColumn(
                name: "isPlaying",
                table: "PlayersInTourneys",
                newName: "pitIsPlaying");

            migrationBuilder.RenameIndex(
                name: "IX_PlayersInTourneys_playerId",
                table: "PlayersInTourneys",
                newName: "IX_PlayersInTourneys_playerpId");

            migrationBuilder.RenameColumn(
                name: "playerNotes",
                table: "Players",
                newName: "pNotes");

            migrationBuilder.RenameColumn(
                name: "playerName",
                table: "Players",
                newName: "pName");

            migrationBuilder.RenameColumn(
                name: "isAccountless",
                table: "Players",
                newName: "pIsAccountless");

            migrationBuilder.RenameColumn(
                name: "playerId",
                table: "Players",
                newName: "pId");

            migrationBuilder.AddColumn<string>(
                name: "tAdress",
                table: "Tourneys",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tCity",
                table: "Tourneys",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tCountry",
                table: "Tourneys",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tNotes",
                table: "Tourneys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tSiteLink",
                table: "Tourneys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tZipCode",
                table: "Tourneys",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pCountry",
                table: "Players",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pDifficulty",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "pJoinDate",
                table: "Players",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pLink",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pPrefix",
                table: "Players",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pPronouns",
                table: "Players",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersInTourneys_Players_playerpId",
                table: "PlayersInTourneys",
                column: "playerpId",
                principalTable: "Players",
                principalColumn: "pId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayersInTourneys_Players_playerpId",
                table: "PlayersInTourneys");

            migrationBuilder.DropColumn(
                name: "tAdress",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "tCity",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "tCountry",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "tNotes",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "tSiteLink",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "tZipCode",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "pCountry",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "pDifficulty",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "pJoinDate",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "pLink",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "pPrefix",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "pPronouns",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "tWhichSite",
                table: "Tourneys",
                newName: "whichSite");

            migrationBuilder.RenameColumn(
                name: "tIsOnline",
                table: "Tourneys",
                newName: "isOnline");

            migrationBuilder.RenameColumn(
                name: "playerpId",
                table: "PlayersInTourneys",
                newName: "playerId");

            migrationBuilder.RenameColumn(
                name: "pitIsTO",
                table: "PlayersInTourneys",
                newName: "isTO");

            migrationBuilder.RenameColumn(
                name: "pitIsPlaying",
                table: "PlayersInTourneys",
                newName: "isPlaying");

            migrationBuilder.RenameIndex(
                name: "IX_PlayersInTourneys_playerpId",
                table: "PlayersInTourneys",
                newName: "IX_PlayersInTourneys_playerId");

            migrationBuilder.RenameColumn(
                name: "pNotes",
                table: "Players",
                newName: "playerNotes");

            migrationBuilder.RenameColumn(
                name: "pName",
                table: "Players",
                newName: "playerName");

            migrationBuilder.RenameColumn(
                name: "pIsAccountless",
                table: "Players",
                newName: "isAccountless");

            migrationBuilder.RenameColumn(
                name: "pId",
                table: "Players",
                newName: "playerId");

            migrationBuilder.AddColumn<string>(
                name: "adress",
                table: "Tourneys",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "Tourneys",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "Tourneys",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "notes",
                table: "Tourneys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "siteLink",
                table: "Tourneys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "zipCode",
                table: "Tourneys",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "playerCountry",
                table: "Players",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "playerDifficulty",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "playerJoinDate",
                table: "Players",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "playerLink",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "playerPrefix",
                table: "Players",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "playerPronouns",
                table: "Players",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersInTourneys_Players_playerId",
                table: "PlayersInTourneys",
                column: "playerId",
                principalTable: "Players",
                principalColumn: "playerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
