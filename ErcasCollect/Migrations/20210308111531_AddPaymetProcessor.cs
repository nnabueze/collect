using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class AddPaymetProcessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentProcessorId",
                table: "Batchs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentProcessors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentProcessors", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 11, 15, 30, 57, DateTimeKind.Utc).AddTicks(8309));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 11, 15, 30, 57, DateTimeKind.Utc).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 11, 15, 30, 57, DateTimeKind.Utc).AddTicks(9580));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 11, 15, 30, 57, DateTimeKind.Utc).AddTicks(9582));

            migrationBuilder.InsertData(
                table: "PaymentProcessors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pos" },
                    { 2, "Nibss" },
                    { 3, "Interswitch" },
                    { 4, "Remitta" },
                    { 5, "PayStack" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_PaymentProcessorId",
                table: "Batchs",
                column: "PaymentProcessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_PaymentProcessors_PaymentProcessorId",
                table: "Batchs",
                column: "PaymentProcessorId",
                principalTable: "PaymentProcessors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_PaymentProcessors_PaymentProcessorId",
                table: "Batchs");

            migrationBuilder.DropTable(
                name: "PaymentProcessors");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_PaymentProcessorId",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "PaymentProcessorId",
                table: "Batchs");

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 10, 30, 23, 388, DateTimeKind.Utc).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 10, 30, 23, 388, DateTimeKind.Utc).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 10, 30, 23, 388, DateTimeKind.Utc).AddTicks(7973));

            migrationBuilder.UpdateData(
                table: "EbillsProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 8, 10, 30, 23, 388, DateTimeKind.Utc).AddTicks(7975));
        }
    }
}
