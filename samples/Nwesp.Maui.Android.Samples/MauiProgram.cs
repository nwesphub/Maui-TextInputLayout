using Microsoft.Extensions.Logging;
using Nwesp.Maui.Android.Hosting;

namespace Nwesp.Maui.Android.Samples
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
            builder.RegisterPages();
            return builder.Build();
        }

        private static void RegisterPages(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<PasswordPage>();
        }
    }
}
