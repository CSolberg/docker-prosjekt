using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Konfigurer databaseforbindelse
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Legg til API-tjenester
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/users", async ([FromServices] AppDbContext db, [FromBody] User user) =>
{
    db.Users.Add(user);
    await db.SaveChangesAsync();
    return Results.Created($"/users/{user.Id}", user);
});

app.MapGet("/users", async ([FromServices] AppDbContext db) =>
{
    var users = await db.Users.ToListAsync();
    return Results.Ok(users);
});


app.MapGet("/test-db", async ([FromServices] AppDbContext db) =>
{
    try
    {
        await db.Database.CanConnectAsync();
        return Results.Ok("Database connection successful!");
    }
    catch (Exception ex)
    {
        return Results.Problem($"Database connection failed: {ex.Message}");
    }
});

// Kjør migrasjoner automatisk, men sjekk først om tabellen finnes
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Korrekt sjekk for om tabellen allerede finnes
    var tableExists = dbContext.Database
        .SqlQueryRaw<int>("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users'")
        .AsEnumerable()
        .FirstOrDefault() > 0;

    if (!tableExists)
    {
        dbContext.Database.Migrate();
    }
}



app.Urls.Add("http://0.0.0.0:5000");

app.Run();
