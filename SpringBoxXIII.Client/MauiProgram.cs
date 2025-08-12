using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpringBoxXIII.Client.Models;
using SpringBoxXIII.Client.Services;
using SpringBoxXIII.Client.ViewModels;
using SpringBoxXIII.Client.Views;
using System.Diagnostics;

namespace SpringBoxXIII.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<SettingsViewModel>();
            builder.Services.AddTransient<SettingsPage>();

            // MauiProgram.cs
            builder.Services.AddHttpClient("api", client =>
            {
                var baseAddress = Preferences.Default.Get("api_base_address", "https://localhost:5106/");
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.Timeout = TimeSpan.FromSeconds(15);
            });
            builder.Services.AddTransient<IApiService, ApiService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
