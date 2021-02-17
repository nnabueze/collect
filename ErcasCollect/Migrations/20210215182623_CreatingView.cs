using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class CreatingView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.HqAllBillersYearlyTotalAmount AS
                            SELECT sum(ISNULL(TotalAmount,0.00)) as TotalAmountProcessed
                            FROM dbo.CloseBatchTransactions
                            WHERE IsPaid = 1 AND YEAR(CreatedDate) = YEAR(getdate());');");

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 15, 18, 26, 22, 840, DateTimeKind.Utc).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 15, 18, 26, 22, 840, DateTimeKind.Utc).AddTicks(7982));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 15, 18, 26, 22, 840, DateTimeKind.Utc).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 15, 18, 26, 22, 840, DateTimeKind.Utc).AddTicks(8002));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("exec('drop view dbo.HqAllBillersYearlyTotalAmount');");

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
        }
    }
}
