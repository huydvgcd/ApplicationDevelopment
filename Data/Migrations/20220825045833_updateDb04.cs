using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationDevelopment.Data.Migrations
{
    public partial class updateDb04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders Detail_Book_BookId",
                table: "Orders Detail");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders Detail_Orders_OrderId",
                table: "Orders Detail");

            migrationBuilder.DropIndex(
                name: "IX_Orders Detail_OrderId",
                table: "Orders Detail");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Orders Detail",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Orders Detail",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders Detail",
                table: "Orders Detail",
                columns: new[] { "OrderId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders Detail_Book_BookId",
                table: "Orders Detail",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders Detail_Orders_OrderId",
                table: "Orders Detail",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders Detail_Book_BookId",
                table: "Orders Detail");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders Detail_Orders_OrderId",
                table: "Orders Detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders Detail",
                table: "Orders Detail");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Orders Detail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Orders Detail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Orders Detail_OrderId",
                table: "Orders Detail",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders Detail_Book_BookId",
                table: "Orders Detail",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders Detail_Orders_OrderId",
                table: "Orders Detail",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
