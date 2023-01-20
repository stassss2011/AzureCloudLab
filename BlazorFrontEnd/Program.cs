using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorFrontEnd;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseAddress = builder.Configuration.GetValue<string>("BaseUrl");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress ?? builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();