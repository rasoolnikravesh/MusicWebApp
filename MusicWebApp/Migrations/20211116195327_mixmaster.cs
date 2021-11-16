using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWebApp.Migrations
{
    public partial class mixmaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Composer_Artists_ArtistId",
                table: "Composer");

            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Composer_ComposerArtistId",
                table: "Musics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Composer",
                table: "Composer");

            migrationBuilder.RenameTable(
                name: "Composer",
                newName: "Composers");

            migrationBuilder.AddColumn<int>(
                name: "MixMasterArtistId",
                table: "Musics",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Composers",
                table: "Composers",
                column: "ArtistId");

            migrationBuilder.CreateTable(
                name: "MixMasters",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MixMasters", x => x.ArtistId);
                    table.ForeignKey(
                        name: "FK_MixMasters_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musics_MixMasterArtistId",
                table: "Musics",
                column: "MixMasterArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Composers_Artists_ArtistId",
                table: "Composers",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Composers_ComposerArtistId",
                table: "Musics",
                column: "ComposerArtistId",
                principalTable: "Composers",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_MixMasters_MixMasterArtistId",
                table: "Musics",
                column: "MixMasterArtistId",
                principalTable: "MixMasters",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Composers_Artists_ArtistId",
                table: "Composers");

            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Composers_ComposerArtistId",
                table: "Musics");

            migrationBuilder.DropForeignKey(
                name: "FK_Musics_MixMasters_MixMasterArtistId",
                table: "Musics");

            migrationBuilder.DropTable(
                name: "MixMasters");

            migrationBuilder.DropIndex(
                name: "IX_Musics_MixMasterArtistId",
                table: "Musics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Composers",
                table: "Composers");

            migrationBuilder.DropColumn(
                name: "MixMasterArtistId",
                table: "Musics");

            migrationBuilder.RenameTable(
                name: "Composers",
                newName: "Composer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Composer",
                table: "Composer",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Composer_Artists_ArtistId",
                table: "Composer",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Composer_ComposerArtistId",
                table: "Musics",
                column: "ComposerArtistId",
                principalTable: "Composer",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
