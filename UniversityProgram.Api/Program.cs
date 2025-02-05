
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api;
using UniversityProgram.Api.Middlewares;
using UniversityProgram.Api.Services.AddressService.Abstract;
using UniversityProgram.Api.Services.AddressService.Impl;
using UniversityProgram.Api.Services.CourseBankService.Abstract;
using UniversityProgram.Api.Services.CourseBankService.Impl;
using UniversityProgram.Api.Services.CoursesService.Abstract;
using UniversityProgram.Api.Services.CoursesService.Impl;
using UniversityProgram.Api.Services.CpuService.Abstract;
using UniversityProgram.Api.Services.CpuService.Impl;
using UniversityProgram.Api.Services.LaptopsService.Abstract;
using UniversityProgram.Api.Services.LaptopsService.Impl;
using UniversityProgram.Api.Services.LibrariesService.Impl;
using UniversityProgram.Api.Services.StudentsService.Abstract;
using UniversityProgram.Api.Services.StudentsService.Impl;
using UniversityProgram.Api.Services.UniversitiesService.Impl;
using UniversityProgram.Api.Validators.AddressValidators;
using UniversityProgram.Api.Validators.CourseValidators;
using UniversityProgram.Api.Validators.CpuValidators;
using UniversityProgram.Api.Validators.LaptopValidators;
using UniversityProgram.Api.Validators.LibraryValidators;
using UniversityProgram.Api.Validators.StudentValidators;
using UniversityProgram.Api.Validators.UniversityValidators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICourseBankService ,CourseBankServiceApi>();
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<ILaptopsService, LaptopsService>();
builder.Services.AddScoped<UniversityProgram.Api.Services.LibrariesService.Abstract.ILibraryService, LibrariesService>();
builder.Services.AddScoped<ICoursesService, CoursesService>();
builder.Services.AddScoped<UniversityProgram.Api.Services.UniversitiesService.Abstract.IUniversityService, UniversityService>();
builder.Services.AddScoped<ICpuService, CpuService>();
builder.Services.AddScoped<IAddressService, AddressService>();


builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

builder.Services.AddValidatorsFromAssemblyContaining<LaptopAddModelValidator>(ServiceLifetime.Transient);
builder.Services.AddValidatorsFromAssemblyContaining<CpuAddModelValidator>(ServiceLifetime.Transient);
builder.Services.AddValidatorsFromAssemblyContaining<CourseAddModelValidator>(ServiceLifetime.Transient);
builder.Services.AddValidatorsFromAssemblyContaining<LibraryAddModelValidator>(ServiceLifetime.Transient);
builder.Services.AddValidatorsFromAssemblyContaining<StudentAddModelValidator>(ServiceLifetime.Transient);
builder.Services.AddValidatorsFromAssemblyContaining<UniversityAddModelValidator>(ServiceLifetime.Transient);
builder.Services.AddValidatorsFromAssemblyContaining<AddressAddModelValidator>(ServiceLifetime.Transient); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();



app.MapControllers();

app.MapGet("test", () => 100);

app.Run();
