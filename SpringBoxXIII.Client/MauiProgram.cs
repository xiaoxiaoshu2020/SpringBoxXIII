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

            builder.Services.AddHttpClient<IApiService, ApiService>((provider, client) =>
            {
                client.BaseAddress = new Uri("http://localhost:5106/"); // 基础地址
                client.DefaultRequestHeaders.Add("Accept", "application/json"); // 默认请求头
                client.Timeout = TimeSpan.FromSeconds(15);
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
