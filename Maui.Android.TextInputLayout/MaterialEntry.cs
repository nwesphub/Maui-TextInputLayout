using Maui.Android.TextInputLayout.Models.Enums;
using Maui.Android.TextInputLayout.Utilities;
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
        public MaterialEntry() : base()
        {
        }
        public BoxBackgroundMode BoxBackgroundMode { get; set; }

        public static readonly BindableProperty DisabledTextColorProperty = BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialEntry), defaultValue: ThemeHelper.GetDisabledInputTextColor());
        public Color DisabledTextColor
        {
            get => (Color)base.GetValue(DisabledTextColorProperty);
            set => base.SetValue(DisabledTextColorProperty, value);
        }
        public static readonly BindableProperty DisabledTextColorOpacityProperty = BindableProperty.Create(nameof(DisabledTextColorOpacity), typeof(float), typeof(MaterialEntry), defaultValue: ThemeHelper.GetDisabledInputTextOpacity());
        public float DisabledTextColorOpacity
        {
            get => (float)base.GetValue(DisabledTextColorOpacityProperty);
            set => base.SetValue(DisabledTextColorOpacityProperty, value);
        }
    }
}
