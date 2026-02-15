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
using Maui.Android.TextInputLayout.Utilities;
using System.Runtime.CompilerServices;


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
            

            EndIconEventHandler.EndIconClicked += TextInputLayout_EndIconClicked;
        }

 
        private void TextInputLayout_EndIconClicked(object? sender, EndIconClickedEventArgs e)
        {
            if(Content is InputView inputView)
            {
                inputView.Text = string.Empty;
            }
            if(Content is Picker pp)
            {
                pp.SelectedItem = null;
            }
            Text = string.Empty;
        }

        static TextInputLayout()
        {
            OutlineColorProperty = BindableProperty.Create(nameof(OutlineColor), typeof(Color), typeof(TextInputLayout), defaultValue: Colors.Black);
            FocusedOutlineColorProperty = BindableProperty.Create(nameof(FocusedOutlineColor), typeof(Color), typeof(TextInputLayout), defaultValue: Colors.Black);
            HintProperty = BindableProperty.Create(nameof(Hint), typeof(string), typeof(TextInputLayout));
            DefaultHintColorProperty = BindableProperty.Create(nameof(DefaultHintColor), typeof(Color), typeof(TextInputLayout), defaultValue: (Application.Current.Resources["Primary"] as Color) ?? Colors.LightGray);
            FocusedHintColorProperty = BindableProperty.Create(nameof(FocusedHintColor), typeof(Color), typeof(TextInputLayout), defaultValue: (Application.Current.Resources["Primary"] as Color) ?? Colors.LightGray);
            IsHintAnimatedProperty = BindableProperty.Create(nameof(IsHintAnimated), typeof(bool), typeof(TextInputLayout), defaultValue: true);
            TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TextInputLayout), defaultBindingMode: BindingMode.TwoWay);
            EndIconProperty = BindableProperty.Create(nameof(EndIcon), typeof(ImageSource), typeof(TextInputLayout));
            BoxBackgroundModeProperty = BindableProperty.Create(nameof(BoxBackgroundMode), typeof(BoxBackgroundMode), typeof(TextInputLayout), defaultBindingMode: BindingMode.OneTime, propertyChanged: BoxBackgroundModePropertyChanged);
            EndIconVisibilityModeProperty = BindableProperty.Create(nameof(EndIconVisibilityMode), typeof(IconVisibilityMode), typeof(TextInputLayout));
            TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(TextInputLayout));
            EndIconColorProperty = BindableProperty.Create(nameof(EndIconColor), typeof(Color), typeof(TextInputLayout));
            PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(TextInputLayout));
            PlaceholderColorProperty = BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(TextInputLayout), defaultValue: Colors.Black);
        }

        private static void BoxBackgroundModePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(bindable is not TextInputLayout control || newValue is not BoxBackgroundMode mode)
            {
                return;
            }

            control.TrySetDefaultProperty(OutlineColorProperty, ThemeHelper.GetOutlineColor(mode));
            control.TrySetDefaultProperty(FocusedOutlineColorProperty, ThemeHelper.GetFocusedOutlineColor(mode));
        }

        private void TrySetDefaultProperty<T>(BindableProperty property, T value)
        {
            if (!IsSet(property))
            {
                SetValue(property, value);
            }
        }

        //protected override ILayoutManager CreateLayoutManager()
        //{
        //    return new TextInputLayoutManager(this);
        //}

        public static readonly BindableProperty OutlineColorProperty;
        public static readonly BindableProperty FocusedOutlineColorProperty;
        public static readonly BindableProperty HintProperty;
        public static readonly BindableProperty DefaultHintColorProperty;
        public static readonly BindableProperty FocusedHintColorProperty;
        public static readonly BindableProperty IsHintAnimatedProperty;
        public static readonly BindableProperty TextProperty;
        public static readonly BindableProperty EndIconProperty;
        public static readonly BindableProperty BoxBackgroundModeProperty;
        public static readonly BindableProperty EndIconVisibilityModeProperty;
        public static readonly BindableProperty TextColorProperty;
        public static readonly BindableProperty EndIconColorProperty;
        public static readonly BindableProperty PlaceholderProperty;
        public static readonly BindableProperty PlaceholderColorProperty;
        public EndIconClickedEventHandler EndIconEventHandler { get; set; } = new();

        public Color OutlineColor
        {
            get => (Color)base.GetValue(OutlineColorProperty);
            set => base.SetValue(OutlineColorProperty, value);
        }

        public Color FocusedOutlineColor
        {
            get => (Color)base.GetValue(FocusedOutlineColorProperty);
            set => base.SetValue(FocusedOutlineColorProperty, value);
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

        /// <summary>
        /// BoxBackground mode needs to be set upon initialization of the component. This cannot be changed once set.
        /// </summary>
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

        /// <summary>
        /// Unused
        /// </summary>
        public Color CursorColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public Color? EndIconColor
        {
            get => (Color?)GetValue(EndIconColorProperty);
            set => SetValue(EndIconColorProperty, value);
        }
        public string Placeholder
        {
            get => GetValue(PlaceholderProperty)?.ToString() ?? string.Empty;
            set => SetValue(PlaceholderProperty, value);
        }
        public Color PlaceholderColor
        {
            get => (Color)GetValue(PlaceholderColorProperty);
            set => SetValue(PlaceholderColorProperty, value);
        }


        public static class OutlineTextField
        {

        }
        
    }
}
