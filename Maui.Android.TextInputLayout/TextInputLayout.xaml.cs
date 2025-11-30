using Maui.Android.TextInputLayout.Models.Enums;
using Maui.Android.TextInputLayout.Models.Events;
using Microsoft.Maui;
using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if ANDROID
using Microsoft.Maui.Platform;
#endif
namespace Maui.Android.TextInputLayout
{
    public partial class TextInputLayout : ContentView, ITextInputLayout
    {
        public ITextInputEditText TextInputEditText { get; set; }
        public TextInputLayout()
        {
            
            InitializeComponent();
            TextInputEditText = this.textInputEditText;

            EndIconEventHandler.EndIconClicked += TextInputLayout_EndIconClicked;
        }


        private void TextInputLayout_EndIconClicked(object? sender, EndIconClickedEventArgs e)
        {
            Text = string.Empty;
        }

        static TextInputLayout()
        {
            BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(TextInputLayout), defaultValue: Colors.Black);
            FocusedBorderColorProperty = BindableProperty.Create(nameof(FocusedBorderColor), typeof(Color), typeof(TextInputLayout), defaultValue: Colors.Black);
            HintProperty = BindableProperty.Create(nameof(Hint), typeof(string), typeof(TextInputLayout));
            DefaultHintColorProperty = BindableProperty.Create(nameof(DefaultHintColor), typeof(Color), typeof(TextInputLayout), defaultValue: (Application.Current.Resources["Primary"] as Color) ?? Colors.LightGray);
            FocusedHintColorProperty = BindableProperty.Create(nameof(FocusedHintColor), typeof(Color), typeof(TextInputLayout), defaultValue: (Application.Current.Resources["Primary"] as Color) ?? Colors.LightGray);
            IsHintAnimatedProperty = BindableProperty.Create(nameof(IsHintAnimated), typeof(bool), typeof(TextInputLayout), defaultValue: true);
            TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TextInputLayout), defaultBindingMode: BindingMode.TwoWay);
            EndIconProperty = BindableProperty.Create(nameof(EndIcon), typeof(ImageSource), typeof(TextInputLayout));
            BoxBackgroundModeProperty = BindableProperty.Create(nameof(BoxBackgroundMode), typeof(BoxBackgroundMode), typeof(TextInputLayout));
            EndIconVisibilityModeProperty = BindableProperty.Create(nameof(EndIconVisibilityMode), typeof(IconVisibilityMode), typeof(TextInputLayout));
            TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(TextInputLayout));
        }



        //protected override ILayoutManager CreateLayoutManager()
        //{
        //    return new TextInputLayoutManager(this);
        //}

        public static readonly BindableProperty BorderColorProperty;
        public static readonly BindableProperty FocusedBorderColorProperty;
        public static readonly BindableProperty HintProperty;
        public static readonly BindableProperty DefaultHintColorProperty;
        public static readonly BindableProperty FocusedHintColorProperty;
        public static readonly BindableProperty IsHintAnimatedProperty;
        public static readonly BindableProperty TextProperty;
        public static readonly BindableProperty EndIconProperty;
        public static readonly BindableProperty BoxBackgroundModeProperty;
        public static readonly BindableProperty EndIconVisibilityModeProperty;
        public static readonly BindableProperty TextColorProperty;

        public EndIconClickedEventHandler EndIconEventHandler { get; set; } = new();

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

        public string? Text
        {
            get => base.GetValue(TextProperty)?.ToString();
            set => base.SetValue(TextProperty, value);
        }

        [TypeConverter(typeof(ImageSourceConverter))]
        public ImageSource EndIcon
        {
            get => (ImageSource)base.GetValue(EndIconProperty);
            set => base.SetValue(EndIconProperty, value);
        }

        public BoxBackgroundMode BoxBackgroundMode
        {
            get => (BoxBackgroundMode)base.GetValue(BoxBackgroundModeProperty);
            set => base.SetValue(BoxBackgroundModeProperty, value);
        }
        public IconVisibilityMode EndIconVisibilityMode
        {
            get => (IconVisibilityMode)base.GetValue(EndIconVisibilityModeProperty);
            set => base.SetValue(EndIconVisibilityModeProperty, value);
        }

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }
    }
}
