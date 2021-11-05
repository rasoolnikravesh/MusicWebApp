using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWebApp.Migrations
{
    public partial class Rasool4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Artists");

            migrationBuilder.AddColumn<int>(
                name: "SongWriterId",
                table: "Musics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musics_SongWriterId",
                table: "Musics",
                column: "SongWriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Artists_SongWriterId",
                table: "Musics",
                column: "SongWriterId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Artists_SongWriterId",
                table: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Musics_SongWriterId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "SongWriterId",
                table: "Musics");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
