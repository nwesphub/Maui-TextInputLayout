using Maui.Android.TextInputLayout.Models.Enums;
using Maui.Android.TextInputLayout.Models.Events;
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
        Color OutlineColor { get; set; }
        Color FocusedOutlineColor { get; set; }
        Color DisabledOutlineColor { get; set; }
        string Hint { get; set; }
        Color DefaultHintColor { get; set; }
        Color FocusedHintColor { get; set; }
        Color DisabledHintColor { get; set; }
        bool IsHintAnimated { get; set; }
        View Content { get; set; }
        ITextInputEditText TextInputEditText { get; set; }
        string? Text { get; set; }
        ImageSource EndIcon { get; set; }
        BoxBackgroundMode BoxBackgroundMode { get; set; }
        IconVisibilityMode EndIconVisibilityMode { get; set; }
        EndIconClickedEventHandler EndIconEventHandler { get; set; }
        Color TextColor { get; set; }
        Color? EndIconColor { get; set; }
    }
}
