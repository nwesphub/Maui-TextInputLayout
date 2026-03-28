using Android.Content.Res;
using Microsoft.Maui.Platform;
using Nwesp.Maui.Android.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nwesp.Maui.Android.Utilities
{
    public class ColorStateHelper
    {
        public static ColorStateList GetColorStateList(IStatefulColor textColor, bool isEnabled, bool hasFocus)
        {
            Color color;
            if (isEnabled)
            {
                if (hasFocus)
                {
                    color = textColor.FocusedColor;
                }
                else
                {
                    color = textColor.DefaultColor;
                }
            }
            else
            {
                color = textColor.DisabledColor.WithAlpha(textColor.DisabledOpacity);
            }

            return color.ToDefaultColorStateList();
        }

        public static ColorStateList GetSupportingTextColorStateList(ITextInputLayout layout, bool hasFocus)
        {
            return GetColorStateList(layout.SupportingTextColors, layout.IsEnabled, hasFocus);
        }
    }
}
