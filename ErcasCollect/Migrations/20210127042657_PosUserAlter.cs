using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class PosUserAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poses_Users_UserId",
                table: "Poses");

            migrationBuilder.DropIndex(
                name: "IX_Poses_UserId",
                table: "Poses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
