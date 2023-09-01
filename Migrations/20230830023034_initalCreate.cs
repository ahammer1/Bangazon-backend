using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BangAzon.Migrations
{
    public partial class initalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "OrderProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "OrderProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "OrderProductId",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "OrderProductId", "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 1001, 123, 1 },
                    { 1002, 124, 3 },
                    { 1003, 125, 6 }
                });

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

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "uid",
                value: "yca0FmJzbHXwh0rUvsoQSjYWREv1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "OrderProductId",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "OrderProductId",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "OrderProductId",
                keyValue: 1003);

            migrationBuilder.DropColumn(
                name: "uid",
                table: "User");

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "OrderProductId", "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 1, 123, 1 },
                    { 2, 124, 3 },
                    { 3, 125, 6 }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 123,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 21, 11, 44, 36, 754, DateTimeKind.Local).AddTicks(129), new DateTime(2023, 8, 26, 11, 44, 36, 754, DateTimeKind.Local).AddTicks(164) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 124,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 13, 11, 44, 36, 754, DateTimeKind.Local).AddTicks(167), new DateTime(2023, 8, 23, 11, 44, 36, 754, DateTimeKind.Local).AddTicks(169) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 125,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 24, 11, 44, 36, 754, DateTimeKind.Local).AddTicks(171), new DateTime(2023, 8, 26, 11, 44, 36, 754, DateTimeKind.Local).AddTicks(173) });
        }
    }
}
