using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWebApp.Migrations
{
    public partial class addlazyloading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Genres_GenreId",
                table: "Musics");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Genres_GenreId",
                table: "Musics",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Genres_GenreId",
                table: "Musics");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Genres_GenreId",
                table: "Musics",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
