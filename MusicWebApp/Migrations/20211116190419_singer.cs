using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWebApp.Migrations
{
    public partial class singer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Artists_SingerId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Artists");

            migrationBuilder.RenameColumn(
                name: "SingerId",
                table: "Musics",
                newName: "SongWriterArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Musics_SingerId",
                table: "Musics",
                newName: "IX_Musics_SongWriterArtistId");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Musics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SingerArtistId",
                table: "Musics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Singers",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Singers", x => x.ArtistId);
                    table.ForeignKey(
                        name: "FK_Singers_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongWriters",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    NikName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongWriters", x => x.ArtistId);
                    table.ForeignKey(
                        name: "FK_SongWriters_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SingerArtistId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genres_Singers_SingerArtistId",
                        column: x => x.SingerArtistId,
                        principalTable: "Singers",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Musics_GenreId",
                table: "Musics",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Musics_SingerArtistId",
                table: "Musics",
                column: "SingerArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_SingerArtistId",
                table: "Genres",
                column: "SingerArtistId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Singers_SingerArtistId",
                table: "Musics",
                column: "SingerArtistId",
                principalTable: "Singers",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_SongWriters_SongWriterArtistId",
                table: "Musics",
                column: "SongWriterArtistId",
                principalTable: "SongWriters",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Genres_GenreId",
                table: "Musics");

            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Singers_SingerArtistId",
                table: "Musics");

            migrationBuilder.DropForeignKey(
                name: "FK_Musics_SongWriters_SongWriterArtistId",
                table: "Musics");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "MusicSubject");

            migrationBuilder.DropTable(
                name: "SongWriters");

            migrationBuilder.DropTable(
                name: "Singers");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Musics_GenreId",
                table: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Musics_SingerArtistId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "SingerArtistId",
                table: "Musics");

            migrationBuilder.RenameColumn(
                name: "SongWriterArtistId",
                table: "Musics",
                newName: "SingerId");

            migrationBuilder.RenameIndex(
                name: "IX_Musics_SongWriterArtistId",
                table: "Musics",
                newName: "IX_Musics_SingerId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Artists_SingerId",
                table: "Musics",
                column: "SingerId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
