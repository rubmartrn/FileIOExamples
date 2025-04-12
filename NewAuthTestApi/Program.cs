using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityDbContext>(e => e.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=IdentityTest"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(e =>
{
    e.User.RequireUniqueEmail = true;
    e.Password.RequiredLength = 5;
    e.Password.RequireDigit = true;
    e.Password.RequireLowercase = true;
    e.Password.RequireUppercase = true;
})
.AddEntityFrameworkStores<IdentityDbContext>()
.AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapGet("/seed", async (ctx) =>
{
    var db = ctx.RequestServices.GetRequiredService<IdentityDbContext>();
    db.Database.EnsureCreated();
    var mng = ctx.RequestServices.GetRequiredService<UserManager<IdentityUser>>();
    var user = new IdentityUser()
    {
        UserName = "testuser",
        Email = "ruben@gmail.com"
    };

    var result = await mng.CreateAsync(user, "Aa%12345");
    Console.Write("a");
});

app.MapGet("/seed2", async (ctx) =>
{

    var rlMng = ctx.RequestServices.GetRequiredService<RoleManager<IdentityRole>>();
    await rlMng.CreateAsync(new IdentityRole("student"));

    var mng = ctx.RequestServices.GetRequiredService<UserManager<IdentityUser>>();
    var user = new IdentityUser()
    {
        UserName = "testuser1",
        Email = "ruben1@gmail.com"
    };

    var result = await mng.CreateAsync(user, "Aa%12345");

    await mng.AddToRoleAsync(user, "student");
});

app.MapControllers();

app.Run();
