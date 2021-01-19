using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class ChangedIdToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Users_AgentId",
                table: "Batchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Billers_BillerId",
                table: "Batchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Billers_Statuses_StatusId",
                table: "Billers");

            migrationBuilder.DropForeignKey(
                name: "FK_BillerTinDetails_Billers_BillerId",
                table: "BillerTinDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_FundSweep_Billers_BillerId",
                table: "FundSweep");

            migrationBuilder.DropForeignKey(
                name: "FK_FundSweep_LevelOne_LevelOneId",
                table: "FundSweep");

            migrationBuilder.DropForeignKey(
                name: "FK_FundSweep_LevelTwo_LevelTwoId",
                table: "FundSweep");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelOne_Billers_BillerId",
                table: "LevelOne");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelOne_Statuses_StatusId",
                table: "LevelOne");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelThree_Billers_BillerId",
                table: "LevelThree");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelThree_LevelOne_LevelOneId",
                table: "LevelThree");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelThree_LevelTwo_LevelTwoId",
                table: "LevelThree");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelTwo_Billers_BillerId",
                table: "LevelTwo");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelTwo_LevelOne_LevelOneId",
                table: "LevelTwo");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelTwo_Statuses_StatusId",
                table: "LevelTwo");

            migrationBuilder.DropForeignKey(
                name: "FK_Poses_Billers_BillerId",
                table: "Poses");

            migrationBuilder.DropForeignKey(
                name: "FK_Poses_LevelOne_LevelOneId",
                table: "Poses");

            migrationBuilder.DropForeignKey(
                name: "FK_Poses_LevelTwo_LevelTwoId",
                table: "Poses");

            migrationBuilder.DropForeignKey(
                name: "FK_Poses_Statuses_StatusId",
                table: "Poses");

            migrationBuilder.DropForeignKey(
                name: "FK_Poses_Users_UserId",
                table: "Poses");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Banks_BankId",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Billers_BillerId",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Statuses_StatusId",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxPayers_Billers_BillerId",
                table: "TaxPayers");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxPayers_Statuses_StatusId",
                table: "TaxPayers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_AgentId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Billers_BillerId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_LevelOne_LevelOneId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_LevelThree_LevelThreeId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_LevelTwo_LevelTwoId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Poses_PosId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Statuses_StatusId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionSummaryViews_Billers_BillerId",
                table: "TransactionSummaryViews");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionSummaryViews_LevelOne_LevelOneId",
                table: "TransactionSummaryViews");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionSummaryViews_LevelTwo_LevelTwoId",
                table: "TransactionSummaryViews");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Billers_BillerId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_LevelOne_LevelOneId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_LevelTwo_LevelTwoId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Statuses_StatusId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StatusId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TransactionSummaryViews_BillerId",
                table: "TransactionSummaryViews");

            migrationBuilder.DropIndex(
                name: "IX_TransactionSummaryViews_LevelOneId",
                table: "TransactionSummaryViews");

            migrationBuilder.DropIndex(
                name: "IX_TransactionSummaryViews_LevelTwoId",
                table: "TransactionSummaryViews");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_StatusId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_TaxPayers_StatusId",
                table: "TaxPayers");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_BankId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_StatusId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Poses_StatusId",
                table: "Poses");

            migrationBuilder.DropIndex(
                name: "IX_LevelTwo_BillerId",
                table: "LevelTwo");

            migrationBuilder.DropIndex(
                name: "IX_LevelTwo_LevelOneId",
                table: "LevelTwo");

            migrationBuilder.DropIndex(
                name: "IX_LevelThree_BillerId",
                table: "LevelThree");

            migrationBuilder.DropIndex(
                name: "IX_LevelOne_BillerId",
                table: "LevelOne");

            migrationBuilder.DropIndex(
                name: "IX_FundSweep_BillerId",
                table: "FundSweep");

            migrationBuilder.DropIndex(
                name: "IX_FundSweep_LevelOneId",
                table: "FundSweep");

            migrationBuilder.DropIndex(
                name: "IX_FundSweep_LevelTwoId",
                table: "FundSweep");

            migrationBuilder.DropIndex(
                name: "IX_BillerTinDetails_BillerId",
                table: "BillerTinDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "TaxPayers");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Poses");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Transactions",
                newName: "RemittanceNumber");

            migrationBuilder.RenameColumn(
                name: "TransactionID",
                table: "Settlements",
                newName: "TransactionNumber");

            migrationBuilder.AlterColumn<int>(
                name: "LevelTwoId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LevelOneId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BillerId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LevelTwoId",
                table: "TransactionSummaryViews",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LevelOneId",
                table: "TransactionSummaryViews",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "TransactionSummaryViews",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillerId1",
                table: "TransactionSummaryViews",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelOneId1",
                table: "TransactionSummaryViews",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelTwoId1",
                table: "TransactionSummaryViews",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PosId",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LevelTwoId",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LevelThreeId",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LevelOneId",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BillerId",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BatchId",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TransactionNumber",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "TaxPayers",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TaxPayers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "StatusCode",
                table: "TaxPayers",
                type: "nvarchar(32)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "BillerId",
                table: "Settlements",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BankId",
                table: "Settlements",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Settlements",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "BankId1",
                table: "Settlements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "Settlements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Poses",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LevelTwoId",
                table: "Poses",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LevelOneId",
                table: "Poses",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "Poses",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Poses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "Poses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LevelOneId",
                table: "LevelTwo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "LevelTwo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LevelTwo",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BillerId1",
                table: "LevelTwo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelOneId1",
                table: "LevelTwo",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LevelTwoId",
                table: "LevelThree",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LevelOneId",
                table: "LevelThree",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LevelThree",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BillerId1",
                table: "LevelThree",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "LevelOne",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LevelOne",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BillerId1",
                table: "LevelOne",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LevelTwoId",
                table: "FundSweep",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LevelOneId",
                table: "FundSweep",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "FundSweep",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillerId1",
                table: "FundSweep",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelOneId1",
                table: "FundSweep",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelTwoId1",
                table: "FundSweep",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillerId1",
                table: "BillerTinDetails",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Billers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "BillerId",
                table: "Batchs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "Batchs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Batchs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSummaryViews_BillerId1",
                table: "TransactionSummaryViews",
                column: "BillerId1");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSummaryViews_LevelOneId1",
                table: "TransactionSummaryViews",
                column: "LevelOneId1");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSummaryViews_LevelTwoId1",
                table: "TransactionSummaryViews",
                column: "LevelTwoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_BankId1",
                table: "Settlements",
                column: "BankId1");

            migrationBuilder.CreateIndex(
                name: "IX_LevelTwo_BillerId1",
                table: "LevelTwo",
                column: "BillerId1");

            migrationBuilder.CreateIndex(
                name: "IX_LevelTwo_LevelOneId1",
                table: "LevelTwo",
                column: "LevelOneId1");

            migrationBuilder.CreateIndex(
                name: "IX_LevelThree_BillerId1",
                table: "LevelThree",
                column: "BillerId1");

            migrationBuilder.CreateIndex(
                name: "IX_LevelOne_BillerId1",
                table: "LevelOne",
                column: "BillerId1");

            migrationBuilder.CreateIndex(
                name: "IX_FundSweep_BillerId1",
                table: "FundSweep",
                column: "BillerId1");

            migrationBuilder.CreateIndex(
                name: "IX_FundSweep_LevelOneId1",
                table: "FundSweep",
                column: "LevelOneId1");

            migrationBuilder.CreateIndex(
                name: "IX_FundSweep_LevelTwoId1",
                table: "FundSweep",
                column: "LevelTwoId1");

            migrationBuilder.CreateIndex(
                name: "IX_BillerTinDetails_BillerId1",
                table: "BillerTinDetails",
                column: "BillerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Users_AgentId",
                table: "Batchs",
                column: "AgentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Billers_BillerId",
                table: "Batchs",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Billers_Status_StatusId",
                table: "Billers",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillerTinDetails_Billers_BillerId1",
                table: "BillerTinDetails",
                column: "BillerId1",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundSweep_Billers_BillerId1",
                table: "FundSweep",
                column: "BillerId1",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundSweep_LevelOne_LevelOneId1",
                table: "FundSweep",
                column: "LevelOneId1",
                principalTable: "LevelOne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundSweep_LevelTwo_LevelTwoId1",
                table: "FundSweep",
                column: "LevelTwoId1",
                principalTable: "LevelTwo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelOne_Billers_BillerId1",
                table: "LevelOne",
                column: "BillerId1",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelOne_Status_StatusId",
                table: "LevelOne",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelThree_Billers_BillerId1",
                table: "LevelThree",
                column: "BillerId1",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelThree_LevelOne_LevelOneId",
                table: "LevelThree",
                column: "LevelOneId",
                principalTable: "LevelOne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelThree_LevelTwo_LevelTwoId",
                table: "LevelThree",
                column: "LevelTwoId",
                principalTable: "LevelTwo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelTwo_Billers_BillerId1",
                table: "LevelTwo",
                column: "BillerId1",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelTwo_LevelOne_LevelOneId1",
                table: "LevelTwo",
                column: "LevelOneId1",
                principalTable: "LevelOne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelTwo_Status_StatusId",
                table: "LevelTwo",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Poses_Billers_BillerId",
                table: "Poses",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poses_LevelOne_LevelOneId",
                table: "Poses",
                column: "LevelOneId",
                principalTable: "LevelOne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poses_LevelTwo_LevelTwoId",
                table: "Poses",
                column: "LevelTwoId",
                principalTable: "LevelTwo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poses_Users_UserId",
                table: "Poses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Banks_BankId1",
                table: "Settlements",
                column: "BankId1",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Billers_BillerId",
                table: "Settlements",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxPayers_Billers_BillerId",
                table: "TaxPayers",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_AgentId",
                table: "Transactions",
                column: "AgentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Billers_BillerId",
                table: "Transactions",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_LevelOne_LevelOneId",
                table: "Transactions",
                column: "LevelOneId",
                principalTable: "LevelOne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_LevelThree_LevelThreeId",
                table: "Transactions",
                column: "LevelThreeId",
                principalTable: "LevelThree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_LevelTwo_LevelTwoId",
                table: "Transactions",
                column: "LevelTwoId",
                principalTable: "LevelTwo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Poses_PosId",
                table: "Transactions",
                column: "PosId",
                principalTable: "Poses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionSummaryViews_Billers_BillerId1",
                table: "TransactionSummaryViews",
                column: "BillerId1",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionSummaryViews_LevelOne_LevelOneId1",
                table: "TransactionSummaryViews",
                column: "LevelOneId1",
                principalTable: "LevelOne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionSummaryViews_LevelTwo_LevelTwoId1",
                table: "TransactionSummaryViews",
                column: "LevelTwoId1",
                principalTable: "LevelTwo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Billers_BillerId",
                table: "Users",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_LevelOne_LevelOneId",
                table: "Users",
                column: "LevelOneId",
                principalTable: "LevelOne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_LevelTwo_LevelTwoId",
                table: "Users",
                column: "LevelTwoId",
                principalTable: "LevelTwo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Users_AgentId",
                table: "Batchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Billers_BillerId",
                table: "Batchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Billers_Status_StatusId",
                table: "Billers");

            migrationBuilder.DropForeignKey(
                name: "FK_BillerTinDetails_Billers_BillerId1",
                table: "BillerTinDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_FundSweep_Billers_BillerId1",
                table: "FundSweep");

            migrationBuilder.DropForeignKey(
                name: "FK_FundSweep_LevelOne_LevelOneId1",
                table: "FundSweep");

            migrationBuilder.DropForeignKey(
                name: "FK_FundSweep_LevelTwo_LevelTwoId1",
                table: "FundSweep");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelOne_Billers_BillerId1",
                table: "LevelOne");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelOne_Status_StatusId",
                table: "LevelOne");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelThree_Billers_BillerId1",
                table: "LevelThree");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelThree_LevelOne_LevelOneId",
                table: "LevelThree");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelThree_LevelTwo_LevelTwoId",
                table: "LevelThree");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelTwo_Billers_BillerId1",
                table: "LevelTwo");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelTwo_LevelOne_LevelOneId1",
                table: "LevelTwo");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelTwo_Status_StatusId",
                table: "LevelTwo");

            migrationBuilder.DropForeignKey(
                name: "FK_Poses_Billers_BillerId",
                table: "Poses");

            migrationBuilder.DropForeignKey(
                name: "FK_Poses_LevelOne_LevelOneId",
                table: "Poses");

            migrationBuilder.DropForeignKey(
                name: "FK_Poses_LevelTwo_LevelTwoId",
                table: "Poses");

            migrationBuilder.DropForeignKey(
                name: "FK_Poses_Users_UserId",
                table: "Poses");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Banks_BankId1",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Billers_BillerId",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxPayers_Billers_BillerId",
                table: "TaxPayers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_AgentId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Billers_BillerId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_LevelOne_LevelOneId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_LevelThree_LevelThreeId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_LevelTwo_LevelTwoId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Poses_PosId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionSummaryViews_Billers_BillerId1",
                table: "TransactionSummaryViews");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionSummaryViews_LevelOne_LevelOneId1",
                table: "TransactionSummaryViews");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionSummaryViews_LevelTwo_LevelTwoId1",
                table: "TransactionSummaryViews");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Billers_BillerId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_LevelOne_LevelOneId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_LevelTwo_LevelTwoId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TransactionSummaryViews_BillerId1",
                table: "TransactionSummaryViews");

            migrationBuilder.DropIndex(
                name: "IX_TransactionSummaryViews_LevelOneId1",
                table: "TransactionSummaryViews");

            migrationBuilder.DropIndex(
                name: "IX_TransactionSummaryViews_LevelTwoId1",
                table: "TransactionSummaryViews");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_BankId1",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_LevelTwo_BillerId1",
                table: "LevelTwo");

            migrationBuilder.DropIndex(
                name: "IX_LevelTwo_LevelOneId1",
                table: "LevelTwo");

            migrationBuilder.DropIndex(
                name: "IX_LevelThree_BillerId1",
                table: "LevelThree");

            migrationBuilder.DropIndex(
                name: "IX_LevelOne_BillerId1",
                table: "LevelOne");

            migrationBuilder.DropIndex(
                name: "IX_FundSweep_BillerId1",
                table: "FundSweep");

            migrationBuilder.DropIndex(
                name: "IX_FundSweep_LevelOneId1",
                table: "FundSweep");

            migrationBuilder.DropIndex(
                name: "IX_FundSweep_LevelTwoId1",
                table: "FundSweep");

            migrationBuilder.DropIndex(
                name: "IX_BillerTinDetails_BillerId1",
                table: "BillerTinDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BillerId1",
                table: "TransactionSummaryViews");

            migrationBuilder.DropColumn(
                name: "LevelOneId1",
                table: "TransactionSummaryViews");

            migrationBuilder.DropColumn(
                name: "LevelTwoId1",
                table: "TransactionSummaryViews");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionNumber",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "TaxPayers");

            migrationBuilder.DropColumn(
                name: "BankId1",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "Poses");

            migrationBuilder.DropColumn(
                name: "BillerId1",
                table: "LevelTwo");

            migrationBuilder.DropColumn(
                name: "LevelOneId1",
                table: "LevelTwo");

            migrationBuilder.DropColumn(
                name: "BillerId1",
                table: "LevelThree");

            migrationBuilder.DropColumn(
                name: "BillerId1",
                table: "LevelOne");

            migrationBuilder.DropColumn(
                name: "BillerId1",
                table: "FundSweep");

            migrationBuilder.DropColumn(
                name: "LevelOneId1",
                table: "FundSweep");

            migrationBuilder.DropColumn(
                name: "LevelTwoId1",
                table: "FundSweep");

            migrationBuilder.DropColumn(
                name: "BillerId1",
                table: "BillerTinDetails");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "Statuses");

            migrationBuilder.RenameColumn(
                name: "RemittanceNumber",
                table: "Transactions",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "TransactionNumber",
                table: "Settlements",
                newName: "TransactionID");

            migrationBuilder.AlterColumn<string>(
                name: "LevelTwoId",
                table: "Users",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "LevelOneId",
                table: "Users",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "Users",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "StatusId",
                table: "Users",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LevelTwoId",
                table: "TransactionSummaryViews",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LevelOneId",
                table: "TransactionSummaryViews",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "TransactionSummaryViews",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PosId",
                table: "Transactions",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "LevelTwoId",
                table: "Transactions",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "LevelThreeId",
                table: "Transactions",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "LevelOneId",
                table: "Transactions",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "Transactions",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "BatchId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "Transactions",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Transactions",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "TransactionId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "TaxPayers",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TaxPayers",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "StatusId",
                table: "TaxPayers",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "Settlements",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "BankId",
                table: "Settlements",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Settlements",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "StatusId",
                table: "Settlements",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Poses",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "LevelTwoId",
                table: "Poses",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "LevelOneId",
                table: "Poses",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "Poses",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Poses",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "StatusId",
                table: "Poses",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LevelOneId",
                table: "LevelTwo",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "LevelTwo",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "LevelTwo",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "LevelTwoId",
                table: "LevelThree",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "LevelOneId",
                table: "LevelThree",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "LevelThree",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "LevelOne",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "LevelOne",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "LevelTwoId",
                table: "FundSweep",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LevelOneId",
                table: "FundSweep",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "FundSweep",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Billers",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "BillerId",
                table: "Batchs",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "Batchs",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Batchs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusId",
                table: "Users",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSummaryViews_BillerId",
                table: "TransactionSummaryViews",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSummaryViews_LevelOneId",
                table: "TransactionSummaryViews",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSummaryViews_LevelTwoId",
                table: "TransactionSummaryViews",
                column: "LevelTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StatusId",
                table: "Transactions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxPayers_StatusId",
                table: "TaxPayers",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_BankId",
                table: "Settlements",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_StatusId",
                table: "Settlements",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Poses_StatusId",
                table: "Poses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelTwo_BillerId",
                table: "LevelTwo",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelTwo_LevelOneId",
                table: "LevelTwo",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelThree_BillerId",
                table: "LevelThree",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelOne_BillerId",
                table: "LevelOne",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_FundSweep_BillerId",
                table: "FundSweep",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_FundSweep_LevelOneId",
                table: "FundSweep",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_FundSweep_LevelTwoId",
                table: "FundSweep",
                column: "LevelTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_BillerTinDetails_BillerId",
                table: "BillerTinDetails",
                column: "BillerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Users_AgentId",
                table: "Batchs",
                column: "AgentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Billers_BillerId",
                table: "Batchs",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Billers_Statuses_StatusId",
                table: "Billers",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillerTinDetails_Billers_BillerId",
                table: "BillerTinDetails",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundSweep_Billers_BillerId",
                table: "FundSweep",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundSweep_LevelOne_LevelOneId",
                table: "FundSweep",
                column: "LevelOneId",
                principalTable: "LevelOne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundSweep_LevelTwo_LevelTwoId",
                table: "FundSweep",
                column: "LevelTwoId",
                principalTable: "LevelTwo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelOne_Billers_BillerId",
                table: "LevelOne",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelOne_Statuses_StatusId",
                table: "LevelOne",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelThree_Billers_BillerId",
                table: "LevelThree",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelThree_LevelOne_LevelOneId",
                table: "LevelThree",
                column: "LevelOneId",
                principalTable: "LevelOne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelThree_LevelTwo_LevelTwoId",
                table: "LevelThree",
                column: "LevelTwoId",
                principalTable: "LevelTwo",
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
                name: "FK_LevelTwo_Statuses_StatusId",
                table: "LevelTwo",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Poses_Billers_BillerId",
                table: "Poses",
                column: "BillerId",
                principalTable: "Billers",
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
                name: "FK_Poses_Statuses_StatusId",
                table: "Poses",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Poses_Users_UserId",
                table: "Poses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Banks_BankId",
                table: "Settlements",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Billers_BillerId",
                table: "Settlements",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Statuses_StatusId",
                table: "Settlements",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxPayers_Billers_BillerId",
                table: "TaxPayers",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxPayers_Statuses_StatusId",
                table: "TaxPayers",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_AgentId",
                table: "Transactions",
                column: "AgentId",
                principalTable: "Users",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Poses_PosId",
                table: "Transactions",
                column: "PosId",
                principalTable: "Poses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Statuses_StatusId",
                table: "Transactions",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionSummaryViews_Billers_BillerId",
                table: "TransactionSummaryViews",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionSummaryViews_LevelOne_LevelOneId",
                table: "TransactionSummaryViews",
                column: "LevelOneId",
                principalTable: "LevelOne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionSummaryViews_LevelTwo_LevelTwoId",
                table: "TransactionSummaryViews",
                column: "LevelTwoId",
                principalTable: "LevelTwo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Billers_BillerId",
                table: "Users",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Statuses_StatusId",
                table: "Users",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
