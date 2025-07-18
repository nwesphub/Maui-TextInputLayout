using Android.Content.Res;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RResource = Android.Resource.Attribute;

namespace Maui.Android.TextInputLayout.Platforms.Android.Managers
{
    public static class BorderManager
    {
        private static int[][] _states =
        [
            [-RResource.StateFocused],
            [RResource.StateFocused],
        ];

        private static int _borderColor = 0;
        private static int _focusedBorderColor = 0;
        public static void MapBorderColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            _borderColor = entry.BorderColor.ToPlatform();
            ApplyBorderColors(handler);
        }

        public static void MapFocusedBorderColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            _focusedBorderColor = entry.FocusedBorderColor.ToPlatform();
            ApplyBorderColors(handler);
        }

        private static void ApplyBorderColors(ITextInputLayoutHandler handler)
        {
            ColorStateList csl = new ColorStateList(_states, [_borderColor, _focusedBorderColor]);

            handler.PlatformView.SetBoxStrokeColorStateList(csl);
        }
    }
}
