using Microsoft.EntityFrameworkCore;
using StudentService.Data;
using StudentService.Repositories;
using StudentService.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();



// MySQL Database Connection
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "MySQL connection string is missing."
    );
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(connectionString)
);


// Register Repository
builder.Services.AddScoped<IStudentRepository, StudentRepository>();


// Register Service
builder.Services.AddScoped<IStudentService, StudentService.Services.StudentService>();




// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
