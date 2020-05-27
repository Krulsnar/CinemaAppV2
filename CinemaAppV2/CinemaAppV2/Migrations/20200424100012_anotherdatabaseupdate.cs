using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaAppV2.Migrations
{
    public partial class anotherdatabaseupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Show_Movie_movieId",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_Theater_theaterId",
                table: "Show");

            migrationBuilder.AlterColumn<int>(
                name: "theaterId",
                table: "Show",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "movieId",
                table: "Show",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Movie_movieId",
                table: "Show",
                column: "movieId",
                principalTable: "Movie",
                principalColumn: "movieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Theater_theaterId",
                table: "Show",
                column: "theaterId",
                principalTable: "Theater",
                principalColumn: "theaterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Show_Movie_movieId",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_Theater_theaterId",
                table: "Show");

            migrationBuilder.AlterColumn<int>(
                name: "theaterId",
                table: "Show",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "movieId",
                table: "Show",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Movie_movieId",
                table: "Show",
                column: "movieId",
                principalTable: "Movie",
                principalColumn: "movieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Theater_theaterId",
                table: "Show",
                column: "theaterId",
                principalTable: "Theater",
                principalColumn: "theaterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
