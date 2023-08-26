using Microsoft.EntityFrameworkCore;
using BangAzon.Models;

namespace BangAzon
{
    public class BangazonDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> Status { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(new User[]
            {
            new User { UserId = 1, UserName = "Bob", Email = "bobiscool@gmail.com", Password = "mommashouse33", isSeller=false },
            });

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
          
            new Product { ProductId = 1, Name = "Epic Adventure Book", Description = "Embark on a thrilling journey through uncharted lands.", Price = 25.99M },
            new Product { ProductId = 2, Name = "Mystical Fantasy Novel", Description = "Unveil the secrets of a world filled with magic and wonder.", Price = 19.95M },
            new Product { ProductId = 3, Name = "Virtual Realm Game", Description = "Dive into a virtual universe where anything is possible.", Price = 49.99M },
            new Product { ProductId = 4, Name = "Sci-Fi Shooter", Description = "Engage in epic battles across distant galaxies.", Price = 39.99M },
            new Product { ProductId = 5, Name = "Professional Basketball", Description = "High-quality basketball for competitive play.", Price = 29.99M },
            new Product { ProductId = 6, Name = "Training Football", Description = "Practice your skills with this durable training football.", Price = 15.99M }
            });

            modelBuilder.Entity<ProductType>().HasData(new ProductType[]
            {
             new ProductType { ProductTypeId = 1, Name = "Books" },
             new ProductType { ProductTypeId = 2, Name = "Sports" },
             new ProductType { ProductTypeId = 3, Name = "Video Games" },
            });

            modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
            {
            new PaymentType { PaymentTypeId = 1, Type = "Debit Card"},
            new PaymentType { PaymentTypeId = 2, Type = "Credit Card"},
            new PaymentType { PaymentTypeId = 3, Type = "Gift Card"},
            new PaymentType { PaymentTypeId = 4, Type = "AfterPay"}
            });

            modelBuilder.Entity<OrderProduct>().HasData(new OrderProduct[]
            {
                new OrderProduct {OrderProductId = 1001, ProductId = 1, OrderId = 123},
                new OrderProduct {OrderProductId = 1002, ProductId = 3, OrderId = 124},
                new OrderProduct {OrderProductId = 1003, ProductId = 6, OrderId = 125},
            });

            modelBuilder.Entity<Order>().HasData(new Order[]
            {
            new Order {  OrderId = 123, UserId = 1, CreatedDate = DateTime.Now.AddDays(-5), UpdatedDate = DateTime.Now, OrderStatus = OrderStatus.Processing, OrderStatusId = 1, PaymentType = "credit Card"  },
            new Order {  OrderId = 124, UserId = 2, CreatedDate = DateTime.Now.AddDays(-3).AddDays(-10), UpdatedDate = DateTime.Now.AddDays(-3), OrderStatus = OrderStatus.Completed, OrderStatusId = 2,  PaymentType = "Afterpay" },
            new Order {  OrderId = 125, UserId = 3, CreatedDate = DateTime.Now.AddDays(-2), UpdatedDate = DateTime.Now,OrderStatus = OrderStatus.Pending,OrderStatusId = 3, PaymentType = "GiftCard" }
            });

            modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus[]
            {
            new OrderStatus { OrderStatusId = 1, Name = "Processing"},
            new OrderStatus {  OrderStatusId = 2, Name = "Completed" },
            new OrderStatus {  OrderStatusId = 3, Name = "Pending" },
            });

        }
    }
}
