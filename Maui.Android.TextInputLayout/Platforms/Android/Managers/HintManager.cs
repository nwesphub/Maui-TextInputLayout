using Android.Content.Res;
using Android.Views;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RResource = Android.Resource.Attribute;
using AColor = Android.Graphics.Color;
using Maui.Android.TextInputLayout.Platforms.Android.Helpers;

namespace Maui.Android.TextInputLayout.Platforms.Android.Managers
{
    public static class HintManager
    {
        private static int[][] _states =
        [
            [-RResource.StateFocused],
            [RResource.StateFocused],
        ];

        private static AColor _defaultHintColor;
        private static AColor _focusedHintColor;

        public static void MapHint(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.Hint = entry.Hint;
        }

        public static void MapDefaultHintTextColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            _defaultHintColor = entry.DefaultHintColor.ToPlatform();
            ApplyHintColor(handler, entry);
        }

        public static void MapFocusedHintTextColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            _focusedHintColor = entry.FocusedHintColor.ToPlatform();
            ApplyHintColor(handler, entry);
        }

        private static void ApplyHintColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            ColorStateList colorStateList;
            if (entry.IsEnabled)
            {
                colorStateList = new ColorStateList(_states, [_defaultHintColor, _focusedHintColor]);
            }
            else
            {
                colorStateList = new ColorStateList(_states, [ColorHelper.GetDesaturatedColor(_defaultHintColor), ColorHelper.GetDesaturatedColor(_focusedHintColor)]);
            }
            
            handler.PlatformView.DefaultHintTextColor = colorStateList;
        }

        public static void MapIsHintAnimated(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.ExpandedHintEnabled = entry.IsHintAnimated;
        }
    }
}
