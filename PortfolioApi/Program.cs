using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using PostApiSeperateFile;

var builder = WebApplication.CreateBuilder(args);

// Configure the DbContext with SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=portfolio.db"));

// Add endpoint API explorer
builder.Services.AddEndpointsApiExplorer();

// Add Swagger generation
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger and Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portfolio API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

// Map the endpoints
PostEndpoints.Map(app);

// Run the application
app.Run();
