using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class mm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isManaged",
                table: "Batchs");

            migrationBuilder.AddColumn<string>(
                name: "LevelOneId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LevelThreeId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LevelTwoId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillerId",
                table: "Batchs",
                nullable: true);

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
                name: "IX_Batchs_BillerId",
                table: "Batchs",
                column: "BillerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Billers_BillerId",
                table: "Batchs",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Billers_BillerId",
                table: "Batchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_LevelOne_LevelOneId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_LevelThree_LevelThreeId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_LevelTwo_LevelTwoId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_LevelOneId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_LevelThreeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_LevelTwoId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_BillerId",
                table: "Batchs");

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
                name: "BillerId",
                table: "Batchs");

            migrationBuilder.AddColumn<bool>(
                name: "isManaged",
                table: "Batchs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
