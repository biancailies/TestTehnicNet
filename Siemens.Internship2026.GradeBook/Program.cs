using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Repositories;
using Siemens.Internship2026.GradeBook.Services;

var builder = WebApplication.CreateBuilder(args);

// Adds controller support for the Web API.
builder.Services.AddControllers();

// Registers repository and service abstractions using dependency injection.
builder.Services.AddHttpClient<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IGradeService, GradeService>();

// Adds built-in OpenAPI document generation support available in modern ASP.NET Core.
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Exposes the generated OpenAPI document in Development.
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();