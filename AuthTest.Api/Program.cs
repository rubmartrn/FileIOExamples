using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UniversityProgram.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string AuthScheme = "Cookie";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthorizationHandler, TestRequirementHandler>();
builder.Services.AddAuthentication(AuthScheme)
    .AddCookie(AuthScheme)
    .AddCookie("UrishCookie");
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Aca11"));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Only Students", policy =>
    {
        policy.AddAuthenticationSchemes(AuthScheme)
        .RequireAuthenticatedUser()
        .AddRequirements(new TestRequirement())
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

public class TestRequirement : IAuthorizationRequirement
{
    public int Money { get; set; } = 3000;
}

public class TestRequirementHandler : AuthorizationHandler<TestRequirement>
{
    private readonly StudentDbContext _context;

    public TestRequirementHandler(StudentDbContext context)
    {
        _context = context;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, TestRequirement requirement)
    {
        var student = await _context.Students
            .FirstOrDefaultAsync(e => e.Email == context.User.FindFirst("email")!.Value);

        if (student == null)
        {
            context.Fail();
            return;
        }
        if (student.Money >= requirement.Money)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
    }
}
