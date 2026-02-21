using Maui.Android.TextInputLayout.Models.Enums;
using Maui.Android.TextInputLayout.Models.Events;
using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout
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
        string? Text { get; set; }
        ImageSource EndIcon { get; set; }
        BoxBackgroundMode BoxBackgroundMode { get; set; }
        IconVisibilityMode EndIconVisibilityMode { get; set; }
        EndIconClickedEventHandler EndIconEventHandler { get; set; }
        Color TextColor { get; set; }
        Color EndIconColor { get; set; }
        Color EndIconDisabledColor { get; set; }
        float DisabledEndIconOpacity { get; set; }
        string? Prefix { get; set; }
        string? Suffix { get; set; }
        string? SupportingText { get; set; }
        CornerRadius BoxStrokeCornerRadius { get; set; }
        int BoxStrokeWidth { get; set; }
        int BoxStrokeFocusedWidth { get; set; }
        bool CounterEnabled { get; set; }
        int CounterMaxLength { get; set; }
    }
}
