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
        public static ColorStateList GetColorStateList(IInteractiveColor textColor, bool isEnabled, bool hasFocus)
        {
            Color color = textColor.DefaultColor;
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
            else if(textColor is IDisabledColor disabledColor)
            {
                color = disabledColor.DisabledColor.WithAlpha(disabledColor.DisabledOpacity);
            }

            return color.ToDefaultColorStateList();
        }

        public static ColorStateList GetSupportingTextColorStateList(ITextInputLayout layout, bool hasFocus)
        {
            return GetColorStateList(layout.SupportingTextColors, layout.IsEnabled, hasFocus);
        }

        public static ColorStateList GetCounterOverflowTextColorStateList(ITextInputLayout layout, bool hasFocus)
        {
            return GetColorStateList(layout.CounterOverflowTextColors, layout.IsEnabled, hasFocus);
        }
    }
}
