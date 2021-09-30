using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class GeneralAlteration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentChannel",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "PaymentChannel",
                table: "CloseBatchTransactions");

            migrationBuilder.DropColumn(
                name: "PaymentChannel",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Batchs");

            migrationBuilder.AddColumn<int>(
                name: "PaymentChannelId",
                table: "Settlements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionTypeId",
                table: "Settlements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentChannelId",
                table: "CloseBatchTransactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentChannelId",
                table: "Batchs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionTypeId",
                table: "Batchs",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 3, 19, 33, 28, 705, DateTimeKind.Utc).AddTicks(313));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 3, 19, 33, 28, 705, DateTimeKind.Utc).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 3, 19, 33, 28, 705, DateTimeKind.Utc).AddTicks(1377));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 3, 19, 33, 28, 705, DateTimeKind.Utc).AddTicks(1378));

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_PaymentChannelId",
                table: "Settlements",
                column: "PaymentChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_TransactionTypeId",
                table: "Settlements",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CloseBatchTransactions_PaymentChannelId",
                table: "CloseBatchTransactions",
                column: "PaymentChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_PaymentChannelId",
                table: "Batchs",
                column: "PaymentChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_TransactionTypeId",
                table: "Batchs",
                column: "TransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_PaymentChannels_PaymentChannelId",
                table: "Batchs",
                column: "PaymentChannelId",
                principalTable: "PaymentChannels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_TransactionTypes_TransactionTypeId",
                table: "Batchs",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CloseBatchTransactions_PaymentChannels_PaymentChannelId",
                table: "CloseBatchTransactions",
                column: "PaymentChannelId",
                principalTable: "PaymentChannels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_PaymentChannels_PaymentChannelId",
                table: "Settlements",
                column: "PaymentChannelId",
                principalTable: "PaymentChannels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_TransactionTypes_TransactionTypeId",
                table: "Settlements",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_PaymentChannels_PaymentChannelId",
                table: "Batchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_TransactionTypes_TransactionTypeId",
                table: "Batchs");

            migrationBuilder.DropForeignKey(
                name: "FK_CloseBatchTransactions_PaymentChannels_PaymentChannelId",
                table: "CloseBatchTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_PaymentChannels_PaymentChannelId",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_TransactionTypes_TransactionTypeId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_PaymentChannelId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_TransactionTypeId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_CloseBatchTransactions_PaymentChannelId",
                table: "CloseBatchTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_PaymentChannelId",
                table: "Batchs");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_TransactionTypeId",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "PaymentChannelId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "TransactionTypeId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "PaymentChannelId",
                table: "CloseBatchTransactions");

            migrationBuilder.DropColumn(
                name: "PaymentChannelId",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "TransactionTypeId",
                table: "Batchs");

            migrationBuilder.AddColumn<int>(
                name: "PaymentChannel",
                table: "Settlements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "Settlements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentChannel",
                table: "CloseBatchTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentChannel",
                table: "Batchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "Batchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 3, 19, 3, 44, 773, DateTimeKind.Utc).AddTicks(365));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 3, 19, 3, 44, 773, DateTimeKind.Utc).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 3, 19, 3, 44, 773, DateTimeKind.Utc).AddTicks(1940));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 3, 19, 3, 44, 773, DateTimeKind.Utc).AddTicks(1942));
        }
    }
}
