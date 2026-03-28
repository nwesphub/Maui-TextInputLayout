using System;
using System.Collections.Generic;
using System.Text;

namespace Nwesp.Maui.Android.Abstractions
{
    public interface IStatefulColor
    {
        Color DefaultColor { get; }
        Color FocusedColor { get; }
        Color DisabledColor { get; }
        float DisabledOpacity { get; }
    }
}
