using BlazorWASM;
using BlazorWASM.Clients;
using BlazorWASM.Handlers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<CustomAuthMessageHandler>();
builder.Services.AddHttpClient("ServerAPI",
      client => client.BaseAddress = new Uri(builder.Configuration["BackendUrl"]!))
    .AddHttpMessageHandler<CustomAuthMessageHandler>();

builder.Services.AddHttpClient<StudentClient>("ServerAPI");

//builder.Services.AddHttpClient<StudentClient>(e=>e.BaseAddress = new Uri("http://localhost:5042"))
//    .AddHttpMessageHandler<CustomAuthMessageHandler>();

builder.Services.AddHttpClient("BankApi",
      client => client.BaseAddress = new Uri("http://localhost:5042"));
//builder.Services.AddHttpClient<BooklLient>("ServerAPI");

//builder.Services.AddHttpClient<BankClient>("BankApi");

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";

    options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]!);

    options.UserOptions.RoleClaim = "https://www.aca.com/roles";
});

builder.Services.AddAuthorizationCore(op =>
{
    op.AddPolicy("nameruben", p => p.RequireClaim("nickname", "rubmartrn"));
});

await builder.Build().RunAsync();
