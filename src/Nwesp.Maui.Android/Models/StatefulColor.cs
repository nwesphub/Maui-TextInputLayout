using Nwesp.Maui.Android.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nwesp.Maui.Android.Models
{
    public class StatefulColor
    (
        Color defaultColor,
        Color focusedColor,
        Color disabledColor,
        float disabledOpacity
    ) : IStatefulColor
    {
        public Color DefaultColor { get; } = defaultColor;
        public Color FocusedColor { get; } = focusedColor;
        public Color DisabledColor { get; } = disabledColor;
        public float DisabledOpacity { get; } = disabledOpacity;
    }
}
