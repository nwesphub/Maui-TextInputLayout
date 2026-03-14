using Android.Content.Res;
using Microsoft.Maui.Platform;
using Nwesp.Maui.Android.Abstractions;
using Nwesp.Maui.Android.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AResource = Android.Resource.Attribute;

namespace Nwesp.Maui.Android.Platforms.Android.Managers
{
    public static class OutlineManager
    {
        private static int[][] _states =
        [
            [-AResource.StateFocused, AResource.StateEnabled],
            [AResource.StateEnabled, AResource.StateFocused],
            [-AResource.StateEnabled],
        ];

        public static void UpdateOutlineColor(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            ColorStateList csl = new ColorStateList(
                _states,
                [
                    virtualView.OutlineColor.ToPlatform(),
                    virtualView.FocusedOutlineColor.ToPlatform(),
                    virtualView.DisabledOutlineColor.WithAlpha(virtualView.DisabledOutlineOpacity).ToPlatform()
                ]
            );

            platformView.SetBoxStrokeColorStateList(csl);
        }

        public static BoxBackgroundMode ParseBoxBackgroundMode(IView view)
        {
            return (view as IMaterialEntry)?.BoxBackgroundMode ?? BoxBackgroundMode.None;
        }
    }
}
