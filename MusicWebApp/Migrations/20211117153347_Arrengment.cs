using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWebApp.Migrations
{
    public partial class Arrengment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArrangementArtistId",
                table: "Musics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Arrangement",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrangement", x => x.ArtistId);
                    table.ForeignKey(
                        name: "FK_Arrangement_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musics_ArrangementArtistId",
                table: "Musics",
                column: "ArrangementArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Arrangement_ArrangementArtistId",
                table: "Musics",
                column: "ArrangementArtistId",
                principalTable: "Arrangement",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Arrangement_ArrangementArtistId",
                table: "Musics");

            migrationBuilder.DropTable(
                name: "Arrangement");

            migrationBuilder.DropIndex(
                name: "IX_Musics_ArrangementArtistId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "ArrangementArtistId",
                table: "Musics");
        }
    }
}
