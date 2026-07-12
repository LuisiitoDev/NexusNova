using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using NexusNova.Infraestructure.Http;
using NexusNova.UI.Pages;
using NexusNova.UI.ViewModels;
using Refit;

namespace NexusNova
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("SegoeUI-Semibold.ttf", "SegoeSemibold");
                    fonts.AddFont("FluentSystemIcons-Regular.ttf", FluentUI.FontFamily);
                });

            builder.Services.AddRefitClient<INovaApiClient>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri("https+http:
                });

            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<AssistantPage>();
            builder.Services.AddTransient<AgendaPage>();
            builder.Services.AddSingleton<AppShell>();

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<AssistantViewModel>();
            builder.Services.AddTransient<AgendaViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
    		builder.Services.AddLogging(configure => configure.AddDebug());
#endif

            return builder.Build();
        }
    }
}
