using Nwesp.Maui.Android.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nwesp.Maui.Android
{
    public interface IMaterialEntry : IView, ITextStyle
    {
        public BoxBackgroundMode BoxBackgroundMode { get; set; }
        public static BoxBackgroundMode ParseBoxBackgroundMode(IView view)
        {
            return (view as IMaterialEntry)?.BoxBackgroundMode ?? BoxBackgroundMode.None;
        }
        
        Color DisabledTextColor { get; set; }
        float DisabledTextColorOpacity { get; set; }
    }
}
