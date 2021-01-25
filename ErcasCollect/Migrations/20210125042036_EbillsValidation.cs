using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class EbillsValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillerEbillsProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    BillerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillerEbillsProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillerEbillsProduct_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillerValidations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    BillerId = table.Column<int>(nullable: true),
                    BillerEbillsProductId = table.Column<int>(nullable: true),
                    ValidationName = table.Column<string>(nullable: true),
                    VaidationStep = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillerValidations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillerValidations_BillerEbillsProduct_BillerEbillsProductId",
                        column: x => x.BillerEbillsProductId,
                        principalTable: "BillerEbillsProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillerValidations_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillerEbillsProduct_BillerId",
                table: "BillerEbillsProduct",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_BillerValidations_BillerEbillsProductId",
                table: "BillerValidations",
                column: "BillerEbillsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BillerValidations_BillerId",
                table: "BillerValidations",
                column: "BillerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillerValidations");

            migrationBuilder.DropTable(
                name: "BillerEbillsProduct");
        }
    }
}
