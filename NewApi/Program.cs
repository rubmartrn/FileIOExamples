var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    try
    {
        await next.Invoke();
    }
    catch (Exception e)
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsJsonAsync(new
        {
            errorHy = "մի բան սխալ էր",
            errorEn = "Something went wrong",
            message = e.Message
        });
    }
});

app.Use(async (context, next) =>
{
    if (context is not null)
    {
        throw new Exception("Wrong");
    }
    await next.Invoke();
});

app.UseAuthorization();

app.MapControllers();

app.Run();