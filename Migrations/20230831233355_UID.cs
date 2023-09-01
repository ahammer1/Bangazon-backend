using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BangAzon.Migrations
{
    public partial class UID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 123,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 26, 18, 33, 53, 551, DateTimeKind.Local).AddTicks(5453), new DateTime(2023, 8, 31, 18, 33, 53, 551, DateTimeKind.Local).AddTicks(5499) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 124,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 18, 18, 33, 53, 551, DateTimeKind.Local).AddTicks(5505), new DateTime(2023, 8, 28, 18, 33, 53, 551, DateTimeKind.Local).AddTicks(5508) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 125,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 29, 18, 33, 53, 551, DateTimeKind.Local).AddTicks(5513), new DateTime(2023, 8, 31, 18, 33, 53, 551, DateTimeKind.Local).AddTicks(5516) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 123,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 24, 21, 30, 34, 382, DateTimeKind.Local).AddTicks(3581), new DateTime(2023, 8, 29, 21, 30, 34, 382, DateTimeKind.Local).AddTicks(3618) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 124,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 16, 21, 30, 34, 382, DateTimeKind.Local).AddTicks(3626), new DateTime(2023, 8, 26, 21, 30, 34, 382, DateTimeKind.Local).AddTicks(3627) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 125,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 27, 21, 30, 34, 382, DateTimeKind.Local).AddTicks(3630), new DateTime(2023, 8, 29, 21, 30, 34, 382, DateTimeKind.Local).AddTicks(3632) });
        }
    }
}
