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
using Nwesp.Maui.Android.Utilities;
using static Android.Views.View;
using Nwesp.Maui.Android.Platforms.Android.Managers;
using ATextChangedEventArgs = Android.Text.TextChangedEventArgs;
using Android.Net;
using Android.Text.Style;
using Android.Text;
using ATypeFaceStyle = Android.Graphics.TypefaceStyle;
using AComplexUnitType = Android.Util.ComplexUnitType;

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
            int density = (int)Math.Floor(platformView.Context?.Resources?.DisplayMetrics?.Density ?? 2.75);
            int width = virtualView.BoxStrokeWidth * density;
            platformView.BoxStrokeWidth = (int)(width);
        }
        public static void UpdateBoxStrokeFocusedWidth(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            int density = (int)Math.Floor(platformView.Context?.Resources?.DisplayMetrics?.Density ?? 2.75);
            int width = virtualView.BoxStrokeFocusedWidth * density;
            platformView.BoxStrokeWidthFocused = width; 
        }

        public static void UpdatePrefixText(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            if (string.Equals(platformView.PrefixText, virtualView.Prefix, StringComparison.CurrentCulture))
            {
                return;
            }
            //var spannable = new SpannableString(virtualView.Prefix);
            //spannable.SetSpan(
            //    new StyleSpan(ATypeFaceStyle.Bold),
            //    0,
            //    virtualView.Prefix.Length,
            //    SpanTypes.ExclusiveExclusive);
            //platformView.PrefixTextFormatted = spannable;
            
            //float textSize = (float)(virtualView.MaterialEntry?.FontSize ?? 14f);
            //platformView.PrefixTextView.SetTextSize(AComplexUnitType.Dip, 16f);

            // Default prefix/suffix text size is 16. This returns 44. (16 * 2.75(density))
            //var textSize1 = platformView.PrefixTextView.TextSize;

            // No longer needed?
            // Prefix gets misaligned from input text.
            // platformView.Post(() =>
            // {
            platformView.PrefixText = virtualView.Prefix;
                platformView.InvalidateMeasure(virtualView);
           // });
            
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
            //float textSize = (float)(virtualView.MaterialEntry?.FontSize ?? 14f);
            //platformView.SuffixTextView.SetTextSize(AComplexUnitType.Dip, textSize);
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
                virtualView.BackgroundColor?.ToPlatform() ?? ThemeHelper.GetContainerColor(virtualView.BoxBackgroundMode).ToPlatform(),
                virtualView.DisabledBackgroundColor?.WithAlpha(virtualView.DisabledBackgroundColorOpacity).ToPlatform() ?? ThemeHelper.GetDisabledContainerColor(virtualView.BoxBackgroundMode).WithAlpha(ThemeHelper.GetDisabledContainerOpacity(virtualView.BoxBackgroundMode)).ToPlatform(),
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

        public static void TextInputLayoutFocusChanged(this MauiTextInputLayout platformView, ITextInputLayout virtualView, bool hasFocus)
        {
            if(virtualView is null)
            {
                return;
            }

            if (virtualView.EndIconVisibilityMode != IconVisibilityMode.WhileEditing &&
                virtualView.EndIconVisibilityMode != IconVisibilityMode.HasTextWhileEditing)
            {
                return;
            }

            if (virtualView.EndIconVisibilityMode == IconVisibilityMode.HasTextWhileEditing)
            {
                if (platformView.HasTextAndFocus(hasFocus))
                {
                    platformView.ShowEndIcon();
                }
                else
                {
                    platformView.HideEndIcon();
                }
            }
            else
            {
                if (hasFocus)
                {
                    platformView.ShowEndIcon();
                }
                else
                {
                    platformView.HideEndIcon();
                }
            }
        }

        public static void TextInputLayoutTextChanged(this MauiTextInputLayout platformView, ITextInputLayout virtualView, string? text)
        {
            if (virtualView is null)
            {
                return;
            }

            if (virtualView.EndIconVisibilityMode != IconVisibilityMode.HasText &&
                virtualView.EndIconVisibilityMode != IconVisibilityMode.HasTextWhileEditing)
            {
                return;
            }

            if (virtualView.EndIconVisibilityMode == IconVisibilityMode.HasTextWhileEditing)
            {
                if (platformView.HasTextAndFocus(platformView.HasFocus))
                {
                    platformView.ShowEndIcon();
                }
                else
                {
                    platformView.HideEndIcon();
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    platformView.ShowEndIcon();
                }
                else
                {
                    platformView.HideEndIcon();
                }
            }
        }
    }
}
