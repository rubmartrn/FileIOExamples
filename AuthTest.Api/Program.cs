using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataProtection();
builder.Services.AddScoped<AuthService>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use((ctx, next) =>
{
    var provider = ctx.RequestServices.GetService<IDataProtectionProvider>();
    var authCookie = ctx.Request.Cookies["auth"];
    if (authCookie == null)
    {
        throw new UnauthorizedAccessException();
    }
    var protector = provider.CreateProtector("auth-cookie");
    var unprotectedValue = protector.Unprotect(authCookie);
    return next.Invoke();
});

app.MapGet("/secret",
    (HttpContext ctx, IDataProtectionProvider provider) =>
    {
        
        return "a";
    });

app.MapGet("/login",
    (AuthService auth) =>
    {
        auth.SignIn();
        return "Ok";
    });

app.MapControllers();

app.Run();


public class AuthService
{
    private readonly IHttpContextAccessor _accessor;
    private readonly IDataProtectionProvider _provider;

    public AuthService(IHttpContextAccessor accessor,
        IDataProtectionProvider provider)
    {
        _accessor = accessor;
        _provider = provider;
    }

    public void SignIn()
    {
        string cookieValue = "email:Ruben";
        var protector = _provider.CreateProtector("auth-cookie");
        var protectedValue = protector.Protect(cookieValue);
        _accessor.HttpContext!.Response.Headers.Add("Set-Cookie", $"auth={protectedValue}");
    }
}