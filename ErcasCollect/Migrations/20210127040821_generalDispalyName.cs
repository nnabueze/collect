using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class generalDispalyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "LevelDisplayNames");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "LevelDisplayNames");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "LevelDisplayNames");

            migrationBuilder.AddColumn<string>(
                name: "CategoryOneDisplayName",
                table: "LevelDisplayNames",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryTwoDisplayName",
                table: "LevelDisplayNames",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LevelOneDisplayName",
                table: "LevelDisplayNames",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LevelTwoDisplayName",
                table: "LevelDisplayNames",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryOneDisplayName",
                table: "LevelDisplayNames");

            migrationBuilder.DropColumn(
                name: "CategoryTwoDisplayName",
                table: "LevelDisplayNames");

            migrationBuilder.DropColumn(
                name: "LevelOneDisplayName",
                table: "LevelDisplayNames");

            migrationBuilder.DropColumn(
                name: "LevelTwoDisplayName",
                table: "LevelDisplayNames");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "LevelDisplayNames",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "LevelDisplayNames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "LevelDisplayNames",
                type: "int",
                nullable: true);
        }
    }
}
