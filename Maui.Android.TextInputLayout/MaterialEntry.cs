using Maui.Android.TextInputLayout.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AndroidX.ConstraintLayout.Core.Motion.Utils.HyperSpline;

namespace Maui.Android.TextInputLayout
{
    public class MaterialEntry : Entry, IMaterialEntry
    {
        public BoxBackgroundMode BoxBackgroundMode { get; set; }
    }
}
