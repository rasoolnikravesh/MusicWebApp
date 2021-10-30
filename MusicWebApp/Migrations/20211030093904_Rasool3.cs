using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWebApp.Migrations
{
    public partial class Rasool3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Singer_SingerId",
                table: "Musics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Singer",
                table: "Singer");

            migrationBuilder.RenameTable(
                name: "Singer",
                newName: "Artists");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists",
                table: "Artists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Artists_SingerId",
                table: "Musics",
                column: "SingerId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Artists_SingerId",
                table: "Musics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artists",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Artists");

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "Singer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Singer",
                table: "Singer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Singer_SingerId",
                table: "Musics",
                column: "SingerId",
                principalTable: "Singer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
