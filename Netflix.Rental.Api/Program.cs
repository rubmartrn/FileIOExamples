using Microsoft.EntityFrameworkCore;
using Netflix.Rental.Api.Clients;
using Netflix.Rental.Api.Services;
using Netflix.Rental.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRentalService, RentalService>();

builder.Services.AddDbContext<RentalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentalDb")));

builder.Services.AddHttpClient<MovieApi>(e => e.BaseAddress = new Uri(builder.Configuration["movieApi"]!));
builder.Services.AddHttpClient<UserApi>(e => e.BaseAddress = new Uri(builder.Configuration["userApi"]!));
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
