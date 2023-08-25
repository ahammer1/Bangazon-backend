using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BangAzon.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OrderStatus = table.Column<int>(type: "integer", nullable: false),
                    OrderStatusId = table.Column<int>(type: "integer", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.PaymentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.OrderStatusId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    isSeller = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedDate", "OrderStatus", "OrderStatusId", "PaymentType", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 123, new DateTime(2023, 8, 19, 19, 56, 32, 802, DateTimeKind.Local).AddTicks(9798), 0, 1, "credit Card", new DateTime(2023, 8, 24, 19, 56, 32, 802, DateTimeKind.Local).AddTicks(9844), 1 },
                    { 124, new DateTime(2023, 8, 11, 19, 56, 32, 802, DateTimeKind.Local).AddTicks(9849), 0, 2, "Afterpay", new DateTime(2023, 8, 21, 19, 56, 32, 802, DateTimeKind.Local).AddTicks(9851), 2 },
                    { 125, new DateTime(2023, 8, 22, 19, 56, 32, 802, DateTimeKind.Local).AddTicks(9853), 0, 3, "GiftCard", new DateTime(2023, 8, 24, 19, 56, 32, 802, DateTimeKind.Local).AddTicks(9855), 3 }
                });

            migrationBuilder.InsertData(
                table: "PaymentType",
                columns: new[] { "PaymentTypeId", "Type" },
                values: new object[,]
                {
                    { 1, "Debit Card" },
                    { 2, "Credit Card" },
                    { 3, "Gift Card" },
                    { 4, "AfterPay" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "ProductTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Books" },
                    { 2, "Sports" },
                    { 3, "Video Games" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "Embark on a thrilling journey through uncharted lands.", "Epic Adventure Book", 25.99m, 0 },
                    { 2, "Unveil the secrets of a world filled with magic and wonder.", "Mystical Fantasy Novel", 19.95m, 0 },
                    { 3, "Dive into a virtual universe where anything is possible.", "Virtual Realm Game", 49.99m, 0 },
                    { 4, "Engage in epic battles across distant galaxies.", "Sci-Fi Shooter", 39.99m, 0 },
                    { 5, "High-quality basketball for competitive play.", "Professional Basketball", 29.99m, 0 },
                    { 6, "Practice your skills with this durable training football.", "Training Football", 15.99m, 0 }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "OrderStatusId", "Name" },
                values: new object[,]
                {
                    { 1, "Processing" },
                    { 2, "Completed" },
                    { 3, "Pending" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "Password", "UserName", "isSeller" },
                values: new object[] { 1, "bobiscool@gmail.com", "mommashouse33", "Bob", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
