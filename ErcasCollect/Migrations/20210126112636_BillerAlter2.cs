using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class BillerAlter2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Billers_BillerId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Abbreviation",
                table: "Billers",
                type: "nvarchar(16)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Billers_BillerId",
                table: "Users",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Billers_BillerId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Abbreviation",
                table: "Billers",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Billers_BillerId",
                table: "Users",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
