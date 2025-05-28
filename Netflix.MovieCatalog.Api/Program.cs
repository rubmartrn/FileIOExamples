using Microsoft.EntityFrameworkCore;
using Netflix.MovieCatalog.Api.Clients;
using Netflix.MovieCatalog.Business;
using Netflix.MovieCatalog.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieCatalogDb")));

builder.Services.AddHttpClient<RentApi>(e => e.BaseAddress = new Uri("http://localhost:5160/"));
builder.Services.AddScoped<IMovieService, MovieService>();
var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
