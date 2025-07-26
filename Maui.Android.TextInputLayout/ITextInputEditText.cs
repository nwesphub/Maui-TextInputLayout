using Maui.Android.TextInputLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout
{
    public interface ITextInputEditText : IView, IEntry
    {
        Color BackgroundColor { get; set; }
        BoxBackgroundMode BoxBackgroundMode { get; set; }
    }
}
