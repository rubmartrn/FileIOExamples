
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api;
using UniversityProgram.Api.Models;
using UniversityProgram.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CourseBankServiceApi>();

var connectionString = builder.Configuration["StudentDb"];

builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddValidatorsFromAssemblyContaining<LaptopAddModelValidator>(ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapGet("test", () => 100);

app.Run();
