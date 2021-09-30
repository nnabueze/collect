using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class PosAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poses_Os_OSId",
                table: "Poses");

            migrationBuilder.DropIndex(
                name: "IX_Poses_OSId",
                table: "Poses");

            migrationBuilder.DropColumn(
                name: "OSId",
                table: "Poses");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "Poses");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Poses");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Poses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLogin",
                table: "Poses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceKey",
                table: "Poses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Poses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Poses_UserId",
                table: "Poses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Poses_Users_UserId",
                table: "Poses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poses_Users_UserId",
                table: "Poses");

            migrationBuilder.DropIndex(
                name: "IX_Poses_UserId",
                table: "Poses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Poses");

            migrationBuilder.DropColumn(
                name: "IsLogin",
                table: "Poses");

            migrationBuilder.DropColumn(
                name: "ReferenceKey",
                table: "Poses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Poses");

            migrationBuilder.AddColumn<int>(
                name: "OSId",
                table: "Poses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "Poses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Version",
                table: "Poses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Poses_OSId",
                table: "Poses",
                column: "OSId");

            migrationBuilder.AddForeignKey(
                name: "FK_Poses_Os_OSId",
                table: "Poses",
                column: "OSId",
                principalTable: "Os",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
