
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api;
using UniversityProgram.Api.Map;
using UniversityProgram.Api.Repositories;
using UniversityProgram.Api.Services;
using UniversityProgram.Api.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["StudentDb"];

builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddValidatorsFromAssemblyContaining<LaptopAddModelValidator>(ServiceLifetime.Transient);
builder.Services.AddAutoMapper(typeof(LaptopProfile));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IStudentService, StudentService>();

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
