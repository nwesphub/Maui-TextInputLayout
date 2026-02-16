using Maui.Android.TextInputLayout.Models.Enums;
using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout.Utilities
{
    public static class ThemeHelper
    {
  
        // ==================== Container ====================
        public static Color GetContainerColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ContainerColor,
                BoxBackgroundMode.Outline => null,
                _ => Colors.Transparent
            };

        public static double GetContainerHeight(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ContainerHeight,
                BoxBackgroundMode.Outline => Outlined.ContainerHeight,
                _ => 0
            };

        public static object GetContainerShape(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ContainerShape,
                BoxBackgroundMode.Outline => Outlined.ContainerShape,
                _ => null
            };

        // ==================== Label text ====================
        public static Color GetLabelTextColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.LabelTextColor,
                BoxBackgroundMode.Outline => Outlined.LabelTextColor,
                _ => Colors.Transparent
            };

        public static string GetLabelFont(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.LabelFont,
                BoxBackgroundMode.Outline => Outlined.LabelFont,
                _ => null
            };

        public static double GetLabelLineHeight(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.LabelLineHeight,
                BoxBackgroundMode.Outline => Outlined.LabelLineHeight,
                _ => 0
            };

        public static double GetLabelSize(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.LabelSize,
                BoxBackgroundMode.Outline => Outlined.LabelSize,
                _ => 0
            };

        public static int GetLabelWeight(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.LabelWeight,
                BoxBackgroundMode.Outline => Outlined.LabelWeight,
                _ => 0
            };

        public static double GetLabelTracking(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.LabelTracking,
                BoxBackgroundMode.Outline => Outlined.LabelTracking,
                _ => 0
            };

        public static string GetLabelType(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.LabelType,
                BoxBackgroundMode.Outline => Outlined.LabelType,
                _ => null
            };

        public static double GetLabelPopulatedLineHeight(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.LabelPopulatedLineHeight,
                BoxBackgroundMode.Outline => Outlined.LabelPopulatedLineHeight,
                _ => 0
            };

        public static double GetLabelPopulatedSize(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.LabelPopulatedSize,
                BoxBackgroundMode.Outline => Outlined.LabelPopulatedSize,
                _ => 0
            };

        // ==================== Leading icon ====================
        public static Color GetLeadingIconColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.LeadingIconColor,
                BoxBackgroundMode.Outline => Outlined.LeadingIconColor,
                _ => Colors.Transparent
            };

        public static double GetLeadingIconSize(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.LeadingIconSize,
                BoxBackgroundMode.Outline => Outlined.LeadingIconSize,
                _ => 0
            };

        // ==================== Trailing icon ====================
        public static Color GetTrailingIconColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.TrailingIconColor,
                BoxBackgroundMode.Outline => Outlined.TrailingIconColor,
                _ => Colors.Transparent
            };

        public static double GetTrailingIconSize(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.TrailingIconSize,
                BoxBackgroundMode.Outline => Outlined.TrailingIconSize,
                _ => 0
            };

        // ==================== Active indicator / Outline ====================
        public static double GetActiveIndicatorHeight(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ActiveIndicatorHeight,
                BoxBackgroundMode.Outline => Outlined.FocusIndicatorThickness,
                _ => 0
            };

        public static Color GetActiveIndicatorColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ActiveIndicatorColor,
                BoxBackgroundMode.Outline => Outlined.FocusIndicatorColor,
                _ => Colors.Transparent
            };

        // ==================== Supporting text ====================
        public static Color GetSupportingTextColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.SupportingTextColor,
                BoxBackgroundMode.Outline => Outlined.SupportingTextColor,
                _ => Colors.Transparent
            };

        public static string GetSupportingTextFont(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.SupportingTextFont,
                BoxBackgroundMode.Outline => Outlined.SupportingTextFont,
                _ => null
            };

        public static double GetSupportingTextLineHeight(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.SupportingTextLineHeight,
                BoxBackgroundMode.Outline => Outlined.SupportingTextLineHeight,
                _ => 0
            };

        public static double GetSupportingTextSize(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.SupportingTextSize,
                BoxBackgroundMode.Outline => Outlined.SupportingTextSize,
                _ => 0
            };

        public static int GetSupportingTextWeight(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.SupportingTextWeight,
                BoxBackgroundMode.Outline => Outlined.SupportingTextWeight,
                _ => 0
            };

        public static double GetSupportingTextTracking(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.SupportingTextTracking,
                BoxBackgroundMode.Outline => Outlined.SupportingTextTracking,
                _ => 0
            };

        // ==================== Input text ====================
        public static Color GetInputTextColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.InputTextColor,
                BoxBackgroundMode.Outline => Outlined.InputTextColor,
                _ => Colors.Transparent
            };

        public static string GetInputTextFont(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.InputTextFont,
                BoxBackgroundMode.Outline => Outlined.InputTextFont,
                _ => null
            };

        public static double GetInputTextLineHeight(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.InputTextLineHeight,
                BoxBackgroundMode.Outline => Outlined.InputTextLineHeight,
                _ => 0
            };

        public static double GetInputTextSize(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.InputTextSize,
                BoxBackgroundMode.Outline => Outlined.InputTextSize,
                _ => 0
            };

        public static int GetInputTextWeight(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.InputTextWeight,
                BoxBackgroundMode.Outline => Outlined.InputTextWeight,
                _ => 0
            };

        public static double GetInputTextTracking(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.InputTextTracking,
                BoxBackgroundMode.Outline => Outlined.InputTextTracking,
                _ => 0
            };

        public static Color GetInputTextPrefixColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.InputTextPrefixColor,
                BoxBackgroundMode.Outline => Outlined.InputTextPrefixColor,
                _ => Colors.Transparent
            };

        public static Color GetInputTextSuffixColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.InputTextSuffixColor,
                BoxBackgroundMode.Outline => Outlined.InputTextSuffixColor,
                _ => Colors.Transparent
            };

        public static Color GetInputTextPlaceholderColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.InputTextPlaceholderColor,
                BoxBackgroundMode.Outline => Outlined.InputTextPlaceholderColor,
                _ => Colors.Transparent
            };

        // ==================== Caret ====================
        public static Color GetCaretColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.CaretColor,
                BoxBackgroundMode.Outline => Outlined.CaretColor,
                _ => Colors.Transparent
            };

        public static Color GetErrorFocusCaretColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ErrorFocusedCaretColor,
                BoxBackgroundMode.Outline => Outlined.ErrorFocusCaretColor,
                _ => Colors.Transparent
            };

        // ==================== Outline (Outlined only) ====================
        public static double GetOutlineWidth(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Outline => Outlined.OutlineWidth,
                _ => 0
            };

        public static Color GetOutlineColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ActiveIndicatorColor,
                BoxBackgroundMode.Outline => Outlined.OutlineColor,
                _ => Colors.Transparent
            };

        // ==================== Focus indicator ====================
        public static Color GetFocusIndicatorColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.FocusedActiveIndicatorColor,
                BoxBackgroundMode.Outline => Outlined.FocusedOutlineColor,
                _ => Colors.Transparent
            };

        public static double GetFocusIndicatorThickness(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Outline => Outlined.FocusIndicatorThickness,
                _ => 0
            };

        // ==================== Error colors ====================
        public static Color GetErrorLabelTextColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ErrorLabelTextColor,
                BoxBackgroundMode.Outline => Outlined.ErrorLabelTextColor,
                _ => Colors.Transparent
            };

        public static Color GetErrorInputTextColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ErrorInputTextColor,
                BoxBackgroundMode.Outline => Outlined.ErrorInputTextColor,
                _ => Colors.Transparent
            };

        public static Color GetErrorSupportingTextColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ErrorSupportingTextColor,
                BoxBackgroundMode.Outline => Outlined.ErrorSupportingTextColor,
                _ => Colors.Transparent
            };

        public static Color GetErrorLeadingIconColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ErrorLeadingIconColor,
                BoxBackgroundMode.Outline => Outlined.ErrorLeadingIconColor,
                _ => Colors.Transparent
            };

        public static Color GetErrorTrailingIconColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ErrorTrailingIconColor,
                BoxBackgroundMode.Outline => Outlined.ErrorTrailingIconColor,
                _ => Colors.Transparent
            };

        // ==================== Disabled / Container ====================
        public static Color GetDisabledContainerColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledContainerColor,
                BoxBackgroundMode.Outline => null, // outlined text-field container usually transparent
                _ => Colors.Transparent
            };

        public static double GetDisabledContainerOpacity(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledContainerOpacity,
                BoxBackgroundMode.Outline => 1.0, // no opacity for outlined
                _ => 1.0
            };

        // ==================== Disabled / Label text ====================
        public static Color GetDisabledLabelTextColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledLabelTextColor,
                BoxBackgroundMode.Outline => Outlined.DisabledLabelTextColor,
                _ => Colors.Transparent
            };

        public static double GetDisabledLabelTextOpacity(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledLabelTextOpacity,
                BoxBackgroundMode.Outline => Outlined.DisabledLabelTextOpacity,
                _ => 1.0
            };

        // ==================== Disabled / Leading icon ====================
        public static Color GetDisabledLeadingIconColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledLeadingIconColor,
                BoxBackgroundMode.Outline => Outlined.DisabledLeadingIconColor,
                _ => Colors.Transparent
            };

        public static double GetDisabledLeadingIconOpacity(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledLeadingIconOpacity,
                BoxBackgroundMode.Outline => Outlined.DisabledLeadingIconOpacity,
                _ => 1.0
            };

        // ==================== Disabled / Trailing icon ====================
        public static Color GetDisabledTrailingIconColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledTrailingIconColor,
                BoxBackgroundMode.Outline => Outlined.DisabledTrailingIconColor,
                _ => Colors.Transparent
            };

        public static double GetDisabledTrailingIconOpacity(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledTrailingIconOpacity,
                BoxBackgroundMode.Outline => Outlined.DisabledTrailingIconOpacity,
                _ => 1.0
            };

        // ==================== Disabled / Supporting text ====================
        public static Color GetDisabledSupportingTextColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledSupportingTextColor,
                BoxBackgroundMode.Outline => Outlined.DisabledSupportingTextColor,
                _ => Colors.Transparent
            };

        public static double GetDisabledSupportingTextOpacity(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledSupportingTextOpacity,
                BoxBackgroundMode.Outline => Outlined.DisabledSupportingTextOpacity,
                _ => 1.0
            };

        // ==================== Disabled / Input text ====================
        public static Color GetDisabledInputTextColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledInputTextColor,
                BoxBackgroundMode.Outline => Outlined.DisabledInputTextColor,
                _ => Colors.Transparent
            };

        public static double GetDisabledInputTextOpacity(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledInputTextOpacity,
                BoxBackgroundMode.Outline => Outlined.DisabledInputTextOpacity,
                _ => 1.0
            };

        // ==================== Disabled / Active indicator ====================
        public static double GetDisabledActiveIndicatorHeight(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledActiveIndicatorHeight,
                BoxBackgroundMode.Outline => Outlined.DisabledOutlineWidth, // Outlined uses outline instead of filled active indicator
                _ => 0
            };

        public static Color GetDisabledActiveIndicatorColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledActiveIndicatorColor,
                BoxBackgroundMode.Outline => Outlined.DisabledOutlineColor,
                _ => Colors.Transparent
            };

        public static double GetDisabledActiveIndicatorOpacity(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledActiveIndicatorOpacity,
                BoxBackgroundMode.Outline => Outlined.DisabledOutlineOpacity,
                _ => 1.0
            };

        // ==================== Focused / Label text ====================
        public static Color GetFocusedLabelTextColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.FocusedLabelTextColor,
                BoxBackgroundMode.Outline => Outlined.FocusedLabelTextColor,
                _ => Colors.Transparent
            };

        // ==================== Focused / Leading icon ====================
        public static Color GetFocusedLeadingIconColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.FocusedLeadingIconColor,
                BoxBackgroundMode.Outline => Outlined.FocusedLeadingIconColor,
                _ => Colors.Transparent
            };

        // ==================== Focused / Trailing icon ====================
        public static Color GetFocusedTrailingIconColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.FocusedTrailingIconColor,
                BoxBackgroundMode.Outline => Outlined.FocusedTrailingIconColor,
                _ => Colors.Transparent
            };

        // ==================== Focused / Input text ====================
        public static Color GetFocusedInputTextColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.FocusedInputTextColor,
                BoxBackgroundMode.Outline => Outlined.FocusedInputTextColor,
                _ => Colors.Transparent
            };

        // ==================== Focused / Supporting text ====================
        public static Color GetFocusedSupportingTextColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.FocusedSupportingTextColor,
                BoxBackgroundMode.Outline => Outlined.FocusedSupportingTextColor,
                _ => Colors.Transparent
            };

        // ==================== Focused / Active indicator ====================
        public static double GetFocusedActiveIndicatorHeight(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.FocusedActiveIndicatorHeight,
                BoxBackgroundMode.Outline => Outlined.FocusedOutlineWidth,
                _ => 0
            };

        public static Color GetFocusedActiveIndicatorColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.FocusedActiveIndicatorColor,
                BoxBackgroundMode.Outline => Outlined.FocusedOutlineColor,
                _ => Colors.Transparent
            };

        public static Color GetFocusedOutlineColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.FocusedActiveIndicatorColor,
                BoxBackgroundMode.Outline => Outlined.FocusedOutlineColor,
                _ => Colors.Transparent
            };
        public static Color GetDisabledOutlineColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.DisabledActiveIndicatorColor,
                BoxBackgroundMode.Outline => Outlined.DisabledOutlineColor,
                _ => Colors.Transparent
            };
        public static double GetFocusedActiveIndicatorThickness(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.FocusedActiveIndicatorThickness,
                BoxBackgroundMode.Outline => Outlined.FocusIndicatorThickness,
                _ => 0
            };

        // ==================== Error / Focus ====================
        public static Color GetErrorFocusedActiveIndicatorColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ErrorFocusedActiveIndicatorColor,
                BoxBackgroundMode.Outline => Outlined.ErrorFocusOutlineColor,
                _ => Colors.Transparent
            };

        public static Color GetErrorFocusedLabelTextColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ErrorFocusedLabelTextColor,
                BoxBackgroundMode.Outline => Outlined.ErrorFocusLabelTextColor,
                _ => Colors.Transparent
            };

        public static Color GetErrorFocusedInputTextColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ErrorFocusedInputTextColor,
                BoxBackgroundMode.Outline => Outlined.ErrorFocusInputTextColor,
                _ => Colors.Transparent
            };

        public static Color GetErrorFocusedSupportingTextColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ErrorFocusedSupportingTextColor,
                BoxBackgroundMode.Outline => Outlined.ErrorFocusSupportingTextColor,
                _ => Colors.Transparent
            };

        public static Color GetErrorFocusedLeadingIconColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ErrorFocusedLeadingIconColor,
                BoxBackgroundMode.Outline => Outlined.ErrorFocusLeadingIconColor,
                _ => Colors.Transparent
            };

        public static Color GetErrorFocusedTrailingIconColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ErrorFocusedTrailingIconColor,
                BoxBackgroundMode.Outline => Outlined.ErrorFocusTrailingIconColor,
                _ => Colors.Transparent
            };

        public static Color GetErrorFocusedCaretColor(BoxBackgroundMode mode) =>
            mode switch
            {
                BoxBackgroundMode.Filled => Filled.ErrorFocusedCaretColor,
                BoxBackgroundMode.Outline => Outlined.ErrorFocusCaretColor,
                _ => Colors.Transparent
            };
        public static class Filled
        {
            // ==================== Enabled / Container ====================
            public static Color ContainerColor => (Color)Application.Current.Resources["md.comp.filled-text-field.container.color"];
            public static double ContainerHeight => (double)Application.Current.Resources["md.comp.filled-text-field.container.height"];
            public static Thickness ContainerShape => (Thickness)Application.Current.Resources["md.comp.filled-text-field.container.shape"]; // RoundRectangle

            // ==================== Enabled / Label text ====================
            public static Color LabelTextColor => (Color)Application.Current.Resources["md.comp.filled-text-field.label-text.color"];
            public static string LabelFont => (string)Application.Current.Resources["md.comp.filled-text-field.label-text.font"];
            public static double LabelLineHeight => (double)Application.Current.Resources["md.comp.filled-text-field.label-text.line-height"];
            public static double LabelSize => (double)Application.Current.Resources["md.comp.filled-text-field.label-text.size"];
            public static int LabelWeight => (int)Application.Current.Resources["md.comp.filled-text-field.label-text.weight"];
            public static double LabelTracking => (double)Application.Current.Resources["md.comp.filled-text-field.label-text.tracking"];
            public static string LabelType => (string)Application.Current.Resources["md.comp.filled-text-field.label-text.type"];
            public static double LabelPopulatedLineHeight => (double)Application.Current.Resources["md.comp.filled-text-field.label-text.populated.line-height"];
            public static double LabelPopulatedSize => (double)Application.Current.Resources["md.comp.filled-text-field.label-text.populated.size"];

            // ==================== Enabled / Leading icon ====================
            public static Color LeadingIconColor => (Color)Application.Current.Resources["md.comp.filled-text-field.leading-icon.color"];
            public static double LeadingIconSize => (double)Application.Current.Resources["md.comp.filled-text-field.leading-icon.size"];

            // ==================== Enabled / Trailing icon ====================
            public static Color TrailingIconColor => (Color)Application.Current.Resources["md.comp.filled-text-field.trailing-icon.color"];
            public static double TrailingIconSize => (double)Application.Current.Resources["md.comp.filled-text-field.trailing-icon.size"];

            // ==================== Enabled / Active indicator ====================
            public static double ActiveIndicatorHeight => (double)Application.Current.Resources["md.comp.filled-text-field.active-indicator.height"];
            public static Color ActiveIndicatorColor => (Color)Application.Current.Resources["md.comp.filled-text-field.active-indicator.color"];

            // ==================== Enabled / Supporting text ====================
            public static Color SupportingTextColor => (Color)Application.Current.Resources["md.comp.filled-text-field.supporting-text.color"];
            public static string SupportingTextFont => (string)Application.Current.Resources["md.comp.filled-text-field.supporting-text.font"];
            public static double SupportingTextLineHeight => (double)Application.Current.Resources["md.comp.filled-text-field.supporting-text.line-height"];
            public static double SupportingTextSize => (double)Application.Current.Resources["md.comp.filled-text-field.supporting-text.size"];
            public static int SupportingTextWeight => (int)Application.Current.Resources["md.comp.filled-text-field.supporting-text.weight"];
            public static double SupportingTextTracking => (double)Application.Current.Resources["md.comp.filled-text-field.supporting-text.tracking"];

            // ==================== Enabled / Input text ====================
            public static Color InputTextColor => (Color)Application.Current.Resources["md.comp.filled-text-field.input-text.color"];
            public static string InputTextFont => (string)Application.Current.Resources["md.comp.filled-text-field.input-text.font"];
            public static double InputTextLineHeight => (double)Application.Current.Resources["md.comp.filled-text-field.input-text.line-height"];
            public static double InputTextSize => (double)Application.Current.Resources["md.comp.filled-text-field.input-text.size"];
            public static int InputTextWeight => (int)Application.Current.Resources["md.comp.filled-text-field.input-text.weight"];
            public static double InputTextTracking => (double)Application.Current.Resources["md.comp.filled-text-field.input-text.tracking"];
            public static Color InputTextPrefixColor => (Color)Application.Current.Resources["md.comp.filled-text-field.input-text.prefix.color"];
            public static Color InputTextSuffixColor => (Color)Application.Current.Resources["md.comp.filled-text-field.input-text.suffix.color"];
            public static Color InputTextPlaceholderColor => (Color)Application.Current.Resources["md.comp.filled-text-field.input-text.placeholder.color"];

            // ==================== Enabled / Caret ====================
            public static Color CaretColor => (Color)Application.Current.Resources["md.comp.filled-text-field.caret.color"];

            // ==================== Disabled / Container ====================
            public static Color DisabledContainerColor => (Color)Application.Current.Resources["md.comp.filled-text-field.disabled.container.color"];
            public static double DisabledContainerOpacity => (double)Application.Current.Resources["md.comp.filled-text-field.disabled.container.opacity"];

            // ==================== Disabled / Label text ====================
            public static Color DisabledLabelTextColor => (Color)Application.Current.Resources["md.comp.filled-text-field.disabled.label-text.color"];
            public static double DisabledLabelTextOpacity => (double)Application.Current.Resources["md.comp.filled-text-field.disabled.label-text.opacity"];

            // ==================== Disabled / Leading icon ====================
            public static Color DisabledLeadingIconColor => (Color)Application.Current.Resources["md.comp.filled-text-field.disabled.leading-icon.color"];
            public static double DisabledLeadingIconOpacity => (double)Application.Current.Resources["md.comp.filled-text-field.disabled.leading-icon.opacity"];

            // ==================== Disabled / Trailing icon ====================
            public static Color DisabledTrailingIconColor => (Color)Application.Current.Resources["md.comp.filled-text-field.disabled.trailing-icon.color"];
            public static double DisabledTrailingIconOpacity => (double)Application.Current.Resources["md.comp.filled-text-field.disabled.trailing-icon.opacity"];

            // ==================== Disabled / Supporting text ====================
            public static Color DisabledSupportingTextColor => (Color)Application.Current.Resources["md.comp.filled-text-field.disabled.supporting-text.color"];
            public static double DisabledSupportingTextOpacity => (double)Application.Current.Resources["md.comp.filled-text-field.disabled.supporting-text.opacity"];

            // ==================== Disabled / Input text ====================
            public static Color DisabledInputTextColor => (Color)Application.Current.Resources["md.comp.filled-text-field.disabled.input-text.color"];
            public static double DisabledInputTextOpacity => (double)Application.Current.Resources["md.comp.filled-text-field.disabled.input-text.opacity"];

            // ==================== Disabled / Active indicator ====================
            public static double DisabledActiveIndicatorHeight => (double)Application.Current.Resources["md.comp.filled-text-field.disabled.active-indicator.height"];
            public static Color DisabledActiveIndicatorColor => (Color)Application.Current.Resources["md.comp.filled-text-field.disabled.active-indicator.color"];
            public static double DisabledActiveIndicatorOpacity => (double)Application.Current.Resources["md.comp.filled-text-field.disabled.active-indicator.opacity"];

            // ==================== Focused / Label text ====================
            public static Color FocusedLabelTextColor => (Color)Application.Current.Resources["md.comp.filled-text-field.focus.label-text.color"];

            // ==================== Focused / Leading icon ====================
            public static Color FocusedLeadingIconColor => (Color)Application.Current.Resources["md.comp.filled-text-field.focus.leading-icon.color"];

            // ==================== Focused / Trailing icon ====================
            public static Color FocusedTrailingIconColor => (Color)Application.Current.Resources["md.comp.filled-text-field.focus.trailing-icon.color"];

            // ==================== Focused / Input text ====================
            public static Color FocusedInputTextColor => (Color)Application.Current.Resources["md.comp.filled-text-field.focus.input-text.color"];

            // ==================== Focused / Supporting text ====================
            public static Color FocusedSupportingTextColor => (Color)Application.Current.Resources["md.comp.filled-text-field.focus.supporting-text.color"];

            // ==================== Focused / Active indicator ====================
            public static double FocusedActiveIndicatorHeight => (double)Application.Current.Resources["md.comp.filled-text-field.focus.active-indicator.height"];
            public static Color FocusedActiveIndicatorColor => (Color)Application.Current.Resources["md.comp.filled-text-field.focus.active-indicator.color"];
            public static double FocusedActiveIndicatorThickness => (double)Application.Current.Resources["md.comp.filled-text-field.focus.active-indicator.thickness"];

            // ==================== Error ====================
            public static Color ErrorActiveIndicatorColor => (Color)Application.Current.Resources["md.comp.filled-text-field.error.active-indicator.color"];
            public static Color ErrorLabelTextColor => (Color)Application.Current.Resources["md.comp.filled-text-field.error.label-text.color"];
            public static Color ErrorInputTextColor => (Color)Application.Current.Resources["md.comp.filled-text-field.error.input-text.color"];
            public static Color ErrorSupportingTextColor => (Color)Application.Current.Resources["md.comp.filled-text-field.error.supporting-text.color"];
            public static Color ErrorLeadingIconColor => (Color)Application.Current.Resources["md.comp.filled-text-field.error.leading-icon.color"];
            public static Color ErrorTrailingIconColor => (Color)Application.Current.Resources["md.comp.filled-text-field.error.trailing-icon.color"];

            // ==================== Error / Focus ====================
            public static Color ErrorFocusedActiveIndicatorColor => (Color)Application.Current.Resources["md.comp.filled-text-field.error.focus.active-indicator.color"];
            public static Color ErrorFocusedLabelTextColor => (Color)Application.Current.Resources["md.comp.filled-text-field.error.focus.label-text.color"];
            public static Color ErrorFocusedInputTextColor => (Color)Application.Current.Resources["md.comp.filled-text-field.error.focus.input-text.color"];
            public static Color ErrorFocusedSupportingTextColor => (Color)Application.Current.Resources["md.comp.filled-text-field.error.focus.supporting-text.color"];
            public static Color ErrorFocusedLeadingIconColor => (Color)Application.Current.Resources["md.comp.filled-text-field.error.focus.leading-icon.color"];
            public static Color ErrorFocusedTrailingIconColor => (Color)Application.Current.Resources["md.comp.filled-text-field.error.focus.trailing-icon.color"];
            public static Color ErrorFocusedCaretColor => (Color)Application.Current.Resources["md.comp.filled-text-field.error.focus.caret.color"];
        }

        public static class Outlined
        {
            // ==================== Enabled / Container ====================
            public static double ContainerHeight => (double)Application.Current.Resources["md.comp.outlined-text-field.container.height"];
            public static object ContainerShape => Application.Current.Resources["md.comp.outlined-text-field.container.shape"]; // RoundRectangle

            // ==================== Enabled / Outline ====================
            public static double OutlineWidth => (double)Application.Current.Resources["md.comp.outlined-text-field.outline.width"];
            public static Color OutlineColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.outline.color"];

            // ==================== Enabled / Label text ====================
            public static Color LabelTextColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.label-text.color"];
            public static string LabelFont => (string)Application.Current.Resources["md.comp.outlined-text-field.label-text.font"];
            public static double LabelLineHeight => (double)Application.Current.Resources["md.comp.outlined-text-field.label-text.line-height"];
            public static double LabelSize => (double)Application.Current.Resources["md.comp.outlined-text-field.label-text.size"];
            public static int LabelWeight => (int)Application.Current.Resources["md.comp.outlined-text-field.label-text.weight"];
            public static double LabelTracking => (double)Application.Current.Resources["md.comp.outlined-text-field.label-text.tracking"];
            public static string LabelType => (string)Application.Current.Resources["md.comp.outlined-text-field.label-text.type"];
            public static double LabelPopulatedLineHeight => (double)Application.Current.Resources["md.comp.outlined-text-field.label-text.populated.line-height"];
            public static double LabelPopulatedSize => (double)Application.Current.Resources["md.comp.outlined-text-field.label-text.populated.size"];

            // ==================== Enabled / Leading icon ====================
            public static Color LeadingIconColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.leading-icon.color"];
            public static double LeadingIconSize => (double)Application.Current.Resources["md.comp.outlined-text-field.leading-icon.size"];

            // ==================== Enabled / Trailing icon ====================
            public static Color TrailingIconColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.trailing-icon.color"];
            public static double TrailingIconSize => (double)Application.Current.Resources["md.comp.outlined-text-field.trailing-icon.size"];

            // ==================== Enabled / Supporting text ====================
            public static Color SupportingTextColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.supporting-text.color"];
            public static string SupportingTextFont => (string)Application.Current.Resources["md.comp.outlined-text-field.supporting-text.font"];
            public static double SupportingTextLineHeight => (double)Application.Current.Resources["md.comp.outlined-text-field.supporting-text.line-height"];
            public static double SupportingTextSize => (double)Application.Current.Resources["md.comp.outlined-text-field.supporting-text.size"];
            public static int SupportingTextWeight => (int)Application.Current.Resources["md.comp.outlined-text-field.supporting-text.weight"];
            public static double SupportingTextTracking => (double)Application.Current.Resources["md.comp.outlined-text-field.supporting-text.tracking"];

            // ==================== Enabled / Input text ====================
            public static Color InputTextColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.input-text.color"];
            public static string InputTextFont => (string)Application.Current.Resources["md.comp.outlined-text-field.input-text.font"];
            public static double InputTextLineHeight => (double)Application.Current.Resources["md.comp.outlined-text-field.input-text.line-height"];
            public static double InputTextSize => (double)Application.Current.Resources["md.comp.outlined-text-field.input-text.size"];
            public static int InputTextWeight => (int)Application.Current.Resources["md.comp.outlined-text-field.input-text.weight"];
            public static double InputTextTracking => (double)Application.Current.Resources["md.comp.outlined-text-field.input-text.tracking"];
            public static string InputTextType => (string)Application.Current.Resources["md.comp.outlined-text-field.input-text.type"];
            public static Color InputTextSuffixColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.input-text.suffix.color"];
            public static Color InputTextPrefixColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.input-text.prefix.color"];
            public static Color InputTextPlaceholderColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.input-text.placeholder.color"];

            // ==================== Enabled / Caret ====================
            public static Color CaretColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.caret.color"];
            public static Color ErrorFocusCaretColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.error.focus.caret.color"];

            // ==================== Disabled / Label text ====================
            public static Color DisabledLabelTextColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.disabled.label-text.color"];
            public static double DisabledLabelTextOpacity => (double)Application.Current.Resources["md.comp.outlined-text-field.disabled.label-text.opacity"];

            // ==================== Disabled / Leading icon ====================
            public static Color DisabledLeadingIconColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.disabled.leading-icon.color"];
            public static double DisabledLeadingIconOpacity => (double)Application.Current.Resources["md.comp.outlined-text-field.disabled.leading-icon.opacity"];

            // ==================== Disabled / Trailing icon ====================
            public static Color DisabledTrailingIconColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.disabled.trailing-icon.color"];
            public static double DisabledTrailingIconOpacity => (double)Application.Current.Resources["md.comp.outlined-text-field.disabled.trailing-icon.opacity"];

            // ==================== Disabled / Outline ====================
            public static double DisabledOutlineWidth => (double)Application.Current.Resources["md.comp.outlined-text-field.disabled.outline.width"];
            public static Color DisabledOutlineColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.disabled.outline.color"];
            public static double DisabledOutlineOpacity => (double)Application.Current.Resources["md.comp.outlined-text-field.disabled.outline.opacity"];

            // ==================== Disabled / Supporting text ====================
            public static Color DisabledSupportingTextColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.disabled.supporting-text.color"];
            public static double DisabledSupportingTextOpacity => (double)Application.Current.Resources["md.comp.outlined-text-field.disabled.supporting-text.opacity"];

            // ==================== Disabled / Input text ====================
            public static Color DisabledInputTextColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.disabled.input-text.color"];
            public static double DisabledInputTextOpacity => (double)Application.Current.Resources["md.comp.outlined-text-field.disabled.input-text.opacity"];

            // ==================== Focused / Label text ====================
            public static Color FocusedLabelTextColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.focus.label-text.color"];

            // ==================== Focused / Leading icon ====================
            public static Color FocusedLeadingIconColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.focus.leading-icon.color"];

            // ==================== Focused / Trailing icon ====================
            public static Color FocusedTrailingIconColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.focus.trailing-icon.color"];

            // ==================== Focused / Outline ====================
            public static double FocusedOutlineWidth => (double)Application.Current.Resources["md.comp.outlined-text-field.focus.outline.width"];
            public static Color FocusedOutlineColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.focus.outline.color"];

            // ==================== Focused / Input text ====================
            public static Color FocusedInputTextColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.focus.input-text.color"];

            // ==================== Focused / Supporting text ====================
            public static Color FocusedSupportingTextColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.focus.supporting-text.color"];

            // ==================== Focused / Focus indicator ====================
            public static Color FocusIndicatorColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.focus.indicator.outline.color"];
            public static Color ErrorFocusIndicatorColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.error.focus.indicator.outline.color"];
            public static double FocusIndicatorThickness => (double)Application.Current.Resources["md.comp.outlined-text-field.focus.indicator.outline.thickness"];

            // ==================== Error ====================
            public static Color ErrorOutlineColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.error.outline.color"];
            public static Color ErrorLabelTextColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.error.label-text.color"];
            public static Color ErrorInputTextColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.error.input-text.color"];
            public static Color ErrorSupportingTextColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.error.supporting-text.color"];
            public static Color ErrorLeadingIconColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.error.leading-icon.color"];
            public static Color ErrorTrailingIconColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.error.trailing-icon.color"];

            // ==================== Error / Focus ====================
            public static Color ErrorFocusOutlineColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.error.focus.outline.color"];
            public static Color ErrorFocusLabelTextColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.error.focus.label-text.color"];
            public static Color ErrorFocusInputTextColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.error.focus.input-text.color"];
            public static Color ErrorFocusSupportingTextColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.error.focus.supporting-text.color"];
            public static Color ErrorFocusLeadingIconColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.error.focus.leading-icon.color"];
            public static Color ErrorFocusTrailingIconColor => (Color)Application.Current.Resources["md.comp.outlined-text-field.error.focus.trailing-icon.color"];
                
        }
    }
}
