using Nwesp.Maui.Android.Abstractions;
using Nwesp.Maui.Android.Models.Enums;
using Nwesp.Maui.Android.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nwesp.Maui.Android.Controls
{
    public class MaterialPicker : Picker, IMaterialEntry
    {
        public MaterialPicker()
        {
            TextColor = ThemeHelper.GetInputTextColor();
        }
        public BoxBackgroundMode BoxBackgroundMode { get; set; }
        public static readonly BindableProperty DisabledTextColorProperty = BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialPicker));
        public Color DisabledTextColor
        {
            get => (Color)GetValue(DisabledTextColorProperty);
            set => SetValue(DisabledTextColorProperty, value);
        }
        public static readonly BindableProperty DisabledTextColorOpacityProperty = BindableProperty.Create(nameof(DisabledTextColorOpacity), typeof(float), typeof(MaterialPicker));
        public float DisabledTextColorOpacity
        {
            get => (float)GetValue(DisabledTextColorOpacityProperty);
            set => SetValue(DisabledTextColorOpacityProperty, value);
        }
    }
}
