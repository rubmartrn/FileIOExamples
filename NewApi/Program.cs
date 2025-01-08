var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Use(async (context, next) =>
{
    if (!context.Request.Headers.ContainsKey("username"))
    {
        context.Response.StatusCode = 401;
    }
    else
    {
        string username = context.Request.Headers["username"]!;
        if (username != "Poghos")
        {
            context.Response.StatusCode = 401;
        }
        else
        {
            await next.Invoke();
        }
    }
});


app.Use(async (context, next) =>
{
    if (context.Request.Path == "/student")
    {
        await context.Response.WriteAsJsonAsync(new
        {
            name = "Պողոս",
            email = "Poghos15@mail.ru"
        });
    }
    else
    {
        await next.Invoke();
    }
});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    try
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("օկ");
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


app.UseAuthorization();

app.MapControllers();

app.Run();