using Nwesp.Maui.Android.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Internals;

namespace Nwesp.Maui.Android.Abstractions
{
    public interface IMaterialEntry : IView, ITextStyle, IFontElement
    {
        BoxBackgroundMode BoxBackgroundMode { get; set; }
        Color DisabledTextColor { get; set; }
        float DisabledTextColorOpacity { get; set; }
    }
}
