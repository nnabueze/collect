using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatustId",
                table: "TaxPayers");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPaidDate",
                table: "TaxPayers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "StatusId",
                table: "Poses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Poses_StatusId",
                table: "Poses",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Poses_Statuses_StatusId",
                table: "Poses",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poses_Statuses_StatusId",
                table: "Poses");

            migrationBuilder.DropIndex(
                name: "IX_Poses_StatusId",
                table: "Poses");

            migrationBuilder.DropColumn(
                name: "LastPaidDate",
                table: "TaxPayers");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Poses");

            migrationBuilder.AddColumn<string>(
                name: "StatustId",
                table: "TaxPayers",
                type: "nvarchar(32)",
                nullable: true);
        }
    }
}
