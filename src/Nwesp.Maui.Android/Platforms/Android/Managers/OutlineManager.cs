using Android.Content.Res;
using Microsoft.Maui.Platform;
using Nwesp.Maui.Android.Abstractions;
using Nwesp.Maui.Android.Models.Enums;
using Nwesp.Maui.Android.Utilities;
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
        public static void UpdateOutlineColor(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            int[][] _states =
            [
                [-AResource.StateFocused, AResource.StateEnabled],
                [AResource.StateEnabled, AResource.StateFocused],
                [-AResource.StateEnabled],
            ];

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

        public static void UpdateBoxBackgroundMode(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            switch (virtualView.BoxBackgroundMode)
            {
                case BoxBackgroundMode.None:
                    break;
                case BoxBackgroundMode.Outline:
                    platformView.BoxBackgroundMode = Google.Android.Material.TextField.TextInputLayout.BoxBackgroundOutline;
                    break;
                case BoxBackgroundMode.Filled:
                    platformView.BoxBackgroundMode = Google.Android.Material.TextField.TextInputLayout.BoxBackgroundFilled;
                    break;
            }
        }

        public static void UpdateBoxCornerRadius(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            var rect = virtualView.BoxStrokeCornerRadius;
            float density = DisplayHelper.GetDensity(platformView.Context);
            float topLeft = (int)(rect.TopLeft * density);
            float topRight = (int)(rect.TopRight * density);
            float bottomLeft = (int)(rect.BottomLeft * density);
            float bottomRight = (int)(rect.BottomRight * density);

            platformView.SetBoxCornerRadii(topLeft, topRight, bottomLeft, bottomRight);
        }

        public static void UpdateBoxStrokeWidth(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            int density = (int)Math.Floor(DisplayHelper.GetDensity(platformView.Context));
            int width = virtualView.BoxStrokeWidth * density;
            platformView.BoxStrokeWidth = (int)(width);
        }

        public static void UpdateBoxStrokeFocusedWidth(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            int density = (int)Math.Floor(DisplayHelper.GetDensity(platformView.Context));
            int width = virtualView.BoxStrokeFocusedWidth * density;
            platformView.BoxStrokeWidthFocused = width;
        }

        public static void UpdateBackgroundColor(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            int[][] states =
            [
                [AResource.StateEnabled],
                [-AResource.StateEnabled],
            ];

            int[] colors =
            [
                virtualView.BackgroundColor?.ToPlatform() ?? ThemeHelper.GetContainerColor(virtualView.BoxBackgroundMode).ToPlatform(),
                virtualView.DisabledBackgroundColor?.WithAlpha(virtualView.DisabledBackgroundColorOpacity).ToPlatform() ?? ThemeHelper.GetDisabledContainerColor(virtualView.BoxBackgroundMode).WithAlpha(ThemeHelper.GetDisabledContainerOpacity(virtualView.BoxBackgroundMode)).ToPlatform(),
            ];

            // Make sure the background tint is null for Filled mode.
            platformView.BackgroundTintList = Colors.Transparent.ToDefaultColorStateList();
            platformView.SetBoxBackgroundColorStateList(new ColorStateList(states, colors));
        }

        public static void UpdateErrorOutlineColor(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            platformView.BoxStrokeErrorColor = virtualView.ErrorOutlineColor.ToDefaultColorStateList();
        }
    }
}
