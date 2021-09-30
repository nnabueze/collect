using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class HQreport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.HqBillerTotal AS
                            SELECT COUNT(Id) as TotalBiller
                            FROM dbo.Billers where IsDeleted = 0;');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.HqYearlyTransactionTotal AS
                            SELECT COUNT(Id) as TotalTransaction
                            FROM dbo.Transactions where IsDeleted = 0 AND YEAR(CreatedDate) = YEAR(getdate());');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.HqTotalUser AS
                            SELECT COUNT(Id) as TotalUser
                            FROM dbo.Users where IsDeleted = 0;');");

            migrationBuilder.Sql(@"exec('CREATE VIEW dbo.HqTotalPos AS
                            SELECT COUNT(Id) as TotalPos
                            FROM dbo.Poses where IsDeleted = 0;');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("exec('drop view dbo.HqBillerTotal');");

            migrationBuilder.Sql("exec('drop view dbo.HqYearlyTransactionTotal');");

            migrationBuilder.Sql("exec('drop view dbo.HqTotalUser');");

            migrationBuilder.Sql("exec('drop view dbo.HqTotalPos');");
        }
    }
}
