using Nwesp.Maui.Android.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nwesp.Maui.Android.Hosting
{
    public static class AppExtensions
    {
        public static void ConfigureTextInputLayoutThemes(this Application app)
        {
            if (app.PlatformAppTheme == AppTheme.Light)
            {
                app.Resources.MergedDictionaries.Add(new LightTheme());
            }
            else if (app.PlatformAppTheme == AppTheme.Dark)
            {
                app.Resources.MergedDictionaries.Add(new DarkTheme());
            }

            app.RequestedThemeChanged += (object? sender, AppThemeChangedEventArgs e) =>
            {
                if (e.RequestedTheme == AppTheme.Light)
                {
                    var foundDictionary = app.Resources.MergedDictionaries.FirstOrDefault(x => x.GetType() == typeof(DarkTheme));
                    if (foundDictionary is not null)
                    {
                        app.Resources.MergedDictionaries.Remove(foundDictionary);
                    }
                    app.Resources.MergedDictionaries.Add(new LightTheme());
                }
                else if (e.RequestedTheme == AppTheme.Dark)
                {
                    var foundDictionary = app.Resources.MergedDictionaries.FirstOrDefault(x => x.GetType() == typeof(LightTheme));
                    if (foundDictionary is not null)
                    {
                        app.Resources.MergedDictionaries.Remove(foundDictionary);
                    }
                    app.Resources.MergedDictionaries.Add(new DarkTheme());
                }
            };
        }
    }
}
