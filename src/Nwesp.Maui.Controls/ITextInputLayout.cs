using Nwesp.Maui.Android.Models.Enums;
using Nwesp.Maui.Android.Models.Events;
using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nwesp.Maui.Android
{
    public interface ITextInputLayout : IView, IContentView
    {
        Color BackgroundColor { get; set; }
        Color DisabledBackgroundColor { get; set; }
        float DisabledBackgroundColorOpacity { get; set; }
        Color OutlineColor { get; set; }
        Color FocusedOutlineColor { get; set; }
        Color DisabledOutlineColor { get; set; }
        float DisabledOutlineOpacity { get; set; }
        string Hint { get; set; }
        Color DefaultHintColor { get; set; }
        Color FocusedHintColor { get; set; }
        Color DisabledHintColor { get; set; }
        float DisabledHintOpacity { get; set; }
        bool IsHintAnimated { get; set; }
        
        BoxBackgroundMode BoxBackgroundMode { get; set; }
        IconVisibilityMode EndIconVisibilityMode { get; set; }
        void EndIconClicked();

        ImageSource EndIcon { get; set; }
        Color EndIconColor { get; set; }
        Color DisabledEndIconColor { get; set; }
        float DisabledEndIconOpacity { get; set; }

        ImageSource StartIcon { get; set; }
        Color StartIconColor { get; set; }
        Color DisabledStartIconColor { get; set; }
        float DisabledStartIconOpacity { get; set; }

        string? Prefix { get; set; }
        string? Suffix { get; set; }
        string? SupportingText { get; set; }
        string? ErrorText { get; set; }
        CornerRadius BoxStrokeCornerRadius { get; set; }
        int BoxStrokeWidth { get; set; }
        int BoxStrokeFocusedWidth { get; set; }
        bool CounterEnabled { get; set; }
        int CounterMaxLength { get; set; }
        Color SuffixTextColor { get; set; }
        Color DisabledSuffixTextColor { get; set; }
        float DisabledSuffixTextColorOpacity { get; set; }
        Color PrefixTextColor { get; set; }
        Color DisabledPrefixTextColor { get; set; }
        float DisabledPrefixTextColorOpacity { get; set; }
    }
}
