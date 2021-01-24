using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class BillerTin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Users_AgentId",
                table: "Batchs");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_AgentId",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Batchs");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Batchs",
                newName: "TotalAmount");

            migrationBuilder.AlterColumn<string>(
                name: "Abbreviation",
                table: "Billers",
                type: "nvarchar(16)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillerTin",
                table: "Billers",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Batchs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_UserId",
                table: "Batchs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Users_UserId",
                table: "Batchs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Users_UserId",
                table: "Batchs");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_UserId",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "BillerTin",
                table: "Billers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Batchs");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Batchs",
                newName: "Amount");

            migrationBuilder.AlterColumn<string>(
                name: "Abbreviation",
                table: "Billers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Batchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_AgentId",
                table: "Batchs",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Users_AgentId",
                table: "Batchs",
                column: "AgentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
