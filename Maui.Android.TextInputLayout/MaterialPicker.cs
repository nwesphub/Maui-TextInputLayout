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
        public static readonly BindableProperty DisabledTextColorProperty = BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialPicker));
        public Color DisabledTextColor
        {
            get => (Color)base.GetValue(DisabledTextColorProperty);
            set => base.SetValue(DisabledTextColorProperty, value);
        }
        public static readonly BindableProperty DisabledTextColorOpacityProperty = BindableProperty.Create(nameof(DisabledTextColorOpacity), typeof(float), typeof(MaterialPicker));
        public float DisabledTextColorOpacity
        {
            get => (float)base.GetValue(DisabledTextColorOpacityProperty);
            set => base.SetValue(DisabledTextColorOpacityProperty, value);
        }
    }
}
