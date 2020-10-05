using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class Updated012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashCollections");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.CreateTable(
                name: "BatchItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SessionID = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    StatusId = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionId = table.Column<string>(nullable: true),
                    PosId = table.Column<string>(nullable: true),
                    PayerName = table.Column<string>(nullable: true),
                    PayerPhone = table.Column<string>(nullable: true),
                    AgentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatchItems_Users_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchItems_Poses_PosId",
                        column: x => x.PosId,
                        principalTable: "Poses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchItems_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Settlements",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    BankId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    BillerId = table.Column<string>(nullable: true),
                    PaymentChannelId = table.Column<int>(nullable: false),
                    TransactionTypeId = table.Column<int>(nullable: false),
                    PaidBy = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    PayerPhone = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    ReferenceID = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settlements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settlements_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Settlements_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Settlements_PaymentChannels_PaymentChannelId",
                        column: x => x.PaymentChannelId,
                        principalTable: "PaymentChannels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Settlements_TransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatchItems_AgentId",
                table: "BatchItems",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchItems_PosId",
                table: "BatchItems",
                column: "PosId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchItems_StatusId",
                table: "BatchItems",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_BankId",
                table: "Settlements",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_BillerId",
                table: "Settlements",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_PaymentChannelId",
                table: "Settlements",
                column: "PaymentChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_TransactionTypeId",
                table: "Settlements",
                column: "TransactionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatchItems");

            migrationBuilder.DropTable(
                name: "Settlements");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    BillerId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidBy = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    PayerPhone = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    PaymentChannelId = table.Column<int>(type: "int", nullable: false),
                    ReferenceID = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_PaymentChannels_PaymentChannelId",
                        column: x => x.PaymentChannelId,
                        principalTable: "PaymentChannels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CashCollections",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    AgentId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Createdby = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayerPhoen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    SessionID = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    StatusId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashCollections_Users_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashCollections_Poses_PosId",
                        column: x => x.PosId,
                        principalTable: "Poses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashCollections_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashCollections_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashCollections_AgentId",
                table: "CashCollections",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_CashCollections_PosId",
                table: "CashCollections",
                column: "PosId");

            migrationBuilder.CreateIndex(
                name: "IX_CashCollections_StatusId",
                table: "CashCollections",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CashCollections_TransactionId",
                table: "CashCollections",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BankId",
                table: "Transactions",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BillerId",
                table: "Transactions",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PaymentChannelId",
                table: "Transactions",
                column: "PaymentChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId");
        }
    }
}
