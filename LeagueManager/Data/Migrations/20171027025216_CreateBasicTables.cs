using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueManager.Data.Migrations
{
    public partial class CreateBasicTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dates = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TournamentTeams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Seed = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    TeamNameOverride = table.Column<string>(nullable: true),
                    TournamentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TournamentTeams_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TournamentGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ParticipantAGameIsWinner = table.Column<bool>(nullable: true),
                    ParticipantATournamentGameId = table.Column<int>(nullable: true),
                    ParticipantATournamentTeamId = table.Column<int>(nullable: true),
                    ParticipantBGameIsWinner = table.Column<bool>(nullable: true),
                    ParticipantBTournamentGameId = table.Column<int>(nullable: true),
                    ParticipantBTournamentTeamId = table.Column<int>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true),
                    TournamentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentGames_TournamentGames_ParticipantATournamentGameId",
                        column: x => x.ParticipantATournamentGameId,
                        principalTable: "TournamentGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TournamentGames_TournamentTeams_ParticipantATournamentTeamId",
                        column: x => x.ParticipantATournamentTeamId,
                        principalTable: "TournamentTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TournamentGames_TournamentGames_ParticipantBTournamentGameId",
                        column: x => x.ParticipantBTournamentGameId,
                        principalTable: "TournamentGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TournamentGames_TournamentTeams_ParticipantBTournamentTeamId",
                        column: x => x.ParticipantBTournamentTeamId,
                        principalTable: "TournamentTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TournamentGames_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TournamentGameTeams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Score = table.Column<int>(nullable: true),
                    TournamentGameId = table.Column<int>(nullable: false),
                    TournamentTeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentGameTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentGameTeams_TournamentGames_TournamentGameId",
                        column: x => x.TournamentGameId,
                        principalTable: "TournamentGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TournamentGameTeams_TournamentTeams_TournamentTeamId",
                        column: x => x.TournamentTeamId,
                        principalTable: "TournamentTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TournamentGames_ParticipantATournamentGameId",
                table: "TournamentGames",
                column: "ParticipantATournamentGameId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentGames_ParticipantATournamentTeamId",
                table: "TournamentGames",
                column: "ParticipantATournamentTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentGames_ParticipantBTournamentGameId",
                table: "TournamentGames",
                column: "ParticipantBTournamentGameId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentGames_ParticipantBTournamentTeamId",
                table: "TournamentGames",
                column: "ParticipantBTournamentTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentGames_TournamentId",
                table: "TournamentGames",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentGameTeams_TournamentGameId",
                table: "TournamentGameTeams",
                column: "TournamentGameId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentGameTeams_TournamentTeamId",
                table: "TournamentGameTeams",
                column: "TournamentTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentTeams_TeamId",
                table: "TournamentTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentTeams_TournamentId",
                table: "TournamentTeams",
                column: "TournamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TournamentGameTeams");

            migrationBuilder.DropTable(
                name: "TournamentGames");

            migrationBuilder.DropTable(
                name: "TournamentTeams");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
