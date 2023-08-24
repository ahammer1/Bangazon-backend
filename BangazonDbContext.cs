using Microsoft.EntityFrameworkCore;
using BangAzon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;

namespace BangAzon
{
    public class BangazonDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> Status { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User[]
            {
            new User { UserId = 1, UserName = "Bob", Email = "bobiscool@gmail.com", Password = "mommashouse33" isSeller = false},
            });

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
          
        new Product { ProductId = 1, Name = "Epic Adventure Book", Description = "Embark on a thrilling journey through uncharted lands.", Price = 25.99M, ProductTypeId = 1 },
        new Product { ProductId = 2, Name = "Mystical Fantasy Novel", Description = "Unveil the secrets of a world filled with magic and wonder.", Price = 19.95M, ProductTypeId = 1 },
        new Product { ProductId = 3, Name = "Virtual Realm Game", Description = "Dive into a virtual universe where anything is possible.", Price = 49.99M, ProductTypeId = 2 },
        new Product { ProductId = 4, Name = "Sci-Fi Shooter", Description = "Engage in epic battles across distant galaxies.", Price = 39.99M, ProductTypeId = 2 },
        new Product { ProductId = 5, Name = "Professional Basketball", Description = "High-quality basketball for competitive play.", Price = 29.99M, ProductTypeId = 3 },
        new Product { ProductId = 6, Name = "Training Football", Description = "Practice your skills with this durable training football.", Price = 15.99M, ProductTypeId = 3 }
            });


            modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
            {
            new PaymentType { PaymentTypeId = 1, Type = "Debit Card"},
            new PaymentType { PaymentTypeId = 2, Type = "Credit Card"},
            new PaymentType { PaymentTypeId = 3, Type = "Gift Card"},
            new PaymentType { PaymentTypeId = 4, Type = "AfterPay"}
            });

            modelBuilder.Entity<Order>().HasData(new Order[]
            {
            new Order {  OrderId = 123, UserId = "user_id_here", CreatedDate = DateTime.Now.AddDays(-5), UpdatedDate = DateTime.Now, OrderStatus = OrderStatus.Processing, OrderStatusId = 1,  PaymentType = PaymentType.CreditCard, },
            new Order {  OrderId = 124, UserId = "user_id_2", CreatedDate = DateTime.Now.AddDays(-10), UpdatedDate = DateTime.Now.AddDays(-3), OrderStatus = OrderStatus.Completed, OrderStatusId = 2,  PaymentType = PaymentType.AfterPal,},
            new Order {  OrderId = 125, UserId = "user_id_3", CreatedDate = DateTime.Now.AddDays(-2), UpdatedDate = DateTime.Now,OrderStatus = OrderStatus.Pending,OrderStatusId = 3, 
        PaymentType = Type.GiftCard, 
    }
            });

            modelBuilder.Entity<OrderProduct>().HasData(new OrderProduct[]
            {
            new OrderProduct { Id = 1, ProductId = 1, OrderId = 123 },
            new OrderProduct { Id = 2, ProductId = 3, OrderId = 123 },
            new OrderProduct { Id = 3, ProductId = 4, OrderId = 123 },
            });

            modelBuilder.Entity<UserOrder>().HasData(new UserOrder[]
            {
            new UserOrder { Id = 1, UserId = 1, OrderId = 1},
            });

            modelBuilder.Entity<UserPaymentType>().HasData(new UserPaymentType[]
            {
            new UserPaymentType { Id = 1, UserId = 1, PaymentTypeId = 3}
            });
        }
    }
}
