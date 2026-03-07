using Nwesp.Maui.Android.Hosting;
using MauiCustomControls.Pages;
using Microsoft.Extensions.Logging;

namespace MauiCustomControls
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
                })
                .AddTextInputLayout();

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            RegisterPages(builder);
            return builder.Build();
        }

        private static void RegisterPages(MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<HintPage>();
        }
    }
}
