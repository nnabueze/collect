using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class AlterSettlement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bank",
                table: "Settlements");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "Settlements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DestinationBank",
                table: "Settlements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceBank",
                table: "Settlements",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "DestinationBank",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "SourceBank",
                table: "Settlements");

            migrationBuilder.AddColumn<string>(
                name: "Bank",
                table: "Settlements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 30, 12, 18, 7, 852, DateTimeKind.Utc).AddTicks(6782));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 30, 12, 18, 7, 855, DateTimeKind.Utc).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 30, 12, 18, 7, 855, DateTimeKind.Utc).AddTicks(492));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 30, 12, 18, 7, 855, DateTimeKind.Utc).AddTicks(497));
        }
    }
}
