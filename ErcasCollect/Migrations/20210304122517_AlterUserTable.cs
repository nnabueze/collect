using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class AlterUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Users_UserId",
                table: "Batchs");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Batchs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 4, 12, 25, 16, 302, DateTimeKind.Utc).AddTicks(937));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 4, 12, 25, 16, 302, DateTimeKind.Utc).AddTicks(2031));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 4, 12, 25, 16, 302, DateTimeKind.Utc).AddTicks(2061));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 4, 12, 25, 16, 302, DateTimeKind.Utc).AddTicks(2063));

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Users_UserId",
                table: "Batchs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Users_UserId",
                table: "Batchs");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Batchs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 1, 12, 49, 51, 199, DateTimeKind.Utc).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 1, 12, 49, 51, 199, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 1, 12, 49, 51, 199, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 1, 12, 49, 51, 199, DateTimeKind.Utc).AddTicks(3742));

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Users_UserId",
                table: "Batchs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
