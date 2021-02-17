using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class HqperiodicalReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.HqDaylyTotalAmount AS
                            SELECT sum(ISNULL(TotalAmount,0.00)) as TotalAmountProcessed
                            FROM dbo.CloseBatchTransactions
                            WHERE IsPaid = 1 AND cast(CreatedDate as Date) = cast(getdate() as Date);');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.HqYestardayTotalAmount AS
                            SELECT sum(ISNULL(TotalAmount,0.00)) as TotalAmountProcessed
                            FROM dbo.CloseBatchTransactions
                            WHERE IsPaid = 1 AND  cast(CreatedDate as Date) = cast(getdate()-1 as Date);');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.HqWeeklyTotalAmount AS                            
                            SELECT sum(ISNULL(TotalAmount,0.00)) as TotalAmountProcessed
                            FROM dbo.CloseBatchTransactions
                            WHERE IsPaid = 1 AND cast(CreatedDate as Date) >= cast(dateadd(day,1-datepart(dw, getdate()), getdate()) as Date)');");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("exec('drop view dbo.HqDaylyTotalAmount');");

            migrationBuilder.Sql("exec('drop view dbo.HqYestardayTotalAmount');");

            migrationBuilder.Sql("exec('drop view dbo.HqWeeklyTotalAmount');");
        }
    }
}
