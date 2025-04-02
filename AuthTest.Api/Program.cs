using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string AuthScheme = "Cookie";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(AuthScheme)
    .AddCookie(AuthScheme, e=>
    {
        e.AccessDeniedPath = "/login";
        e.LoginPath = "/login";
    })
    .AddCookie("UrishCookie");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.MapGet("/secret",
    (HttpContext ctx, IDataProtectionProvider provider) =>
    {
        return ctx.User.FindFirst("email")!.Value;
    });

app.MapGet("/studentInfo", (HttpContext ctx) =>
{
    if (!ctx.User.Identities.Any(e=>e.AuthenticationType == AuthScheme))
    {
        return Results.Forbid();
    }

    if(!ctx.User.HasClaim("UserType", "Student"))
    {
        return Results.Forbid();
    }

    return Results.Ok();
});

app.MapGet("/login",
   async (HttpContext ctx) =>
    {
        var claim = new Claim("Email", "Ruben@gmail.ru");
        var claim1 = new Claim("UserType", "Student");
        var identity = new ClaimsIdentity(new List<Claim>() { claim, claim1 }, AuthScheme);
        var user = new ClaimsPrincipal(identity);
        await ctx.SignInAsync(user);
        return "Ok";
    });

app.MapControllers();

app.Run();
