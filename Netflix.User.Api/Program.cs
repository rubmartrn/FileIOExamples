using Microsoft.EntityFrameworkCore;
using Netflix.User.Api.Clients;
using Netflix.User.Api.Services;
using Netflix.UserManagement.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDb")));


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddHttpClient<RentClient>( e=> e.BaseAddress= new Uri("https+http://netflixRentalApi"));
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
