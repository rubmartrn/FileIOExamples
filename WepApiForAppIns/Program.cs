using Microsoft.EntityFrameworkCore;
using UniversityProgram.BLL.Services;
using UniversityProgram.Data;
using UniversityProgram.Data.Repositories;
using UniversityProgram.Domain.BaseRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Aca11"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
