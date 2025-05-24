using Hangfire;
using HangFireJobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(c => c.UseInMemoryStorage());

builder.Services.AddHangfireServer();

builder.Services.AddScoped<DbContext>();

var app = builder.Build();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate("Test",
    () => Console.WriteLine("test"),
    Cron.Minutely);

RecurringJob.AddOrUpdate("Test1",
    () => Console.WriteLine("test"),
    "2 * * * *");

RecurringJob.AddOrUpdate<RentalService>(
    nameof(RentalService),
    serv => serv.ProcessRentalJobs(),
    "* * * * *");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
