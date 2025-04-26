using Mediator;
using StudentApiForMediator.Data;
using StudentApiForMediator.Handlers;
using StudentApiForMediator.Requests;
using StudentApiForMediator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediator(e => e.ServiceLifetime = ServiceLifetime.Scoped);

builder.Services.AddSingleton<Database>();
builder.Services.AddSingleton<IPipelineBehavior<StudentAddRequest, StudentAddResponse>, StudentFieldslValidationPipeLine>();
builder.Services.AddSingleton<IPipelineBehavior<StudentAddRequest, StudentAddResponse>, StudentEmailUniqueValidationPipeLine>();

builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<CourseService>();

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
