using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillerId",
                table: "Branches",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Branches",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FundsweepPercentage",
                table: "Branches",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Branches",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Branches",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Branches",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusId",
                table: "Branches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_BillerId",
                table: "Branches",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_StatusId",
                table: "Branches",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Billers_BillerId",
                table: "Branches",
                column: "BillerId",
                principalTable: "Billers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Statuses_StatusId",
                table: "Branches",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Billers_BillerId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Statuses_StatusId",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_BillerId",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_StatusId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "BillerId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "FundsweepPercentage",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Branches");
        }
    }
}
