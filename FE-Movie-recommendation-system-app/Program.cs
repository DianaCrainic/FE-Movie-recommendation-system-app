using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FE_Movie_recommendation_system_app
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IHttpService, HttpService>()
                .AddScoped<ILocalStorageService, LocalStorageService>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(APIConstants.BaseUrl) });
            builder.Services.AddSingleton<AppState>();
            builder.Services.AddSyncfusionBlazor();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Licenses.SyncfusionLicense);

            var host = builder.Build();
            var accountService = host.Services.GetRequiredService<IAccountService>();
            await accountService.Initialize();

            await builder.Build().RunAsync();
        }
    }
}
