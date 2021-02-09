using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class billerProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "BillerEbillsProducts");

            migrationBuilder.AddColumn<int>(
                name: "EbillsProductId",
                table: "BillerEbillsProducts",
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

            migrationBuilder.CreateIndex(
                name: "IX_BillerEbillsProducts_EbillsProductId",
                table: "BillerEbillsProducts",
                column: "EbillsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillerEbillsProducts_EbillsProducts_EbillsProductId",
                table: "BillerEbillsProducts",
                column: "EbillsProductId",
                principalTable: "EbillsProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillerEbillsProducts_EbillsProducts_EbillsProductId",
                table: "BillerEbillsProducts");

            migrationBuilder.DropIndex(
                name: "IX_BillerEbillsProducts_EbillsProductId",
                table: "BillerEbillsProducts");

            migrationBuilder.DropColumn(
                name: "EbillsProductId",
                table: "BillerEbillsProducts");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "BillerEbillsProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 8, 22, 23, 27, 536, DateTimeKind.Utc).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 8, 22, 23, 27, 536, DateTimeKind.Utc).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 8, 22, 23, 27, 536, DateTimeKind.Utc).AddTicks(4228));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 8, 22, 23, 27, 536, DateTimeKind.Utc).AddTicks(4230));
        }
    }
}
