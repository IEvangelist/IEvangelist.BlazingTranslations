using IEvangelist.BlazingTranslations.Client.Interop;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEvangelist.BlazingTranslations.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Logging.SetMinimumLevel(LogLevel.Debug);
            builder.Services.AddScoped(sp =>
                new HttpClient
                {
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
                });
            builder.Services.AddLocalization();

            await using var host = builder.Build();

            var javaScript = host.Services.GetRequiredService<IJSRuntime>();
            var browserCulture = await javaScript.GetCultureAsync();
            if (browserCulture != null)
            {
                var culture = new CultureInfo(browserCulture);
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
            }

            await host.RunAsync();
        }
    }
}
