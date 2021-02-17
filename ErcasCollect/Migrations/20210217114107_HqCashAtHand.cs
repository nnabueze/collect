using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class HqCashAtHand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.HqAllBillersMonthlyCashAtHand AS
                            Select SUM(ISNULL(TotalAmount,0.00)) as TotalAmount
                            From dbo.Batchs c
                            WHERE c.IsBatchClosed = 0 AND MONTH(c.CreatedDate) = MONTH(getdate());');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("exec('drop view dbo.HqAllBillersMonthlyCashAtHand');");
        }
    }
}
