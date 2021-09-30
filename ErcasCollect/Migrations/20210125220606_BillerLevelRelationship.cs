using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class BillerLevelRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LevelOne_Billers_BillerId",
                table: "LevelOne");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelTwo_Billers_BillerId",
                table: "LevelTwo");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelTwo_LevelOne_LevelOneId",
                table: "LevelTwo");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_LevelOne_LevelOneId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_LevelThree_LevelThreeId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_LevelTwo_LevelTwoId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "LevelThree");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_LevelOneId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_LevelThreeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_LevelTwoId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "LevelOneId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "LevelThreeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "LevelTwoId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "LevelTwo");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "LevelOne");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LevelOneId",
                table: "LevelTwo",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BillerId",
                table: "LevelTwo",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceKey",
                table: "LevelTwo",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BillerId",
                table: "LevelOne",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceKey",
                table: "LevelOne",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LevelDisplayNames",
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
                    LevelId = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelDisplayNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelDisplayNames_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
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
                    IsAmountFixed = table.Column<bool>(nullable: false)
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
                name: "IX_LevelTwo_ReferenceKey",
                table: "LevelTwo",
                column: "ReferenceKey",
                unique: true,
                filter: "[ReferenceKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LevelOne_ReferenceKey",
                table: "LevelOne",
                column: "ReferenceKey",
                unique: true,
                filter: "[ReferenceKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LevelDisplayNames_BillerId",
                table: "LevelDisplayNames",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_BillerId",
                table: "Services",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_LevelOneId",
                table: "Services",
                column: "LevelOneId");

            migrationBuilder.AddForeignKey(
                name: "FK_LevelOne_Billers_BillerId",
                table: "LevelOne",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelTwo_Billers_BillerId",
                table: "LevelTwo",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelTwo_LevelOne_LevelOneId",
                table: "LevelTwo",
                column: "LevelOneId",
                principalTable: "LevelOne",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Services_ServiceId",
                table: "Transactions",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LevelOne_Billers_BillerId",
                table: "LevelOne");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelTwo_Billers_BillerId",
                table: "LevelTwo");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelTwo_LevelOne_LevelOneId",
                table: "LevelTwo");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Services_ServiceId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "LevelDisplayNames");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ServiceId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_LevelTwo_ReferenceKey",
                table: "LevelTwo");

            migrationBuilder.DropIndex(
                name: "IX_LevelOne_ReferenceKey",
                table: "LevelOne");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ReferenceKey",
                table: "LevelTwo");

            migrationBuilder.DropColumn(
                name: "ReferenceKey",
                table: "LevelOne");

            migrationBuilder.AddColumn<int>(
                name: "LevelOneId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelThreeId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelTwoId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LevelOneId",
                table: "LevelTwo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BillerId",
                table: "LevelTwo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "LevelTwo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "BillerId",
                table: "LevelOne",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "LevelOne",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LevelThree",
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
                    LevelTwoId = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelThree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelThree_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LevelThree_LevelOne_LevelOneId",
                        column: x => x.LevelOneId,
                        principalTable: "LevelOne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LevelThree_LevelTwo_LevelTwoId",
                        column: x => x.LevelTwoId,
                        principalTable: "LevelTwo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_LevelOneId",
                table: "Transactions",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_LevelThreeId",
                table: "Transactions",
                column: "LevelThreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_LevelTwoId",
                table: "Transactions",
                column: "LevelTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelThree_BillerId",
                table: "LevelThree",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelThree_LevelOneId",
                table: "LevelThree",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelThree_LevelTwoId",
                table: "LevelThree",
                column: "LevelTwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_LevelOne_Billers_BillerId",
                table: "LevelOne",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelTwo_Billers_BillerId",
                table: "LevelTwo",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelTwo_LevelOne_LevelOneId",
                table: "LevelTwo",
                column: "LevelOneId",
                principalTable: "LevelOne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_LevelOne_LevelOneId",
                table: "Transactions",
                column: "LevelOneId",
                principalTable: "LevelOne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_LevelThree_LevelThreeId",
                table: "Transactions",
                column: "LevelThreeId",
                principalTable: "LevelThree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_LevelTwo_LevelTwoId",
                table: "Transactions",
                column: "LevelTwoId",
                principalTable: "LevelTwo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
