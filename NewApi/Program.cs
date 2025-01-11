using NewApi;
using NewApi.Middlewares;
using NewApi.Services;
using NewApi.Startups;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ITestServiceTransient, TestServiceTransient>();
builder.Services.AddSingleton<ITestServiceSingleton, TestServiceSingleton>();

builder.Services.AddScoped<ITestServiceScoped, TestServiceScoped>();
builder.Services.Configure<BankSettings>(builder.Configuration.GetSection("BankSettings"));

string password = builder.Configuration["BankSettings:Password"]!;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseMiddleware<StudentMiddleware>();

app.UseMyMiddleWare();


//minimal API
app.MapGet("/minimalStudent", async context =>
{
    context.Response.StatusCode = 200;
    await context.Response.WriteAsJsonAsync(new
    {
        name = "Petros"
    });
});

app.MapControllers();

app.Run();