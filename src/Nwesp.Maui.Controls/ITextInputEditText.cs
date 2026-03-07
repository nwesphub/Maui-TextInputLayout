using Nwesp.Maui.Android.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nwesp.Maui.Android
{
    [Obsolete]
    public interface ITextInputEditText : IEntry
    {
        Color BackgroundColor { get; set; }
        BoxBackgroundMode BoxBackgroundMode { get; set; }
        new ITextInputLayout? Parent { get; }
    }
}
