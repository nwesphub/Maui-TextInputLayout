using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Nwesp.Maui.Android.Samples
{
    [Activity(Theme = "@style/Theme.Material3.DayNight.NoActionBar", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}
