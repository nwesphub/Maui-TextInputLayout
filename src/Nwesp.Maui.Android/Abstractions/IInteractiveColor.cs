using System;
using System.Collections.Generic;
using System.Text;

namespace Nwesp.Maui.Android.Abstractions
{
    public interface IInteractiveColor
    {
        Color DefaultColor { get; }
        Color FocusedColor { get; }
    }
}
