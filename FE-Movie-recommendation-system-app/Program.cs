using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FE_Movie_recommendation_system_app
{
    public class Program
    {
        private static string _baseUrl = "http://localhost:50928";
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IHttpService, HttpService>()
                .AddScoped<ILocalStorageService, LocalStorageService>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(_baseUrl) });
            builder.Services.AddSingleton<AppState>();


            var host = builder.Build();
            var accountService = host.Services.GetRequiredService<IAccountService>();
            await accountService.Initialize();

            await builder.Build().RunAsync();
        }
    }
}
