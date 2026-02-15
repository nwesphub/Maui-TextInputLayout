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
                Resources.MergedDictionaries.Add(new Maui.Android.TextInputLayout.Resources.LightTheme());
            }
            else if(PlatformAppTheme == AppTheme.Dark)
            {
                Resources.MergedDictionaries.Add(new Maui.Android.TextInputLayout.Resources.DarkTheme());
            }
            this.RequestedThemeChanged += App_RequestedThemeChanged;
        }

        private void App_RequestedThemeChanged(object? sender, AppThemeChangedEventArgs e)
        {
            if(e.RequestedTheme == AppTheme.Light)
            {
                var foundDictionary = Resources.MergedDictionaries.FirstOrDefault(x => x.GetType() == typeof(Maui.Android.TextInputLayout.Resources.DarkTheme));
                if (foundDictionary is not null)
                {
                    Resources.MergedDictionaries.Remove(Resources.MergedDictionaries.FirstOrDefault(x => x.GetType() == typeof(Maui.Android.TextInputLayout.Resources.DarkTheme)));
                }
                Resources.MergedDictionaries.Add(new Maui.Android.TextInputLayout.Resources.LightTheme());
            }
            else if(e.RequestedTheme == AppTheme.Dark)
            {
                var foundDictionary = Resources.MergedDictionaries.FirstOrDefault(x => x.GetType() == typeof(Maui.Android.TextInputLayout.Resources.LightTheme));
                if (foundDictionary is not null)
                {
                    Resources.MergedDictionaries.Remove(Resources.MergedDictionaries.FirstOrDefault(x => x.GetType() == typeof(Maui.Android.TextInputLayout.Resources.LightTheme)));
                }
                Resources.MergedDictionaries.Add(new Maui.Android.TextInputLayout.Resources.DarkTheme());
            }
        }

        private static void RegisterRoute<T>()
        {
            var name = typeof(T).Name;
            Routing.RegisterRoute(name, typeof(T));
        }
    }
}
