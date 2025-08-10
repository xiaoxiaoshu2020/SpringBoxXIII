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

            builder.Services.AddHttpClient("api", (provider, client) =>
            {
#if DEBUG
                client.BaseAddress = new Uri("http://192.168.3.59:5000/"); // 基础地址
#else
                client.BaseAddress = new Uri("http://111.6.42.124:35850/"); // 生产环境基础地址
#endif
                client.DefaultRequestHeaders.Add("Accept", "application/json"); // 默认请求头
                client.Timeout = TimeSpan.FromSeconds(10);
            });
            builder.Services.AddTransient<IApiService,ApiService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
