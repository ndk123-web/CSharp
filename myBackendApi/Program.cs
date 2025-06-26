using Microsoft.AspNetCore.Http.HttpResults; // Minimal API response helpers
using Microsoft.AspNetCore.Mvc;              // For controller-based API support

var builder = WebApplication.CreateBuilder(args); // App configuration and DI setup

// 🔧 Add services to the container

builder.Services.AddOpenApi();               // For Swagger (API testing UI)
builder.Services.AddControllers();           // To use controllers (like HelloController)
builder.Services.AddEndpointsApiExplorer();  // Enables endpoint metadata for Swagger

var app = builder.Build();                   // Create the final app pipeline

// 🛠️ Middleware pipeline configuration

if (app.Environment.IsDevelopment())         // Swagger available only in dev mode
{
    app.MapOpenApi();                        // Maps OpenAPI (Swagger) if in dev
}

app.UseHttpsRedirection();                   // Redirect HTTP to HTTPS
app.MapControllers();                        // Enable controller routes like /api/hello

// 🔹 Sample WeatherForecast endpoint using Minimal API
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", 
    "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>         // GET endpoint: /weatherforecast
{
    var forecast = Enumerable.Range(1, 5).Select(index => 
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),    // Date
            Random.Shared.Next(-20, 55),                           // Temperature
            summaries[Random.Shared.Next(summaries.Length)]        // Summary
        ))
        .ToArray();

    return forecast;                          // Return 5-day forecast
})
.WithName("GetWeatherForecast");             // Optional: give endpoint a name

// 🔹 Root endpoint: GET /
app.MapGet("/", () => 
{
    return Results.Ok("Hello this is Home"); // Minimal API root response
})
.WithName("Home");                           // Name for this endpoint

app.Run();                                   // Start the app and listen for requests

// 🔹 Record type used for weather data
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556); // Auto-calculated F value
}
