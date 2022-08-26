using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationDevelopment.Data.Migrations
{
    public partial class updateDb05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders Detail_Orders_OrderId",
                table: "Orders Detail");

            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "Orders Detail",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders Detail_OrdersId",
                table: "Orders Detail",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders Detail_Orders_OrdersId",
                table: "Orders Detail",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders Detail_Orders_OrdersId",
                table: "Orders Detail");

            migrationBuilder.DropIndex(
                name: "IX_Orders Detail_OrdersId",
                table: "Orders Detail");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "Orders Detail");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders Detail_Orders_OrderId",
                table: "Orders Detail",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
