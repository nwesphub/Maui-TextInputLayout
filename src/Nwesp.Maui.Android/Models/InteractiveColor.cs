using Nwesp.Maui.Android.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nwesp.Maui.Android.Models
{
    public class InteractiveColor
    (
        Color defaultColor,
        Color focusedColor
    ) : IInteractiveColor
    {
        public Color DefaultColor { get; } = defaultColor;
        public Color FocusedColor { get; } = focusedColor;
    }
}
