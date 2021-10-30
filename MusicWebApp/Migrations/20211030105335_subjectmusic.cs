using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWebApp.Migrations
{
    public partial class subjectmusic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Genre_GenreId",
                table: "Musics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicSubject",
                columns: table => new
                {
                    MusicsId = table.Column<int>(type: "int", nullable: false),
                    SubjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicSubject", x => new { x.MusicsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_MusicSubject_Musics_MusicsId",
                        column: x => x.MusicsId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicSubject_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicSubject_SubjectsId",
                table: "MusicSubject",
                column: "SubjectsId");

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

            migrationBuilder.DropTable(
                name: "MusicSubject");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Genre_GenreId",
                table: "Musics",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
