using Android.Graphics.Drawables;
using Android.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nwesp.Maui.Android.Models.Enums;
using Nwesp.Maui.Android.Abstractions;
using Microsoft.Maui.Platform;
using Android.Content.Res;
using AResource = Android.Resource.Attribute;

namespace Nwesp.Maui.Android.Platforms.Android
{
    public static class MauiTextInputLayoutExtensions
    {
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
            float density = platformView.Context?.Resources?.DisplayMetrics?.Density ?? 2.75f;
            float topLeft = (int)(rect.TopLeft * density + 0.5f);
            float topRight = (int)(rect.TopRight * density + 0.5f);
            float bottomLeft = (int)(rect.BottomLeft * density + 0.5f);
            float bottomRight = (int)(rect.BottomRight * density + 0.5f);

            platformView.SetBoxCornerRadii(topLeft, topRight, bottomLeft, bottomRight);
        }

        public static void UpdateBoxStrokeWidth(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            platformView.BoxStrokeWidth = virtualView.BoxStrokeWidth;
        }
        public static void UpdateBoxStrokeFocusedWidth(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            platformView.BoxStrokeWidthFocused = virtualView.BoxStrokeFocusedWidth;
        }

        public static void UpdatePrefixText(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            if (string.Equals(platformView.PrefixText, virtualView.Prefix, StringComparison.CurrentCulture))
            {
                return;
            }

            // Prefix gets misaligned from input text.
            platformView.Post(() =>
            {
                platformView.PrefixText = virtualView.Prefix;
                platformView.InvalidateMeasure(virtualView);
            });
        }

        public static void UpdatePrefixTextColor(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            int[][] states =
            [
                [AResource.StateEnabled],
                [-AResource.StateEnabled]
            ];

            int[] colors =
            [
                virtualView.PrefixTextColor.ToPlatform(),
                virtualView.DisabledPrefixTextColor.WithAlpha(virtualView.DisabledPrefixTextColorOpacity).ToPlatform()
            ];
            platformView.PrefixTextColor = new ColorStateList(states, colors);
        }

        public static void UpdateSuffixText(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            if (string.Equals(platformView.SuffixText, virtualView.Suffix, StringComparison.CurrentCulture))
            {
                return;
            }

            platformView.Post(() =>
            {
                platformView.SuffixText = virtualView.Suffix;
                platformView.InvalidateMeasure(virtualView);
            });
        }

        public static void UpdateSuffixTextColor(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            int[][] states =
            [
                [AResource.StateEnabled],
                [-AResource.StateEnabled]
            ];

            int[] colors =
            [
                virtualView.SuffixTextColor.ToPlatform(),
                virtualView.DisabledSuffixTextColor.WithAlpha(virtualView.DisabledSuffixTextColorOpacity).ToPlatform()
            ];
            platformView.SuffixTextColor = new ColorStateList(states, colors);
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
                virtualView.BackgroundColor.ToPlatform(),
                virtualView.DisabledBackgroundColor.WithAlpha(virtualView.DisabledBackgroundColorOpacity).ToPlatform(),
            ];

            // Make sure the background tint is null for Filled mode.
            platformView.BackgroundTintList = Colors.Transparent.ToDefaultColorStateList();
            platformView.SetBoxBackgroundColorStateList(new ColorStateList(states, colors));
        }

        public static void UpdateSupportingText(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            platformView.HelperText = virtualView.SupportingText;
        }
        public static void UpdateErrorText(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            platformView.Error = virtualView.ErrorText;
        }

        public static void UpdateCounterEnabled(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            platformView.CounterEnabled = virtualView.CounterEnabled;
        }
        public static void UpdateCounterMaxLength(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            platformView.CounterMaxLength = virtualView.CounterMaxLength;
        }
        public static void UpdatePadding(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            var padding = virtualView.Padding;
            platformView.SetPadding((int)padding.Left, (int)padding.Top, (int)padding.Right, (int)padding.Bottom);
        }
    }
}
