using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class BatcClosedBatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<int>(
                name: "TransactionTypeId",
                table: "CloseBatchTransactions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OfflineCreatedDate",
                table: "Batchs",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 8, 15, 13, 17, 853, DateTimeKind.Utc).AddTicks(4250));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 8, 15, 13, 17, 853, DateTimeKind.Utc).AddTicks(5823));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 8, 15, 13, 17, 853, DateTimeKind.Utc).AddTicks(5859));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 8, 15, 13, 17, 853, DateTimeKind.Utc).AddTicks(5863));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Biller Admin previllages", "BillerAdmin" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Views all the report under Mda", "LevelOne" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Views all the report under station", "LevelTwo" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Pos agents that only collect", "PosCollector" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Pos agents that collect and remit", "PosRemitter" });

            migrationBuilder.CreateIndex(
                name: "IX_CloseBatchTransactions_TransactionTypeId",
                table: "CloseBatchTransactions",
                column: "TransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CloseBatchTransactions_TransactionTypes_TransactionTypeId",
                table: "CloseBatchTransactions",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CloseBatchTransactions_TransactionTypes_TransactionTypeId",
                table: "CloseBatchTransactions");

            migrationBuilder.DropIndex(
                name: "IX_CloseBatchTransactions_TransactionTypeId",
                table: "CloseBatchTransactions");

            migrationBuilder.DropColumn(
                name: "TransactionTypeId",
                table: "CloseBatchTransactions");

            migrationBuilder.DropColumn(
                name: "OfflineCreatedDate",
                table: "Batchs");

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 4, 14, 41, 59, 939, DateTimeKind.Utc).AddTicks(7810));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 4, 14, 41, 59, 939, DateTimeKind.Utc).AddTicks(9585));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 4, 14, 41, 59, 939, DateTimeKind.Utc).AddTicks(9617));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 4, 14, 41, 59, 939, DateTimeKind.Utc).AddTicks(9624));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Has all the right to the system eg HQ", "SuperAdmin" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Biller Admin previllages", "Admin" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Views all the report under Mda", "LevelOne" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Views all the report under station", "LevelTwo" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Pos agents that only collect", "PosCollector" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 6, "Pos agents that collect and remit", "PosRemitter" });
        }
    }
}
