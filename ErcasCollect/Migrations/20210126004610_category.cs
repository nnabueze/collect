using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Services_ServiceId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ServiceId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "CategoryTwoServiceId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LevelId",
                table: "LevelDisplayNames",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "LevelDisplayNames",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryOneServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ReferenceKey = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    BillerId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LevelOneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryOneServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryOneServices_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryOneServices_LevelOne_LevelOneId",
                        column: x => x.LevelOneId,
                        principalTable: "LevelOne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTwoServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ReferenceKey = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillerId = table.Column<int>(nullable: true),
                    LevelOneId = table.Column<int>(nullable: true),
                    CategoryOneServiceId = table.Column<int>(nullable: true),
                    IsAmountFixed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTwoServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTwoServices_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryTwoServices_CategoryOneServices_CategoryOneServiceId",
                        column: x => x.CategoryOneServiceId,
                        principalTable: "CategoryOneServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryTwoServices_LevelOne_LevelOneId",
                        column: x => x.LevelOneId,
                        principalTable: "LevelOne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryTwoServiceId",
                table: "Transactions",
                column: "CategoryTwoServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryOneServices_BillerId",
                table: "CategoryOneServices",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryOneServices_LevelOneId",
                table: "CategoryOneServices",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTwoServices_BillerId",
                table: "CategoryTwoServices",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTwoServices_CategoryOneServiceId",
                table: "CategoryTwoServices",
                column: "CategoryOneServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTwoServices_LevelOneId",
                table: "CategoryTwoServices",
                column: "LevelOneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_CategoryTwoServices_CategoryTwoServiceId",
                table: "Transactions",
                column: "CategoryTwoServiceId",
                principalTable: "CategoryTwoServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_CategoryTwoServices_CategoryTwoServiceId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "CategoryTwoServices");

            migrationBuilder.DropTable(
                name: "CategoryOneServices");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CategoryTwoServiceId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CategoryTwoServiceId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "LevelDisplayNames");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LevelId",
                table: "LevelDisplayNames",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillerId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Createdby = table.Column<int>(type: "int", nullable: false),
                    IsAmountFixed = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LevelOneId = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    ReferenceKey = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_LevelOne_LevelOneId",
                        column: x => x.LevelOneId,
                        principalTable: "LevelOne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ServiceId",
                table: "Transactions",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_BillerId",
                table: "Services",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_LevelOneId",
                table: "Services",
                column: "LevelOneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Services_ServiceId",
                table: "Transactions",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
