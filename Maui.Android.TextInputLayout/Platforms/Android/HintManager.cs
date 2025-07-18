using Android.Content.Res;
using Android.Views;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RResource = Android.Resource.Attribute;

namespace Maui.Android.TextInputLayout.Platforms.Android
{
    public static class HintManager
    {
        private static int[][] _states =
        [
            [-RResource.StateFocused],
            [RResource.StateFocused],
        ];

        private static int _defaultHintColor = 0;
        private static int _focusedHintColor = 0;

        public static void MapHint(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.Hint = entry.Hint;
        }

        public static void MapDefaultHintTextColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            _defaultHintColor = entry.DefaultHintColor.ToPlatform();
            ApplyHintColor(handler);
        }

        public static void MapFocusedHintTextColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            _focusedHintColor = entry.FocusedHintColor.ToPlatform();
            ApplyHintColor(handler);
        }

        private static void ApplyHintColor(ITextInputLayoutHandler handler)
        {
            ColorStateList colorStateList = new ColorStateList(_states, [_defaultHintColor, _focusedHintColor]);
            handler.PlatformView.DefaultHintTextColor = colorStateList;
        }

        public static void MapIsHintAnimated(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.ExpandedHintEnabled = entry.IsHintAnimated;
        }
    }
}
