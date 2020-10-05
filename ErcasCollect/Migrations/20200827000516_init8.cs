using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "BillerBankDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankId",
                table: "BillerBankDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillerId",
                table: "BillerBankDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillerBankDetails_BankId",
                table: "BillerBankDetails",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BillerBankDetails_BillerId",
                table: "BillerBankDetails",
                column: "BillerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillerBankDetails_Banks_BankId",
                table: "BillerBankDetails",
                column: "BankId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillerBankDetails_Banks_BankId",
                table: "BillerBankDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BillerBankDetails_Billers_BillerId",
                table: "BillerBankDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillerBankDetails_BankId",
                table: "BillerBankDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillerBankDetails_BillerId",
                table: "BillerBankDetails");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "BillerBankDetails");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "BillerBankDetails");

            migrationBuilder.DropColumn(
                name: "BillerId",
                table: "BillerBankDetails");
        }
    }
}
