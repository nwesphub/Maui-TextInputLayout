using Maui.Android.TextInputLayout.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout
{
    [Obsolete]
    public interface ITextInputEditText : IEntry
    {
        Color BackgroundColor { get; set; }
        BoxBackgroundMode BoxBackgroundMode { get; set; }
        new ITextInputLayout? Parent { get; }
    }
}
