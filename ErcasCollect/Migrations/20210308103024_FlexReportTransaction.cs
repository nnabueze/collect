using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class FlexReportTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.MonthlyFlexTransactionCount AS
                            SELECT COUNT(Id) as TotalTransaction
                            FROM dbo.Batchs
                            WHERE PaymentChannelId = 3 AND MONTH(CreatedDate) = MONTH(getdate());');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.MonthlyFlexSuccessCount AS
                            SELECT COUNT(Id) as TotalTransaction
                            FROM dbo.Batchs
                            WHERE IsSuccess = 1 AND PaymentChannelId = 3 AND MONTH(CreatedDate) = MONTH(getdate());');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.MonthlyFlexFailedCount AS
                            SELECT COUNT(Id) as TotalTransaction
                            FROM dbo.Batchs
                            WHERE IsSuccess = 0 AND PaymentChannelId = 3 AND MONTH(CreatedDate) = MONTH(getdate());');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.MonthlyFlexTotalAmount AS
                            SELECT ISNULL(sum(TotalAmount), 0.00) as TotalAmountProcessed
                            FROM dbo.Batchs
                            WHERE IsSuccess = 1 AND PaymentChannelId = 3 AND MONTH(CreatedDate) = MONTH(getdate());');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("exec('drop view dbo.MonthlyFlexTransactionCount');");

            migrationBuilder.Sql("exec('drop view dbo.MonthlyFlexSuccessCount');");

            migrationBuilder.Sql("exec('drop view dbo.MonthlyFlexFailedCount');");

            migrationBuilder.Sql("exec('drop view dbo.MonthlyFlexTotalAmount');");
        }
    }
}
