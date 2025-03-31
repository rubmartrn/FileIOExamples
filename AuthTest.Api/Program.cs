using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataProtection();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/secret",
    (HttpContext ctx, IDataProtectionProvider provider) =>
    {
        var authCookie = ctx.Request.Cookies["auth"];
        if (authCookie == null)
        {
            ctx.Response.StatusCode = 401;
            return "";
        }
        var protector = provider.CreateProtector("auth-cookie");
        var unprotectedValue = protector.Unprotect(authCookie);
        return unprotectedValue;
    });

app.MapGet("/login",
    (HttpContext ctx, IDataProtectionProvider provider) =>
    {
        string cookieValue = "email:Ruben";
        var protector = provider.CreateProtector("auth-cookie");
        var protectedValue = protector.Protect(cookieValue);
        ctx.Response.Headers.Add("Set-Cookie", $"auth={protectedValue}");
        return "Ok";
    });

app.MapControllers();

app.Run();
