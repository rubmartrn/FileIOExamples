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

var connectionString = builder.Configuration["AcaDbConectionString"];

builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();


app.MapGet("/seed", (StudentDbContext context) =>
{
    context.Students.Add(
        new UniversityProgram.Domain.Entities.Student
        {
            Name = "Poghos",
            Email = "poghos@poghos.com",
            Money = 700,
            Address = "Yerevan"
        });

    context.SaveChanges();
});
app.MapControllers();

app.Run();
