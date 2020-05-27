using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaAppV2.Migrations
{
    public partial class orderseatrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "showTime",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "Seat",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_orderId",
                table: "Seat",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Order_orderId",
                table: "Seat",
                column: "orderId",
                principalTable: "Order",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Order_orderId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Seat_orderId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "Seat");

            migrationBuilder.AddColumn<int>(
                name: "showTime",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
