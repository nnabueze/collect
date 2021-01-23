using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class adjustBillerAndSettlement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billers_State_StateId",
                table: "Billers");

            migrationBuilder.AddColumn<string>(
                name: "TransactionStatus",
                table: "Settlements",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Billers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ReferenceKey",
                table: "Billers",
                type: "nvarchar(32)",
                nullable: true);

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
                name: "FK_Billers_State_StateId",
                table: "Billers");

            migrationBuilder.DropColumn(
                name: "TransactionStatus",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "ReferenceKey",
                table: "Billers");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Billers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Billers_State_StateId",
                table: "Billers",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
