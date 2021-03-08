using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class alterTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentChannelId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 12, 32, 35, 29, DateTimeKind.Utc).AddTicks(2931));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 12, 32, 35, 29, DateTimeKind.Utc).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 12, 32, 35, 29, DateTimeKind.Utc).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 12, 32, 35, 29, DateTimeKind.Utc).AddTicks(4630));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PaymentChannelId",
                table: "Transactions",
                column: "PaymentChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_PaymentChannels_PaymentChannelId",
                table: "Transactions",
                column: "PaymentChannelId",
                principalTable: "PaymentChannels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_PaymentChannels_PaymentChannelId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_PaymentChannelId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PaymentChannelId",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 11, 15, 30, 57, DateTimeKind.Utc).AddTicks(8309));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 11, 15, 30, 57, DateTimeKind.Utc).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 11, 15, 30, 57, DateTimeKind.Utc).AddTicks(9580));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 11, 15, 30, 57, DateTimeKind.Utc).AddTicks(9582));
        }
    }
}
