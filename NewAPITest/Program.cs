using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddCheck<MyCustomHealthCheck>("իմ սարքած չեքը")
    .AddUrlGroup(new Uri("https://facebook.com"),
    name: "fb", httpMethod: HttpMethod.Get,
    timeout: TimeSpan.FromSeconds(5))
    .AddUrlGroup(new Uri("https://googles.com"))
    .AddSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=UserDb");


builder.Services.AddHealthChecksUI(options =>
options.AddHealthCheckEndpoint("Health Checks", "/healthz")
).AddInMemoryStorage();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapHealthChecks("/health", new HealthCheckOptions()
{
    ResponseWriter = async (context, report) =>
    {
        var result = new MyHealthCheckResult
        {
            Message = "ԱՄեն ինչ լավ ա",
            Status = report.Status.ToString(),
        };
        await context.Response.WriteAsJsonAsync(result);
    }
});

app.MapHealthChecks("/healthz", new HealthCheckOptions()
{
    ResponseWriter =  UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecksUI(options =>
{
    options.UIPath = "/health-ui"; // Path for the health checks UI
});

app.MapControllers();

app.Run();

public class MyHealthCheckResult
{
    public string Status { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
}

public class MyCustomHealthCheck : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var result = true;
        await Task.Delay(50, cancellationToken); // Simulate some work

        if (result)
        {
            return HealthCheckResult.Healthy("Արդյունքը թրու էևր");
        }
        return HealthCheckResult.Unhealthy("The check indicates an unhealthy state.");
    }
}