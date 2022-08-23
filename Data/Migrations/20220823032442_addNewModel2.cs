using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationDevelopment.Data.Migrations
{
    public partial class addNewModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BookId",
                table: "Orders Detail",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders Detail_BookId",
                table: "Orders Detail",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders Detail_Book_BookId",
                table: "Orders Detail",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Isbn",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders Detail_Book_BookId",
                table: "Orders Detail");

            migrationBuilder.DropIndex(
                name: "IX_Orders Detail_BookId",
                table: "Orders Detail");

            migrationBuilder.AlterColumn<string>(
                name: "BookId",
                table: "Orders Detail",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
