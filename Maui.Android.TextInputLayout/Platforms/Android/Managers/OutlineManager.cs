using Android.Content.Res;
using Maui.Android.TextInputLayout.Platforms.Android.Utilities;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AResource = Android.Resource.Attribute;

namespace Maui.Android.TextInputLayout.Platforms.Android.Managers
{
    public static class OutlineManager
    {
        private static int[][] _states =
        [
            [-AResource.StateFocused, AResource.StateEnabled],
            [AResource.StateEnabled, AResource.StateFocused],
            [-AResource.StateEnabled],
        ];

        public static void ApplyOutlineColors(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            ColorStateList csl = new ColorStateList(
                _states,
                [
                    entry.OutlineColor.ToPlatform(), 
                    entry.FocusedOutlineColor.ToPlatform(),
                    entry.DisabledOutlineColor.WithAlpha(entry.DisabledOutlineOpacity).ToPlatform()
                ]
            );

            handler.PlatformView.SetBoxStrokeColorStateList(csl);
        }
    }
}
