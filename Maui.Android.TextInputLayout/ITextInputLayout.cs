using Maui.Android.TextInputLayout.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout
{
    public interface ITextInputLayout : IView
    {
        Color BackgroundColor { get; set; }
        Color BorderColor { get; set; }
        Color FocusedBorderColor { get; set; }
        string Hint { get; set; }
        Color DefaultHintColor { get; set; }
        Color FocusedHintColor { get; set; }
        bool IsHintAnimated { get; set; }
        View Content { get; set; }
        TextInputEditText TextInputEditText { get; set; }
        string? Text { get; set; }
        ImageSource EndIcon { get; set; }
        BoxBackgroundMode BoxBackgroundMode { get; set; }
    }
}
