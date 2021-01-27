using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class generalAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentChannel",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionNumber",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "TransactionStatus",
                table: "Settlements");

            migrationBuilder.AlterColumn<string>(
                name: "OfflineBatchId",
                table: "Transactions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceKey",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuccess",
                table: "Settlements",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "ReferenceKey",
                table: "Batchs",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OfflineBatchId",
                table: "Batchs",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuccess",
                table: "Batchs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentChannel",
                table: "Batchs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "Batchs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_OfflineBatchId",
                table: "Transactions",
                column: "OfflineBatchId",
                unique: true,
                filter: "[OfflineBatchId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ReferenceKey",
                table: "Transactions",
                column: "ReferenceKey",
                unique: true,
                filter: "[ReferenceKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_OfflineBatchId",
                table: "Batchs",
                column: "OfflineBatchId",
                unique: true,
                filter: "[OfflineBatchId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_ReferenceKey",
                table: "Batchs",
                column: "ReferenceKey",
                unique: true,
                filter: "[ReferenceKey] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_OfflineBatchId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ReferenceKey",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_OfflineBatchId",
                table: "Batchs");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_ReferenceKey",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "ReferenceKey",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IsSuccess",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "IsSuccess",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "PaymentChannel",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Batchs");

            migrationBuilder.AlterColumn<string>(
                name: "OfflineBatchId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentChannel",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TransactionNumber",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "Settlements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TransactionStatus",
                table: "Settlements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReferenceKey",
                table: "Batchs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OfflineBatchId",
                table: "Batchs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
