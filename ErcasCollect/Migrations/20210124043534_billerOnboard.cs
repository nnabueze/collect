using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class billerOnboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GatewayKeyVector",
                table: "Billers",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GatewaySecretKey",
                table: "Billers",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GatewayUsername",
                table: "Billers",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsGatewayOnbaord",
                table: "Billers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GatewayKeyVector",
                table: "Billers");

            migrationBuilder.DropColumn(
                name: "GatewaySecretKey",
                table: "Billers");

            migrationBuilder.DropColumn(
                name: "GatewayUsername",
                table: "Billers");

            migrationBuilder.DropColumn(
                name: "IsGatewayOnbaord",
                table: "Billers");
        }
    }
}
