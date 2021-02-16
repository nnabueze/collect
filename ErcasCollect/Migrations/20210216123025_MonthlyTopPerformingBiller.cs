using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class MonthlyTopPerformingBiller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.MonthlyTopPerformingBillers AS
                            Select b.Name as BillerName, b.Id as BillerId, SUM(ISNULL(c.TotalAmount,0.00)) as TotalAmount
                            From dbo.Billers b
                            LEFT JOIN dbo.CloseBatchTransactions c ON
                            b.Id = c.BillerId AND c.IsPaid = 1 AND Month(c.CreatedDate) = Month(getdate())
                            GROUP BY b.Id, b.Name;');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("exec('drop view dbo.MonthlyTopPerformingBillers');");
        }
    }
}
