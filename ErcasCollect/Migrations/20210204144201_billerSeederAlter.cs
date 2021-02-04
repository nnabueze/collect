using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class billerSeederAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BillerTypes",
                columns: new[] { "Id", "Category" },
                values: new object[,]
                {
                    { 1, "Igr" },
                    { 2, "School" },
                    { 3, "Hospital" },
                    { 4, "Store" }
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BillerTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BillerTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BillerTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BillerTypes",
                keyColumn: "Id",
                keyValue: 4);

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
    }
}
