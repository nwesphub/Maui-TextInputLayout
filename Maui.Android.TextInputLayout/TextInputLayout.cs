using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout
{
    public class TextInputLayout : Layout, ITextInputLayout
    {

        public TextInputLayout()
        {
            
        }

        static TextInputLayout()
        {
            BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(TextInputLayout), defaultValue: Colors.Black);
            FocusedBorderColorProperty = BindableProperty.Create(nameof(FocusedBorderColor), typeof(Color), typeof(TextInputLayout), defaultValue: Colors.Black);
            HintProperty = BindableProperty.Create(nameof(Hint), typeof(string), typeof(TextInputLayout));
            DefaultHintColorProperty = BindableProperty.Create(nameof(DefaultHintColor), typeof(Color), typeof(TextInputLayout), defaultValue: (Application.Current.Resources["Primary"] as Color) ?? Colors.LightGray);
            FocusedHintColorProperty = BindableProperty.Create(nameof(FocusedHintColor), typeof(Color), typeof(TextInputLayout), defaultValue: (Application.Current.Resources["Primary"] as Color) ?? Colors.LightGray);
            IsHintAnimatedProperty = BindableProperty.Create(nameof(IsHintAnimated), typeof(bool), typeof(TextInputLayout), defaultValue: true);
        }

        protected override ILayoutManager CreateLayoutManager()
        {
            return new TextInputLayoutManager(this);
        }

        public static readonly BindableProperty BorderColorProperty;
        public static readonly BindableProperty FocusedBorderColorProperty;
        public static readonly BindableProperty HintProperty;
        public static readonly BindableProperty DefaultHintColorProperty;
        public static readonly BindableProperty FocusedHintColorProperty;
        public static readonly BindableProperty IsHintAnimatedProperty;

        public Color BorderColor
        {
            get => (Color)base.GetValue(BorderColorProperty);
            set => base.SetValue(BorderColorProperty, value);
        }

        public Color FocusedBorderColor
        {
            get => (Color)base.GetValue(FocusedBorderColorProperty);
            set => base.SetValue(FocusedBorderColorProperty, value);
        }

        public string Hint
        {
            get => base.GetValue(HintProperty)?.ToString() ?? string.Empty;
            set => base.SetValue(HintProperty, value);
        }

        public Color DefaultHintColor
        {
            get => (Color)base.GetValue(DefaultHintColorProperty);
            set => base.SetValue(DefaultHintColorProperty, value);
        }

        public Color FocusedHintColor
        {
            get => (Color)base.GetValue(FocusedHintColorProperty);
            set => base.SetValue(FocusedHintColorProperty, value);
        }

        public bool IsHintAnimated
        {
            get => (bool)base.GetValue(IsHintAnimatedProperty);
            set => base.SetValue(IsHintAnimatedProperty, value);
        }
    }
}
