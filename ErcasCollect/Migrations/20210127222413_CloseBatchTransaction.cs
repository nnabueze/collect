using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class CloseBatchTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosedRemiteId",
                table: "Batchs");

            migrationBuilder.AddColumn<int>(
                name: "CloseBatchTransactionId",
                table: "Batchs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelOneId",
                table: "Batchs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelTwoId",
                table: "Batchs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CloseBatchTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ReferenceKey = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    LevelOneId = table.Column<int>(nullable: true),
                    LevelTwoId = table.Column<int>(nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    BillerId = table.Column<int>(nullable: true),
                    PaymentChannel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloseBatchTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CloseBatchTransactions_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CloseBatchTransactions_LevelOne_LevelOneId",
                        column: x => x.LevelOneId,
                        principalTable: "LevelOne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CloseBatchTransactions_LevelTwo_LevelTwoId",
                        column: x => x.LevelTwoId,
                        principalTable: "LevelTwo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CloseBatchTransactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_CloseBatchTransactionId",
                table: "Batchs",
                column: "CloseBatchTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_LevelOneId",
                table: "Batchs",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_LevelTwoId",
                table: "Batchs",
                column: "LevelTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_CloseBatchTransactions_BillerId",
                table: "CloseBatchTransactions",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_CloseBatchTransactions_LevelOneId",
                table: "CloseBatchTransactions",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_CloseBatchTransactions_LevelTwoId",
                table: "CloseBatchTransactions",
                column: "LevelTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_CloseBatchTransactions_ReferenceKey",
                table: "CloseBatchTransactions",
                column: "ReferenceKey",
                unique: true,
                filter: "[ReferenceKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CloseBatchTransactions_UserId",
                table: "CloseBatchTransactions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_CloseBatchTransactions_CloseBatchTransactionId",
                table: "Batchs",
                column: "CloseBatchTransactionId",
                principalTable: "CloseBatchTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_LevelOne_LevelOneId",
                table: "Batchs",
                column: "LevelOneId",
                principalTable: "LevelOne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_LevelTwo_LevelTwoId",
                table: "Batchs",
                column: "LevelTwoId",
                principalTable: "LevelTwo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_CloseBatchTransactions_CloseBatchTransactionId",
                table: "Batchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_LevelOne_LevelOneId",
                table: "Batchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_LevelTwo_LevelTwoId",
                table: "Batchs");

            migrationBuilder.DropTable(
                name: "CloseBatchTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_CloseBatchTransactionId",
                table: "Batchs");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_LevelOneId",
                table: "Batchs");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_LevelTwoId",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "CloseBatchTransactionId",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "LevelOneId",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "LevelTwoId",
                table: "Batchs");

            migrationBuilder.AddColumn<string>(
                name: "ClosedRemiteId",
                table: "Batchs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
