using Android.Content.Res;
using MauiCustomControls.Pages;
using Nwesp.Maui.Android.Hosting;
using Nwesp.Maui.Android.Resources;

namespace MauiCustomControls
{
    public partial class App : Application
    {
        public App(AppShell shell)
        {
            InitializeComponent();

            MainPage = shell;
            RegisterRoute<HintPage>();
            this.ConfigureTextInputLayoutThemes();
        }


        private static void RegisterRoute<T>()
        {
            var name = typeof(T).Name;
            Routing.RegisterRoute(name, typeof(T));
        }
    }
}
