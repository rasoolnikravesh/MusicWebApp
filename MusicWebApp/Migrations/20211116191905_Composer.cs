using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWebApp.Migrations
{
    public partial class Composer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComposerArtistId",
                table: "Musics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Composer",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Composer", x => x.ArtistId);
                    table.ForeignKey(
                        name: "FK_Composer_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musics_ComposerArtistId",
                table: "Musics",
                column: "ComposerArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Composer_ComposerArtistId",
                table: "Musics",
                column: "ComposerArtistId",
                principalTable: "Composer",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Composer_ComposerArtistId",
                table: "Musics");

            migrationBuilder.DropTable(
                name: "Composer");

            migrationBuilder.DropIndex(
                name: "IX_Musics_ComposerArtistId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "ComposerArtistId",
                table: "Musics");
        }
    }
}
