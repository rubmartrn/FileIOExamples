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

app.UseAuthorization();

//minimal API
app.MapGet("/student", async context =>
{
    context.Response.StatusCode = 200;
    await context.Response.WriteAsJsonAsync(new
    {
        name = "Petros"
    });
});

app.MapControllers();

app.Run();