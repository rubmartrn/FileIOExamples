
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api;
using UniversityProgram.Api.Map;
using UniversityProgram.Api.Validators;
using UniversityProgram.BLL.Services;
using UniversityProgram.Data;
using UniversityProgram.Data.Repositories;
using UniversityProgram.Domain.BaseRepositories;
using UniversityProgram.LocalData;
using UniversityProgram.LocalData.Repositories;

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
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkJson>();
builder.Services.AddScoped<IJsonDataService, JsonDataService>();

builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.MapGet("test", () => 100);

app.Run();
