/*
 * Client Program - Enhanced with service registration and configuration
 * REFACTORING: Centralized service registration and configuration
 */

using Client;
using Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure HTTP Client with timeout and base address
builder.Services.AddScoped(sp =>
{
    var httpClient = new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
        Timeout = TimeSpan.FromSeconds(ApiConfiguration.RequestTimeoutSeconds),
    };
    return httpClient;
});

// Register services
builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();
