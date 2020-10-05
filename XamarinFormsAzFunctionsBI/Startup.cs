using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Xamarin.Essentials;
using XamarinFormsAzFunctionsBI.Helpers;
using XamarinFormsAzFunctionsBI.ViewModels;
using XamarinFormsAzFunctionsBI.ViewModels.Interfaces;

namespace XamarinFormsAzFunctionsBI
{
    public static class Startup
    { 
        public static App Init(Action<HostBuilderContext, IServiceCollection> nativeConfigureServices)
        {
            var systemDir = FileSystem.CacheDirectory;
            ResourcesHelpers.ExtractSaveResource("XamarinFormsAzFunctionsBI.appsettings.json", systemDir);
            var fullConfig = Path.Combine(systemDir, "XamarinFormsAzFunctionsBI.appsettings.json");

            var host = new HostBuilder()
                            .ConfigureHostConfiguration(c =>
                            {
                                c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                                c.AddJsonFile(fullConfig);
                            })
                            .ConfigureServices((c, x) =>
                            {
                                nativeConfigureServices(c, x);
                                ConfigureServices(c, x);
                            })
                            .ConfigureLogging(l => l.AddConsole(o =>
                            {
                                o.DisableColors = true;
                            }))
                            .Build();

            App.ServiceProvider = host.Services;

            return App.ServiceProvider.GetService<App>();
        }


        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            if (ctx.HostingEnvironment.IsDevelopment())
            {
                var Api = ctx.Configuration["ApiUrl"];
            }

           // services.AddHttpClient();
            services.AddTransient<IMainViewModel, MainViewModel>();
            services.AddTransient<MainPage>();
            services.AddSingleton<App>();
        }
    }
}
