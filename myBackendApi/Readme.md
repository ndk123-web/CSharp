# 🌐 ASP.NET Core Web API Learning Guide

This document covers my journey and understanding of ASP.NET Core Web API so far, from starting a new project to understanding Minimal APIs, Controllers, attributes, and best practices.

## Concept of IAction
- IAction is Interface 
- so return type is IAction
- Ok is returning object of OkObjectClass
- that okObjetctClass implements IAction interface
- and OkObjectClass is in ControllerBase
- And is valid because Ok() return type is OkObjectClass and that class implements IAction interface that's why it's valid

## ✅ 1. How to Create a New ASP.NET Core Web API Project

### 🔹 Prerequisite:

* .NET SDK installed

### 🔹 Create the project using CLI:

```bash
dotnet new webapi -n MyWebApi
cd MyWebApi
dotnet run
```

This creates a ready-to-run Web API project with a sample endpoint (`/weatherforecast`).

---

## ✅ 2. Sample Code Explanation (Minimal API Style)

### 🔹 `Program.cs` (simplified with explanations)

```csharp
var builder = WebApplication.CreateBuilder(args); // Create builder for app config and services

builder.Services.AddControllers(); // Add support for controllers
builder.Services.AddEndpointsApiExplorer(); // Swagger metadata support
builder.Services.AddSwaggerGen(); // Swagger UI generation

var app = builder.Build(); // Build the app

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger in development
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Force HTTPS
app.MapControllers(); // Enable attribute-based routing (controllers)

// Minimal API endpoint
app.MapGet("/", () => Results.Ok("Hello this is Home"));

app.Run(); // Run the app
```

---

## ✅ 3. `HelloController.cs` Explanation (Controller-based API)

```csharp
using Microsoft.AspNetCore.Mvc;

[ApiController] // Class-level attribute to define API controller behavior
[Route("api/[controller]")] // Route is resolved as api/hello
public class HelloController : ControllerBase
{
    [HttpGet] // Maps to GET request
    public IActionResult GetHello()
    {
        return Ok("Hello from your API!"); // Returns 200 OK
    }

    [HttpPost] // Maps to POST request
    public IActionResult PostData([FromBody] string name)
    {
        return Ok($"Received: {name}"); // Returns 200 OK with dynamic value
    }
}
```

### 🔹 Important Concepts:

| Attribute         | Type        | Description                                            |
| ----------------- | ----------- | ------------------------------------------------------ |
| `[ApiController]` | Class       | Enables model binding, validation, etc.                |
| `[Route]`         | Class       | Defines the base route of the controller               |
| `[HttpGet]`       | Method      | Maps to HTTP GET requests                              |
| `[HttpPost]`      | Method      | Maps to HTTP POST requests                             |
| `IActionResult`   | Return Type | Allows flexible response types like Ok(), BadRequest() |
| `[FromBody]`      | Parameter   | Binds request JSON body to parameter                   |

---

## ✅ 4. Summary of Endpoints

### 🔹 Minimal API

| Method | URL                | Description                 |
| ------ | ------------------ | --------------------------- |
| GET    | `/`                | Returns home message        |
| GET    | `/weatherforecast` | Returns sample weather data |

### 🔹 Controller API

| Method | URL          | Description              |
| ------ | ------------ | ------------------------ |
| GET    | `/api/hello` | Returns hello message    |
| POST   | `/api/hello` | Accepts name, returns it |

---

## ✅ 5. `.gitignore` for ASP.NET Web API

```gitignore
bin/
obj/
.vs/
.vscode/
*.user
*.suo
*.log
*.tmp
appsettings.Development.json
```

This prevents build files, user configs, and secrets from being pushed to GitHub.
