using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationDevelopment.Data.Migrations
{
    public partial class addNewModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Book_Isbn",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Isbn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Isbn",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Isbn",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Isbn",
                table: "Users",
                column: "Isbn");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Book_Isbn",
                table: "Users",
                column: "Isbn",
                principalTable: "Book",
                principalColumn: "Isbn",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
