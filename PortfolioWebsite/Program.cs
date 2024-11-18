using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PortfolioWebsite.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PortfolioWebsite
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            // Configure HttpClient for the ProjectService
            builder.Services.AddHttpClient<ProjectService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7211/api/");
            });


            // Register other services
            builder.Services.AddSingleton<PortfolioWebsite.Services.BlogService>();

            await builder.Build().RunAsync();
        }
    }
}
