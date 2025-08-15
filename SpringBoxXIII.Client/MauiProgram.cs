using Microsoft.Extensions.Logging;
using SpringBoxXIII.Client.Services;
using SpringBoxXIII.Client.ViewModels;
using SpringBoxXIII.Client.Views;

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
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoginPage>();

            builder.Services.AddSingleton(Preferences.Default);
            builder.Services.AddSingleton<IApiConfigService,ApiConfigService>();
            builder.Services.AddHttpClient("api", (sp,client) =>
            {
                var config = sp.GetRequiredService<IApiConfigService>();
                client.BaseAddress = new Uri(config.BaseAddress);
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
