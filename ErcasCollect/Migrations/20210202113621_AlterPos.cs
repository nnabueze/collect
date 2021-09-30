using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class AlterPos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Activationpin",
                table: "Poses",
                newName: "ActivationPin");

            migrationBuilder.AlterColumn<string>(
                name: "PosImei",
                table: "Poses",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ActivationPin",
                table: "Poses",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 2, 11, 36, 21, 38, DateTimeKind.Utc).AddTicks(2823));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 2, 11, 36, 21, 38, DateTimeKind.Utc).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 2, 11, 36, 21, 38, DateTimeKind.Utc).AddTicks(5239));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 2, 11, 36, 21, 38, DateTimeKind.Utc).AddTicks(5250));

            migrationBuilder.CreateIndex(
                name: "IX_Poses_ActivationPin",
                table: "Poses",
                column: "ActivationPin",
                unique: true,
                filter: "[ActivationPin] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Poses_PosImei",
                table: "Poses",
                column: "PosImei",
                unique: true,
                filter: "[PosImei] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Poses_ActivationPin",
                table: "Poses");

            migrationBuilder.DropIndex(
                name: "IX_Poses_PosImei",
                table: "Poses");

            migrationBuilder.RenameColumn(
                name: "ActivationPin",
                table: "Poses",
                newName: "Activationpin");

            migrationBuilder.AlterColumn<string>(
                name: "PosImei",
                table: "Poses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Activationpin",
                table: "Poses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 2, 3, 18, 4, 534, DateTimeKind.Utc).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 2, 3, 18, 4, 534, DateTimeKind.Utc).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 2, 3, 18, 4, 534, DateTimeKind.Utc).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 2, 2, 3, 18, 4, 534, DateTimeKind.Utc).AddTicks(8052));
        }
    }
}
