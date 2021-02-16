using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class HqMonthlyTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.HqAllBillersMonthlyTotalAmount AS
                            SELECT sum(TotalAmount) as TotalAmountProcessed
                            FROM dbo.CloseBatchTransactions
                            WHERE IsPaid = 1 AND MONTH(CreatedDate) = MONTH(getdate());');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.HqMonthlyTransactionTotal AS
                            SELECT COUNT(Id) as TotalTransaction
                            FROM dbo.Transactions where IsDeleted = 0 AND MONTH(CreatedDate) = MONTH(getdate());');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("exec('drop view dbo.HqAllBillersMonthlyTotalAmount');");

            migrationBuilder.Sql("exec('drop view dbo.HqMonthlyTransactionTotal');");
        }
    }
}
