using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Football.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YellowCard = table.Column<int>(type: "int", nullable: false),
                    RedCard = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YellowCard = table.Column<int>(type: "int", nullable: false),
                    RedCard = table.Column<int>(type: "int", nullable: false),
                    MinutesPlayed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Referee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinutesPlayed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeManagerId = table.Column<int>(type: "int", nullable: false),
                    AwayManagerId = table.Column<int>(type: "int", nullable: false),
                    RefereeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Manager_AwayManagerId",
                        column: x => x.AwayManagerId,
                        principalTable: "Manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Match_Manager_HomeManagerId",
                        column: x => x.HomeManagerId,
                        principalTable: "Manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Match_Referee_RefereeId",
                        column: x => x.RefereeId,
                        principalTable: "Referee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AwayMatchPlayer",
                columns: table => new
                {
                    AwayMatchesId = table.Column<int>(type: "int", nullable: false),
                    AwayPlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwayMatchPlayer", x => new { x.AwayMatchesId, x.AwayPlayersId });
                    table.ForeignKey(
                        name: "FK_AwayMatchPlayer_Match_AwayMatchesId",
                        column: x => x.AwayMatchesId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AwayMatchPlayer_Player_AwayPlayersId",
                        column: x => x.AwayPlayersId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeMatchPlayer",
                columns: table => new
                {
                    HomeMatchesId = table.Column<int>(type: "int", nullable: false),
                    HomePlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeMatchPlayer", x => new { x.HomeMatchesId, x.HomePlayersId });
                    table.ForeignKey(
                        name: "FK_HomeMatchPlayer_Match_HomeMatchesId",
                        column: x => x.HomeMatchesId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeMatchPlayer_Player_HomePlayersId",
                        column: x => x.HomePlayersId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AwayMatchPlayer_AwayPlayersId",
                table: "AwayMatchPlayer",
                column: "AwayPlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeMatchPlayer_HomePlayersId",
                table: "HomeMatchPlayer",
                column: "HomePlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayManagerId",
                table: "Match",
                column: "AwayManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeManagerId",
                table: "Match",
                column: "HomeManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_RefereeId",
                table: "Match",
                column: "RefereeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AwayMatchPlayer");

            migrationBuilder.DropTable(
                name: "HomeMatchPlayer");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Referee");
        }
    }
}
