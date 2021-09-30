using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class EbillsProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EbillsProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ProductName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EbillsProducts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EbillsProducts",
                columns: new[] { "Id", "CreatedDate", "Createdby", "IsDeleted", "ModifiedBy", "ModifiedDate", "ProductName" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 30, 9, 26, 11, 896, DateTimeKind.Utc).AddTicks(1253), 0, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Remittance" },
                    { 2, new DateTime(2021, 1, 30, 9, 26, 11, 896, DateTimeKind.Utc).AddTicks(2781), 0, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax" },
                    { 3, new DateTime(2021, 1, 30, 9, 26, 11, 896, DateTimeKind.Utc).AddTicks(2827), 0, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-Tax" },
                    { 4, new DateTime(2021, 1, 30, 9, 26, 11, 896, DateTimeKind.Utc).AddTicks(2831), 0, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Invoice" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EbillsProducts");
        }
    }
}
