using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWebApp.Migrations
{
    public partial class Rasool5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComposerId",
                table: "Musics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Musics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musics_ComposerId",
                table: "Musics",
                column: "ComposerId");

            migrationBuilder.CreateIndex(
                name: "IX_Musics_GenreId",
                table: "Musics",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Artists_ComposerId",
                table: "Musics",
                column: "ComposerId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Genre_GenreId",
                table: "Musics",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Artists_ComposerId",
                table: "Musics");

            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Genre_GenreId",
                table: "Musics");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Musics_ComposerId",
                table: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Musics_GenreId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "ComposerId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Musics");
        }
    }
}
