using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWebApp.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Musics");

            migrationBuilder.AddColumn<int>(
                name: "Image",
                table: "Artists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Artists");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Musics",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
