using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashCollections_Users_UserId",
                table: "CashCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_Poses_Branches_BranchId",
                table: "Poses");

            migrationBuilder.DropForeignKey(
                name: "FK_Poses_Departments_DepartmentId",
                table: "Poses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Branches_BranchId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Users_BranchId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DepartmentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_CashCollections_UserId",
                table: "CashCollections");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CashCollections");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Poses",
                newName: "LevelTwoId");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "Poses",
                newName: "LevelOneId");

            migrationBuilder.RenameIndex(
                name: "IX_Poses_DepartmentId",
                table: "Poses",
                newName: "IX_Poses_LevelTwoId");

            migrationBuilder.RenameIndex(
                name: "IX_Poses_BranchId",
                table: "Poses",
                newName: "IX_Poses_LevelOneId");

            migrationBuilder.AddColumn<string>(
                name: "LevelOneId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LevelTwoId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillerId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgentId",
                table: "CashCollections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayerName",
                table: "CashCollections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayerPhoen",
                table: "CashCollections",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LevelOne",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    BillerId = table.Column<string>(nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    StatusId = table.Column<string>(nullable: true),
                    FundsweepPercentage = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelOne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelOne_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LevelOne_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LevelTwo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Departmant = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    BillerId = table.Column<string>(nullable: true),
                    LevelOneId = table.Column<string>(nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    StatusId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelTwo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelTwo_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LevelTwo_LevelOne_LevelOneId",
                        column: x => x.LevelOneId,
                        principalTable: "LevelOne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LevelTwo_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LevelThree",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillerId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    LevelOneId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    LevelTwoId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    IsAmountFixed = table.Column<bool>(nullable: false)
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
                name: "IX_Users_LevelOneId",
                table: "Users",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LevelTwoId",
                table: "Users",
                column: "LevelTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BillerId",
                table: "Transactions",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_CashCollections_AgentId",
                table: "CashCollections",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelOne_BillerId",
                table: "LevelOne",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelOne_StatusId",
                table: "LevelOne",
                column: "StatusId");

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

            migrationBuilder.CreateIndex(
                name: "IX_LevelTwo_BillerId",
                table: "LevelTwo",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelTwo_LevelOneId",
                table: "LevelTwo",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelTwo_StatusId",
                table: "LevelTwo",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashCollections_Users_AgentId",
                table: "CashCollections",
                column: "AgentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Poses_LevelOne_LevelOneId",
                table: "Poses",
                column: "LevelOneId",
                principalTable: "LevelOne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Poses_LevelTwo_LevelTwoId",
                table: "Poses",
                column: "LevelTwoId",
                principalTable: "LevelTwo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Billers_BillerId",
                table: "Transactions",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_LevelOne_LevelOneId",
                table: "Users",
                column: "LevelOneId",
                principalTable: "LevelOne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_LevelTwo_LevelTwoId",
                table: "Users",
                column: "LevelTwoId",
                principalTable: "LevelTwo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashCollections_Users_AgentId",
                table: "CashCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_Poses_LevelOne_LevelOneId",
                table: "Poses");

            migrationBuilder.DropForeignKey(
                name: "FK_Poses_LevelTwo_LevelTwoId",
                table: "Poses");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Billers_BillerId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_LevelOne_LevelOneId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_LevelTwo_LevelTwoId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "LevelThree");

            migrationBuilder.DropTable(
                name: "LevelTwo");

            migrationBuilder.DropTable(
                name: "LevelOne");

            migrationBuilder.DropIndex(
                name: "IX_Users_LevelOneId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LevelTwoId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BillerId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_CashCollections_AgentId",
                table: "CashCollections");

            migrationBuilder.DropColumn(
                name: "LevelOneId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LevelTwoId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BillerId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "CashCollections");

            migrationBuilder.DropColumn(
                name: "PayerName",
                table: "CashCollections");

            migrationBuilder.DropColumn(
                name: "PayerPhoen",
                table: "CashCollections");

            migrationBuilder.RenameColumn(
                name: "LevelTwoId",
                table: "Poses",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "LevelOneId",
                table: "Poses",
                newName: "BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Poses_LevelTwoId",
                table: "Poses",
                newName: "IX_Poses_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Poses_LevelOneId",
                table: "Poses",
                newName: "IX_Poses_BranchId");

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "Users",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentId",
                table: "Users",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CashCollections",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    BillerId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Createdby = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    FundsweepPercentage = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    StatusId = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    BillerId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    BranchId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Createdby = table.Column<int>(type: "int", nullable: false),
                    Departmant = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillerId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    BranchId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Createdby = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    IsAmountFixed = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true)
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
                        name: "FK_Services_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchId",
                table: "Users",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CashCollections_UserId",
                table: "CashCollections",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_BillerId",
                table: "Branches",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_StatusId",
                table: "Branches",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BillerId",
                table: "Departments",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchId",
                table: "Departments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_StatusId",
                table: "Departments",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_BillerId",
                table: "Services",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_BranchId",
                table: "Services",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_DepartmentId",
                table: "Services",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashCollections_Users_UserId",
                table: "CashCollections",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Poses_Branches_BranchId",
                table: "Poses",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Poses_Departments_DepartmentId",
                table: "Poses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Branches_BranchId",
                table: "Users",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
