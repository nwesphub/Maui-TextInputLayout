using MauiCustomControls.Pages;

namespace MauiCustomControls
{
    public partial class App : Application
    {
        public App(AppShell shell)
        {
            InitializeComponent();

            MainPage = shell;
            RegisterRoute<HintPage>();
            if(PlatformAppTheme == AppTheme.Light)
            {
                Resources.MergedDictionaries.Add(new Nwesp.Maui.Android.Resources.LightTheme());
            }
            else if(PlatformAppTheme == AppTheme.Dark)
            {
                Resources.MergedDictionaries.Add(new Nwesp.Maui.Android.Resources.DarkTheme());
            }
            this.RequestedThemeChanged += App_RequestedThemeChanged;
        }

        private void App_RequestedThemeChanged(object? sender, AppThemeChangedEventArgs e)
        {
            if(e.RequestedTheme == AppTheme.Light)
            {
                var foundDictionary = Resources.MergedDictionaries.FirstOrDefault(x => x.GetType() == typeof(Nwesp.Maui.Android.Resources.DarkTheme));
                if (foundDictionary is not null)
                {
                    Resources.MergedDictionaries.Remove(Resources.MergedDictionaries.FirstOrDefault(x => x.GetType() == typeof(Nwesp.Maui.Android.Resources.DarkTheme)));
                }
                Resources.MergedDictionaries.Add(new Nwesp.Maui.Android.Resources.LightTheme());
            }
            else if(e.RequestedTheme == AppTheme.Dark)
            {
                var foundDictionary = Resources.MergedDictionaries.FirstOrDefault(x => x.GetType() == typeof(Nwesp.Maui.Android.Resources.LightTheme));
                if (foundDictionary is not null)
                {
                    Resources.MergedDictionaries.Remove(Resources.MergedDictionaries.FirstOrDefault(x => x.GetType() == typeof(Nwesp.Maui.Android.Resources.LightTheme)));
                }
                Resources.MergedDictionaries.Add(new Nwesp.Maui.Android.Resources.DarkTheme());
            }
        }

        private static void RegisterRoute<T>()
        {
            var name = typeof(T).Name;
            Routing.RegisterRoute(name, typeof(T));
        }
    }
}
