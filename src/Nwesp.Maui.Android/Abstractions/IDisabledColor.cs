using System;
using System.Collections.Generic;
using System.Text;

namespace Nwesp.Maui.Android.Abstractions
{
    public interface IDisabledColor
    {
        Color DisabledColor { get; }
        float DisabledOpacity { get; }
    }
}
