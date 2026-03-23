using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Internal;
using Google.Android.Material.TextField;
using Java.Lang;
using Nwesp.Maui.Android.Models.Enums;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using AView = Android.Views.View;
using LLayout = Android.Widget.LinearLayout;
using AResource = Android.Resource.Attribute;
using ASound = Android.Views.SoundEffects;
using Nwesp.Maui.Android.Abstractions;
using Nwesp.Maui.Android.Controls;
using AndroidX.AppCompat.Widget;
namespace Nwesp.Maui.Android.Platforms.Android
{
    public class MauiTextInputLayout : Google.Android.Material.TextField.TextInputLayout
    {
        public EndIconMode CustomEndIconMode { get; set; }
        public bool IsPassword { get; set; }
        public bool HasTextAndFocus(bool hasFocus)
        {
            return hasFocus && !string.IsNullOrWhiteSpace(EditText?.Text);
        }

        public MauiTextInputLayout(Context context) : base(context)
        {
            var density = Context?.Resources?.DisplayMetrics?.Density ?? 2.75;

            // Update: No longer needed? Hack. For some reason when the box background mode is set to filled, the hint is positioned too high when focused and/or has text
            //BoxCollapsedPaddingTop = (int)(8 * density);

            var endIcon = this.FindViewById<AppCompatImageButton>(Resource.Id.text_input_end_icon);
            if (endIcon is null)
            {
                return;
            }

            // Hack. The following are workarounds for various issues with the end icon.
            // 1. Icon initially visible before focus state is applied
            // 2. Border shifting when navigating forms if the icon starts hidden
            // 3. End icon occasionally receiving focus during keyboard navigation

            // Make icon invisible with alpha before we toggle visibility (1)
            endIcon.Alpha = 0f;

            // Use custom mode to prevent default end icon behavior (2)
            EndIconMode = EndIconCustom;

            // Toggle visibility to trigger layout changes (1)
            EndIconVisible = true;

            // Queue on UI thread (2)
            Post(() =>
            {
                // Prevent the end icon from receiving focus (3)
                endIcon.Focusable = false;
                endIcon.FocusableInTouchMode = false;

                // Hide the icon after the layout is fixed (2)
                EndIconVisible = false;

                // Make icon visible again with alpha (1)
                endIcon.Alpha = 1f;
            });
        }
    }
}
