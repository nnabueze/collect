using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class mmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusId",
                table: "Settlements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionID",
                table: "Settlements",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_StatusId",
                table: "Settlements",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Statuses_StatusId",
                table: "Settlements",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Statuses_StatusId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_StatusId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "Settlements");
        }
    }
}
