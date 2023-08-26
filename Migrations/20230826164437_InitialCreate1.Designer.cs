﻿// <auto-generated />
using System;
using BangAzon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BangAzon.Migrations
{
    [DbContext(typeof(BangazonDbContext))]
    [Migration("20230826164437_InitialCreate1")]
    partial class InitialCreate1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BangAzon.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("integer");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("integer");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 123,
                            CreatedDate = new DateTime(2023, 8, 21, 11, 44, 36, 754, DateTimeKind.Local).AddTicks(129),
                            OrderStatus = 0,
                            OrderStatusId = 1,
                            PaymentType = "credit Card",
                            UpdatedDate = new DateTime(2023, 8, 26, 11, 44, 36, 754, DateTimeKind.Local).AddTicks(164),
                            UserId = 1
                        },
                        new
                        {
                            OrderId = 124,
                            CreatedDate = new DateTime(2023, 8, 13, 11, 44, 36, 754, DateTimeKind.Local).AddTicks(167),
                            OrderStatus = 0,
                            OrderStatusId = 2,
                            PaymentType = "Afterpay",
                            UpdatedDate = new DateTime(2023, 8, 23, 11, 44, 36, 754, DateTimeKind.Local).AddTicks(169),
                            UserId = 2
                        },
                        new
                        {
                            OrderId = 125,
                            CreatedDate = new DateTime(2023, 8, 24, 11, 44, 36, 754, DateTimeKind.Local).AddTicks(171),
                            OrderStatus = 0,
                            OrderStatusId = 3,
                            PaymentType = "GiftCard",
                            UpdatedDate = new DateTime(2023, 8, 26, 11, 44, 36, 754, DateTimeKind.Local).AddTicks(173),
                            UserId = 3
                        });
                });

            modelBuilder.Entity("BangAzon.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderProductId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("OrderProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");

                    b.HasData(
                        new
                        {
                            OrderProductId = 1,
                            OrderId = 123,
                            ProductId = 1
                        },
                        new
                        {
                            OrderProductId = 2,
                            OrderId = 124,
                            ProductId = 3
                        },
                        new
                        {
                            OrderProductId = 3,
                            OrderId = 125,
                            ProductId = 6
                        });
                });

            modelBuilder.Entity("BangAzon.Models.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderStatusId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OrderStatusId");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            OrderStatusId = 1,
                            Name = "Processing"
                        },
                        new
                        {
                            OrderStatusId = 2,
                            Name = "Completed"
                        },
                        new
                        {
                            OrderStatusId = 3,
                            Name = "Pending"
                        });
                });

            modelBuilder.Entity("BangAzon.Models.PaymentType", b =>
                {
                    b.Property<int>("PaymentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PaymentTypeId"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PaymentTypeId");

                    b.ToTable("PaymentType");

                    b.HasData(
                        new
                        {
                            PaymentTypeId = 1,
                            Type = "Debit Card"
                        },
                        new
                        {
                            PaymentTypeId = 2,
                            Type = "Credit Card"
                        },
                        new
                        {
                            PaymentTypeId = 3,
                            Type = "Gift Card"
                        },
                        new
                        {
                            PaymentTypeId = 4,
                            Type = "AfterPay"
                        });
                });

            modelBuilder.Entity("BangAzon.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("integer");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "Embark on a thrilling journey through uncharted lands.",
                            Name = "Epic Adventure Book",
                            Price = 25.99m,
                            StockQuantity = 0
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "Unveil the secrets of a world filled with magic and wonder.",
                            Name = "Mystical Fantasy Novel",
                            Price = 19.95m,
                            StockQuantity = 0
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "Dive into a virtual universe where anything is possible.",
                            Name = "Virtual Realm Game",
                            Price = 49.99m,
                            StockQuantity = 0
                        },
                        new
                        {
                            ProductId = 4,
                            Description = "Engage in epic battles across distant galaxies.",
                            Name = "Sci-Fi Shooter",
                            Price = 39.99m,
                            StockQuantity = 0
                        },
                        new
                        {
                            ProductId = 5,
                            Description = "High-quality basketball for competitive play.",
                            Name = "Professional Basketball",
                            Price = 29.99m,
                            StockQuantity = 0
                        },
                        new
                        {
                            ProductId = 6,
                            Description = "Practice your skills with this durable training football.",
                            Name = "Training Football",
                            Price = 15.99m,
                            StockQuantity = 0
                        });
                });

            modelBuilder.Entity("BangAzon.Models.ProductType", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProductTypeId");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            ProductTypeId = 1,
                            Name = "Books"
                        },
                        new
                        {
                            ProductTypeId = 2,
                            Name = "Sports"
                        },
                        new
                        {
                            ProductTypeId = 3,
                            Name = "Video Games"
                        });
                });

            modelBuilder.Entity("BangAzon.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isSeller")
                        .HasColumnType("boolean");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "bobiscool@gmail.com",
                            Password = "mommashouse33",
                            UserName = "Bob",
                            isSeller = false
                        });
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrdersOrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductsProductId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersOrderId", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("BangAzon.Models.OrderProduct", b =>
                {
                    b.HasOne("BangAzon.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BangAzon.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("BangAzon.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BangAzon.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
