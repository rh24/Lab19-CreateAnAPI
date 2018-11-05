using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab19_CreateAnApi.Migrations
{
    public partial class UpdateSeedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2018, 11, 4, 22, 35, 38, 623, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "ID",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2018, 11, 4, 22, 35, 38, 623, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "ID",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2018, 11, 4, 22, 35, 38, 623, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2018, 11, 4, 22, 30, 8, 76, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "ID",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2018, 11, 4, 22, 30, 8, 76, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "ID",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2018, 11, 4, 22, 30, 8, 76, DateTimeKind.Local));
        }
    }
}
