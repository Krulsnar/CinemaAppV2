using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaAppV2.Migrations
{
    public partial class orderseatrelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Order_orderId",
                table: "Seat");

            migrationBuilder.AlterColumn<int>(
                name: "orderId",
                table: "Seat",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Order_orderId",
                table: "Seat",
                column: "orderId",
                principalTable: "Order",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Order_orderId",
                table: "Seat");

            migrationBuilder.AlterColumn<int>(
                name: "orderId",
                table: "Seat",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Order_orderId",
                table: "Seat",
                column: "orderId",
                principalTable: "Order",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
