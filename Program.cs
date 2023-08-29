using System.Text.Json.Serialization;
using BangAzon;
using BangAzon.Models;
using Microsoft.AspNetCore.Mvc;
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

app.MapGet("/api/users", (BangazonDbContext db) =>
{
    return db.User.ToList();
});

app.MapPost("/api/users", (BangazonDbContext db, User user) =>
{
    db.User.Add(user);
    return Results.Created($"api/users/{user.UserId}", user);
});

app.MapGet("/api/users/{userId}", (int userId, BangazonDbContext db) =>
{
    User user = db.User.FirstOrDefault(u => u.UserId == userId);
    if (user == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(user);
});

app.MapDelete("/api/users/{userId}", (int userId, BangazonDbContext db) =>
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

app.MapPut("/api/users/{userId}", async (int userId, [FromBody] User updatedUser, BangazonDbContext db) =>
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

    await db.SaveChangesAsync();

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


app.MapGet("/api/orders", (BangazonDbContext db) =>
{
    return db.Orders.ToList();
});

app.Run();
