using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AColor = Android.Graphics.Color;

namespace Maui.Android.TextInputLayout.Platforms.Android.Helpers
{
    public static class ColorHelper
    {
        public static AColor GetDesaturatedColor(AColor color)
        {

            float[] hsv = new float[3];
            AColor.ColorToHSV(color, hsv);
            if (IsLightColor(hsv[1]))
            {
                // White / gray: darken instead of desaturate
                hsv[2] *= 0.75f;
            }
            else
            {
                hsv[1] *= 0.3f;
                hsv[2] *= 0.95f;
            }
            return AColor.HSVToColor(color.A, hsv);
        }

        private static bool IsLightColor(float hue)
        {
            return hue < 0.1f;
        }
    }
}
