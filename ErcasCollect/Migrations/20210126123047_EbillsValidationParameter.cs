using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class EbillsValidationParameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillerEbillsProduct_Billers_BillerId",
                table: "BillerEbillsProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BillerValidations_BillerEbillsProduct_BillerEbillsProductId",
                table: "BillerValidations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillerEbillsProduct",
                table: "BillerEbillsProduct");

            migrationBuilder.RenameTable(
                name: "BillerEbillsProduct",
                newName: "BillerEbillsProducts");

            migrationBuilder.RenameIndex(
                name: "IX_BillerEbillsProduct_BillerId",
                table: "BillerEbillsProducts",
                newName: "IX_BillerEbillsProducts_BillerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillerEbillsProducts",
                table: "BillerEbillsProducts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BillerNotifications",
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
                    NotificationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillerNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillerNotifications_BillerEbillsProducts_BillerEbillsProductId",
                        column: x => x.BillerEbillsProductId,
                        principalTable: "BillerEbillsProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillerNotifications_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillerNotifications_BillerEbillsProductId",
                table: "BillerNotifications",
                column: "BillerEbillsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BillerNotifications_BillerId",
                table: "BillerNotifications",
                column: "BillerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillerEbillsProducts_Billers_BillerId",
                table: "BillerEbillsProducts",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillerValidations_BillerEbillsProducts_BillerEbillsProductId",
                table: "BillerValidations",
                column: "BillerEbillsProductId",
                principalTable: "BillerEbillsProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillerEbillsProducts_Billers_BillerId",
                table: "BillerEbillsProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_BillerValidations_BillerEbillsProducts_BillerEbillsProductId",
                table: "BillerValidations");

            migrationBuilder.DropTable(
                name: "BillerNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillerEbillsProducts",
                table: "BillerEbillsProducts");

            migrationBuilder.RenameTable(
                name: "BillerEbillsProducts",
                newName: "BillerEbillsProduct");

            migrationBuilder.RenameIndex(
                name: "IX_BillerEbillsProducts_BillerId",
                table: "BillerEbillsProduct",
                newName: "IX_BillerEbillsProduct_BillerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillerEbillsProduct",
                table: "BillerEbillsProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillerEbillsProduct_Billers_BillerId",
                table: "BillerEbillsProduct",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillerValidations_BillerEbillsProduct_BillerEbillsProductId",
                table: "BillerValidations",
                column: "BillerEbillsProductId",
                principalTable: "BillerEbillsProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
