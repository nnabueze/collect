using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class BatchTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Billers_BillerId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Poses_PosId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BillerId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_PosId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BillerId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "OfflineSessionId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PosId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "RemittanceNumber",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "OfflineId",
                table: "Batchs");

            migrationBuilder.AddColumn<string>(
                name: "BatchReferenceKey",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosImei",
                table: "Poses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClosedRemiteId",
                table: "Batchs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Batchs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Createdby",
                table: "Batchs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBatchClosed",
                table: "Batchs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Batchs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Batchs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Batchs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OfflineBatchId",
                table: "Batchs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PosId",
                table: "Batchs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceKey",
                table: "Batchs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_PosId",
                table: "Batchs",
                column: "PosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Poses_PosId",
                table: "Batchs",
                column: "PosId",
                principalTable: "Poses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Poses_PosId",
                table: "Batchs");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_PosId",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "BatchReferenceKey",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PosImei",
                table: "Poses");

            migrationBuilder.DropColumn(
                name: "ClosedRemiteId",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "Createdby",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "IsBatchClosed",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "OfflineBatchId",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "PosId",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "ReferenceKey",
                table: "Batchs");

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BillerId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfflineSessionId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PosId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemittanceNumber",
                table: "Transactions",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfflineId",
                table: "Batchs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BillerId",
                table: "Transactions",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PosId",
                table: "Transactions",
                column: "PosId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Billers_BillerId",
                table: "Transactions",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Poses_PosId",
                table: "Transactions",
                column: "PosId",
                principalTable: "Poses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
