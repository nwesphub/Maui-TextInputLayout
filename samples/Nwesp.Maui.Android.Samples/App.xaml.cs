using Nwesp.Maui.Android.Hosting;

namespace Nwesp.Maui.Android.Samples
{
    public partial class App : Application
    {
        public App(AppShell shell)
        {
            InitializeComponent();

            MainPage = shell;
            RegisterRoute<PasswordPage>();
            this.ConfigureTextInputLayoutThemes();
        }

        private static void RegisterRoute<T>()
        {
            var name = typeof(T).Name;
            Routing.RegisterRoute(name, typeof(T));
        }
    }
}
