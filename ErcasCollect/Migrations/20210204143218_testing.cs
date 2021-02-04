using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 4, 14, 32, 17, 334, DateTimeKind.Utc).AddTicks(1352));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 4, 14, 32, 17, 334, DateTimeKind.Utc).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 4, 14, 32, 17, 334, DateTimeKind.Utc).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 4, 14, 32, 17, 334, DateTimeKind.Utc).AddTicks(2381));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 4, 14, 11, 36, 352, DateTimeKind.Utc).AddTicks(723));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 4, 14, 11, 36, 352, DateTimeKind.Utc).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 4, 14, 11, 36, 352, DateTimeKind.Utc).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 4, 14, 11, 36, 352, DateTimeKind.Utc).AddTicks(2248));
        }
    }
}
