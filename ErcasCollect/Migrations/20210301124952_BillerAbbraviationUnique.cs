using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class BillerAbbraviationUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 1, 12, 49, 51, 199, DateTimeKind.Utc).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 1, 12, 49, 51, 199, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 1, 12, 49, 51, 199, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 1, 12, 49, 51, 199, DateTimeKind.Utc).AddTicks(3742));

            migrationBuilder.CreateIndex(
                name: "IX_Billers_Abbreviation",
                table: "Billers",
                column: "Abbreviation",
                unique: true,
                filter: "[Abbreviation] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Billers_Abbreviation",
                table: "Billers");

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 17, 14, 1, 16, 182, DateTimeKind.Utc).AddTicks(5651));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 17, 14, 1, 16, 182, DateTimeKind.Utc).AddTicks(6634));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 17, 14, 1, 16, 182, DateTimeKind.Utc).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 17, 14, 1, 16, 182, DateTimeKind.Utc).AddTicks(6657));
        }
    }
}
