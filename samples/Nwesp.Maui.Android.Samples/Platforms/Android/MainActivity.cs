using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.View;

namespace Nwesp.Maui.Android.Samples
{
    [Activity(Theme = "@style/NwespTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            WindowCompat.SetDecorFitsSystemWindows(Window, false);

            var content = FindViewById(global::Android.Resource.Id.Content);
            
            ViewCompat.SetOnApplyWindowInsetsListener(content, new WindowInsetsListener());
        }
    }

    public class WindowInsetsListener : Java.Lang.Object, IOnApplyWindowInsetsListener
    {
        public WindowInsetsCompat? OnApplyWindowInsets(global::Android.Views.View? v, WindowInsetsCompat? insets)
        {
            var systemBars = insets?.GetInsets(WindowInsetsCompat.Type.SystemBars());

            if (v is null || insets is null || systemBars is null)
            {
                return insets;
            }

            v.SetPadding(
                systemBars.Left,
                systemBars.Top,
                systemBars.Right,
                systemBars.Bottom);

            return insets;
        }
    }
}
