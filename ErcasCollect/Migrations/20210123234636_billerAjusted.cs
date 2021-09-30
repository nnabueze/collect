using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class billerAjusted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillerType",
                table: "Billers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Billers");

            migrationBuilder.AddColumn<int>(
                name: "BillerTypeId",
                table: "Billers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Billers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusCode",
                table: "Billers",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billers_BillerTypes_BillerTypeId",
                table: "Billers");

            migrationBuilder.DropForeignKey(
                name: "FK_Billers_State_StateId",
                table: "Billers");

            migrationBuilder.DropIndex(
                name: "IX_Billers_BillerTypeId",
                table: "Billers");

            migrationBuilder.DropIndex(
                name: "IX_Billers_StateId",
                table: "Billers");

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
                name: "BillerType",
                table: "Billers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Billers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
