using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddHttpClient<RentClient>( e=> e.BaseAddress= new Uri("http://localhost:5160/"));

await builder.Build().RunAsync();
