using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Football.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class KickoffTimeAddedintoMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Manager_AwayManagerId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Manager_HomeManagerId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Referee_RefereeId",
                table: "Match");

            migrationBuilder.AddColumn<DateTime>(
                name: "KickoffTime",
                table: "Match",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Manager_AwayManagerId",
                table: "Match",
                column: "AwayManagerId",
                principalTable: "Manager",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Manager_HomeManagerId",
                table: "Match",
                column: "HomeManagerId",
                principalTable: "Manager",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Referee_RefereeId",
                table: "Match",
                column: "RefereeId",
                principalTable: "Referee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Manager_AwayManagerId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Manager_HomeManagerId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Referee_RefereeId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "KickoffTime",
                table: "Match");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Manager_AwayManagerId",
                table: "Match",
                column: "AwayManagerId",
                principalTable: "Manager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Manager_HomeManagerId",
                table: "Match",
                column: "HomeManagerId",
                principalTable: "Manager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Referee_RefereeId",
                table: "Match",
                column: "RefereeId",
                principalTable: "Referee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
