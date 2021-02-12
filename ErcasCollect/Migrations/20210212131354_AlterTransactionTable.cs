using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class AlterTransactionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchReferenceKey",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 12, 13, 13, 53, 95, DateTimeKind.Utc).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 12, 13, 13, 53, 95, DateTimeKind.Utc).AddTicks(6923));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 12, 13, 13, 53, 95, DateTimeKind.Utc).AddTicks(6942));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 12, 13, 13, 53, 95, DateTimeKind.Utc).AddTicks(6943));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BatchId",
                table: "Transactions",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Batchs_BatchId",
                table: "Transactions",
                column: "BatchId",
                principalTable: "Batchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Batchs_BatchId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BatchId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Transactions");

            migrationBuilder.AddColumn<string>(
                name: "BatchReferenceKey",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 9, 14, 0, 11, 4, DateTimeKind.Utc).AddTicks(485));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 9, 14, 0, 11, 4, DateTimeKind.Utc).AddTicks(1819));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 9, 14, 0, 11, 4, DateTimeKind.Utc).AddTicks(1840));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 9, 14, 0, 11, 4, DateTimeKind.Utc).AddTicks(1841));
        }
    }
}
