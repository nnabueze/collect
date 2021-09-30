using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class adjustBillerAndSettlement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billers_BillerTypes_BillerTypeId",
                table: "Billers");

            migrationBuilder.DropForeignKey(
                name: "FK_Billers_State_StateId",
                table: "Billers");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Banks_BankId",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_PaymentChannels_PaymentChannelId",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_TransactionTypes_TransactionTypeId",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_PaymentChannels_PaymentChannelId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_PaymentChannelId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_BankId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_PaymentChannelId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_TransactionTypeId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Billers_BillerTypeId",
                table: "Billers");

            migrationBuilder.DropIndex(
                name: "IX_Billers_StateId",
                table: "Billers");

            migrationBuilder.DropColumn(
                name: "PaymentChannelId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionTypeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "PaymentChannelId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "TransactionTypeId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "BillerTypeId",
                table: "Billers");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Billers");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "Billers");

            migrationBuilder.AddColumn<int>(
                name: "PaymentChannel",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Bank",
                table: "Settlements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentChannel",
                table: "Settlements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TransactionStatus",
                table: "Settlements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "Settlements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BillerType",
                table: "Billers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceKey",
                table: "Billers",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Billers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Billers_ReferenceKey",
                table: "Billers",
                column: "ReferenceKey",
                unique: true,
                filter: "[ReferenceKey] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Billers_ReferenceKey",
                table: "Billers");

            migrationBuilder.DropColumn(
                name: "PaymentChannel",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Bank",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "PaymentChannel",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "TransactionStatus",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "BillerType",
                table: "Billers");

            migrationBuilder.DropColumn(
                name: "ReferenceKey",
                table: "Billers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Billers");

            migrationBuilder.AddColumn<int>(
                name: "PaymentChannelId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionTypeId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "Settlements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentChannelId",
                table: "Settlements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionTypeId",
                table: "Settlements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillerTypeId",
                table: "Billers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Billers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StatusCode",
                table: "Billers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PaymentChannelId",
                table: "Transactions",
                column: "PaymentChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_BankId",
                table: "Settlements",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_PaymentChannelId",
                table: "Settlements",
                column: "PaymentChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_TransactionTypeId",
                table: "Settlements",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Billers_BillerTypeId",
                table: "Billers",
                column: "BillerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Billers_StateId",
                table: "Billers",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billers_BillerTypes_BillerTypeId",
                table: "Billers",
                column: "BillerTypeId",
                principalTable: "BillerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Billers_State_StateId",
                table: "Billers",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Banks_BankId",
                table: "Settlements",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_PaymentChannels_PaymentChannelId",
                table: "Settlements",
                column: "PaymentChannelId",
                principalTable: "PaymentChannels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_TransactionTypes_TransactionTypeId",
                table: "Settlements",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_PaymentChannels_PaymentChannelId",
                table: "Transactions",
                column: "PaymentChannelId",
                principalTable: "PaymentChannels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
