using System.Text.Json.Serialization;
using BangAzon;
using BangAzon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonDbContext>(builder.Configuration["BangazonDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/api/user", (BangazonDbContext db) =>
{
    return db.User.ToList();
});

app.MapPost("/api/user", (BangazonDbContext db, User user) =>
{
    db.User.Add(user);
    db.SaveChanges();
    return Results.Created($"api/user/{user.UserId}", user);
});

app.MapGet("/api/user/{userId}", (int userId, BangazonDbContext db) =>
{
    User user = db.User.FirstOrDefault(u => u.UserId == userId);
    if (user == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(user);
});

app.MapDelete("/api/user/{userId}", (int userId, BangazonDbContext db) =>
{
    User user = db.User.FirstOrDefault(u => u.UserId == userId);

    if (user == null)
    {
        return Results.NotFound();
    }

    db.User.Remove(user);
    db.SaveChanges();

    return Results.Ok(user);
});

app.MapPut("/api/user/{userId}", async (int userId, [FromBody] User updatedUser, BangazonDbContext db) =>
{
    User existingUser = db.User.FirstOrDefault(u => u.UserId == userId);

    if (existingUser == null)
    {
        return Results.NotFound();
    }

    existingUser.UserName = updatedUser.UserName;
    existingUser.Email = updatedUser.Email;
    existingUser.Password = updatedUser.Password;
    existingUser.isSeller = updatedUser.isSeller;

    db.SaveChanges();

    return Results.Ok(existingUser);
});



app.MapGet("/api/product", (BangazonDbContext db) =>
{
    return db.Products.ToList();
});
app.MapPost("/api/products", (BangazonDbContext db, Product product) =>
{
    db.Products.Add(product);
    db.SaveChanges();

    return Results.Created($"/api/products/{product.ProductId}", product);
});

app.MapGet("/api/products/{productId}", (int productId, BangazonDbContext db) =>
{
    Product product = db.Products.FirstOrDefault(p => p.ProductId == productId);
    if (product == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(product);
});

app.MapDelete("/api/products/{productId}", (int productId, BangazonDbContext db) =>
{
    Product product = db.Products.FirstOrDefault(p => p.ProductId == productId);

    if (product == null)
    {
        return Results.NotFound();
    }

    db.Products.Remove(product);
    db.SaveChanges();

    return Results.Ok(product);
});
app.MapPut("/api/products/{productId}", async (int productId, [FromBody] Product updatedProduct, BangazonDbContext db) =>
{
    Product existingProduct = db.Products.FirstOrDefault(p => p.ProductId == productId);

    if (existingProduct == null)
    {
        return Results.NotFound();
    }

    existingProduct.Name = updatedProduct.Name;
    existingProduct.Description = updatedProduct.Description;
    existingProduct.Price = updatedProduct.Price;
    existingProduct.StockQuantity = updatedProduct.StockQuantity;

    db.SaveChanges();

    return Results.Ok(existingProduct);
});


app.MapGet("/api/orders", (BangazonDbContext db) =>
{
    return db.Orders.ToList();
});

app.MapGet("/api/orders/{orderId}", (int orderId, BangazonDbContext db) =>
{
    var order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.OrderId == orderId);

    if (order == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(order);
});

app.MapPost("/api/orders", (Order order, BangazonDbContext db) =>
{
    db.Orders.Add(order);
    db.SaveChanges();

    return Results.Created($"/api/orders/{order.OrderId}", order);
});


app.MapDelete("/api/orders/{orderId}/products/{productId}", (int orderId, int productId, BangazonDbContext db) =>
{
    var order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.OrderId == orderId);
    if (order == null)
    {
        return Results.NotFound();
    }
    var productToRemove = order.Products.FirstOrDefault(p => p.ProductId == productId);
    if (productToRemove == null)
    {
        return Results.NotFound();
    }
    order.Products.Remove(productToRemove);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapPost("/api/orders/{orderId}/products/{productId}", (int orderId, int productId, BangazonDbContext db) =>
{
    var order =  db.Orders.Include(o => o.Products).FirstOrDefault(o => o.OrderId == orderId);

    if (order == null)
    {
        return Results.NotFound();
    }

    var productToAdd = db.Products.FirstOrDefault(p => p.ProductId == productId);

    if (productToAdd == null)
    {
        return Results.NotFound();
    }

    order.Products.Add(productToAdd);
    db.SaveChanges();

    return Results.NoContent();
});

app.MapDelete("/api/orders/{orderId}", (int orderId, BangazonDbContext db) =>
{
    var order = db.Orders.Find(orderId);

    if (order == null)
    {
        return Results.NotFound();
    }

    db.Orders.Remove(order);
    db.SaveChanges();

    return Results.NoContent();
});

app.MapGet("/api/paymenttypes/{paymentTypeId}", (int paymentTypeId, BangazonDbContext db) =>
{
    var paymentType = db.PaymentType.Find(paymentTypeId);

    if (paymentType == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(paymentType);
});

app.MapPost("/api/paymenttypes", (PaymentType paymentType, BangazonDbContext db) =>
{
    db.PaymentType.Add(paymentType);
    db.SaveChangesAsync();

    return Results.Created($"/api/paymenttypes/{paymentType.PaymentTypeId}", paymentType);
});


app.Run();
