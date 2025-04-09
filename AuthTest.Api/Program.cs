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
    .AddCookie(AuthScheme)
    .AddCookie("UrishCookie");

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Only Students", policy =>
    {
        policy.AddAuthenticationSchemes(AuthScheme)
        .RequireAuthenticatedUser()
        .RequireClaim("usertype", "student");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/secret",
    (HttpContext ctx, IDataProtectionProvider provider) =>
    {
        return ctx.User.FindFirst("email")!.Value;
    });

app.MapGet("/studentInfo", (HttpContext ctx) =>
{
    return Results.Ok("Ուսանողի անունը՝ Պողո");
}).RequireAuthorization("Only Students");

app.MapGet("/login",
   async (HttpContext ctx) =>
    {
        var claim = new Claim("Email", "Ruben@gmail.ru");
        var claim1 = new Claim("usertype", "student");
        var identity = new ClaimsIdentity(new List<Claim>() { claim, claim1 }, AuthScheme);
        var user = new ClaimsPrincipal(identity);
        await ctx.SignInAsync(user);
        return "Ok";
    }).AllowAnonymous();

app.MapControllers();

app.Run();
