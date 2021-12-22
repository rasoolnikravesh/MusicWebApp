using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWebApp.Migrations
{
    public partial class arrengement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arrangement_Artists_ArtistId",
                table: "Arrangement");

            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Arrangement_ArrangementArtistId",
                table: "Musics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Arrangement",
                table: "Arrangement");

            migrationBuilder.RenameTable(
                name: "Arrangement",
                newName: "Arrangements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arrangements",
                table: "Arrangements",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrangements_Artists_ArtistId",
                table: "Arrangements",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Arrangements_ArrangementArtistId",
                table: "Musics",
                column: "ArrangementArtistId",
                principalTable: "Arrangements",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arrangements_Artists_ArtistId",
                table: "Arrangements");

            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Arrangements_ArrangementArtistId",
                table: "Musics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Arrangements",
                table: "Arrangements");

            migrationBuilder.RenameTable(
                name: "Arrangements",
                newName: "Arrangement");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arrangement",
                table: "Arrangement",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrangement_Artists_ArtistId",
                table: "Arrangement",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Arrangement_ArrangementArtistId",
                table: "Musics",
                column: "ArrangementArtistId",
                principalTable: "Arrangement",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
