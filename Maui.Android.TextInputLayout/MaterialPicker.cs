using Maui.Android.TextInputLayout.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout
{
    public class MaterialPicker : Picker, IMaterialEntry
    {
        public BoxBackgroundMode BoxBackgroundMode { get; set; }
    }
}
