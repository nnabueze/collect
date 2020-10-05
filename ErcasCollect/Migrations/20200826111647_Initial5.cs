using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillerBankDetails_Banks_BanksId",
                table: "BillerBankDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BillerBankDetails_Billers_BillerId",
                table: "BillerBankDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillerBankDetails_BanksId",
                table: "BillerBankDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillerBankDetails_BillerId",
                table: "BillerBankDetails");

            migrationBuilder.DropColumn(
                name: "BanksId",
                table: "BillerBankDetails");

            migrationBuilder.DropColumn(
                name: "BillerId",
                table: "BillerBankDetails");

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "BillerBankDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "BillerBankDetails");

            migrationBuilder.AddColumn<string>(
                name: "BanksId",
                table: "BillerBankDetails",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillerId",
                table: "BillerBankDetails",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillerBankDetails_BanksId",
                table: "BillerBankDetails",
                column: "BanksId");

            migrationBuilder.CreateIndex(
                name: "IX_BillerBankDetails_BillerId",
                table: "BillerBankDetails",
                column: "BillerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillerBankDetails_Banks_BanksId",
                table: "BillerBankDetails",
                column: "BanksId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillerBankDetails_Billers_BillerId",
                table: "BillerBankDetails",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
