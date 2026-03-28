using Android.Content;
using System;
using System.Collections.Generic;
using System.Text;
using AView = Android.Views.View;
namespace Nwesp.Maui.Android.Utilities
{
    public static class DisplayHelper
    {
        public const int IconSize = 24;
        public const float DefaultDensity = 1f;
        public static float GetDensity(AView view)
        {
            return GetDensity(view.Context);
        }

        public static float GetDensity(Context? context)
        {
            return context?.Resources?.DisplayMetrics?.Density ?? DefaultDensity;
        }
    }
}
