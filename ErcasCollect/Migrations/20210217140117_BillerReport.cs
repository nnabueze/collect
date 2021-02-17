using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class BillerReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.BillerMonthlyTotalTransactions AS
                            Select b.Name as BillerName, b.Id as BillerId, SUM(ISNULL(c.ItemCount, 0)) as TotalTransaction
                            From dbo.Billers b
                            LEFT JOIN dbo.Batchs c ON
                            b.Id = c.BillerId AND Month(c.CreatedDate) = Month(getdate())
                            GROUP BY b.Id, b.Name;');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.BillerTotalUser AS
                            Select b.Name as BillerName, b.Id as BillerId, COUNT(c.Id) as TotalUser
                            From dbo.Billers b
                            LEFT JOIN dbo.Users c ON
                            b.Id = c.BillerId
                            GROUP BY b.Id, b.Name;');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.BillerTotalCashAtHand AS
                            Select b.Name as BillerName, b.Id as BillerId, SUM(ISNULL(c.TotalAmount,0.00)) as TotalAmount
                            From dbo.Billers b
                            LEFT JOIN dbo.Batchs c ON
                            b.Id = c.BillerId AND c.IsBatchClosed = 0 AND Month(c.CreatedDate) = Month(getdate())
                            GROUP BY b.Id, b.Name;');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.BillerTodayTotalAmountProcessed AS
                            Select b.Name as BillerName, b.Id as BillerId, SUM(ISNULL(c.TotalAmount,0.00)) as TotalAmount
                            From dbo.Billers b
                            LEFT JOIN dbo.CloseBatchTransactions c ON
                            b.Id = c.BillerId AND c.IsPaid = 1 AND cast(c.CreatedDate as Date) = cast(getdate() as Date)
                            GROUP BY b.Id, b.Name;');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.BillerYesterdayTotalAmountProcessed AS
                            Select b.Name as BillerName, b.Id as BillerId, SUM(ISNULL(c.TotalAmount,0.00)) as TotalAmount
                            From dbo.Billers b
                            LEFT JOIN dbo.CloseBatchTransactions c ON
                            b.Id = c.BillerId AND c.IsPaid = 1 AND cast(c.CreatedDate as Date) = cast(getdate()-1 as Date)
                            GROUP BY b.Id, b.Name;');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.BillerWeeklyTotalAmountProcessed AS
                            Select b.Name as BillerName, b.Id as BillerId, SUM(ISNULL(c.TotalAmount,0.00)) as TotalAmount
                            From dbo.Billers b
                            LEFT JOIN dbo.CloseBatchTransactions c ON
                            b.Id = c.BillerId AND c.IsPaid = 1 AND cast(c.CreatedDate as Date) >= cast(dateadd(day,1-datepart(dw, getdate()), getdate()) as Date)
                            GROUP BY b.Id, b.Name;');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.BillerTopPerformingLevelOne AS
                            Select b.Id as BillerId, ISNULL(x.Id,0) as LevelOneId,  SUM(ISNULL(c.TotalAmount,0.00)) as TotalAmount
                            From dbo.Billers b
							LEFT JOIN dbo.LevelOne x
							ON b.Id = x.BillerId
                            LEFT JOIN dbo.CloseBatchTransactions c ON
                            x.Id = c.LevelOneId AND c.IsPaid = 1 AND Month(c.CreatedDate) = Month(getdate())
                            GROUP BY b.Id, b.Name, x.Id;');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.BillerAgentCashAtHand AS
                            Select b.Id as BillerId, ISNULL(u.Id,0) as UserId, SUM(ISNULL(c.TotalAmount,0.00)) as TotalCashAtHand
                            From dbo.Billers b
							LEFT JOIN dbo.Users u
							ON b.Id = u.BillerId
                            LEFT JOIN dbo.Batchs c ON
                            u.Id = c.UserId AND c.IsBatchClosed = 0 AND Month(c.CreatedDate) = Month(getdate())
                            GROUP BY b.Id, b.Name, u.Id;');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("exec('drop view dbo.BillerMonthlyTotalTransactions');");

            migrationBuilder.Sql("exec('drop view dbo.BillerTotalUser');");

            migrationBuilder.Sql("exec('drop view dbo.BillerTotalCashAtHand');");

            migrationBuilder.Sql("exec('drop view dbo.BillerTodayTotalAmountProcessed');");

            migrationBuilder.Sql("exec('drop view dbo.BillerYesterdayTotalAmountProcessed');");

            migrationBuilder.Sql("exec('drop view dbo.BillerWeeklyTotalAmountProcessed');");

            migrationBuilder.Sql("exec('drop view dbo.BillerTopPerformingLevelOne');");

            migrationBuilder.Sql("exec('drop view dbo.BillerAgentCashAtHand');");
        }
    }
}
