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
using Maui.Android.TextInputLayout.Platforms.Android.Utilities;


namespace Maui.Android.TextInputLayout.Platforms.Android.Managers
{
    public static class HintManager
    {
        private static int[][] _states = Constants.GetCommonStates();
        public static void MapHint(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.Hint = entry.Hint;
        }
  
        public static void ApplyHintColors(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.DefaultHintTextColor = new ColorStateList(
                _states, 
                [
                    entry.DisabledHintColor.WithAlpha(entry.DisabledHintOpacity).ToPlatform(),
                    entry.FocusedHintColor.ToPlatform(), 
                    entry.DefaultHintColor.ToPlatform()
                ]
            );
        }

        public static void MapIsHintAnimated(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.ExpandedHintEnabled = entry.IsHintAnimated;
        }
    }
}
