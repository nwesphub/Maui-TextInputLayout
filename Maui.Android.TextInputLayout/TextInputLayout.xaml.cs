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
using Microsoft.Maui.Controls.Shapes;
using System.Windows.Input;




#if ANDROID
using Microsoft.Maui.Platform;
#endif
namespace Maui.Android.TextInputLayout
{
    public partial class TextInputLayout : ContentView, ITextInputLayout
    {
        public TextInputLayout()
        {

            InitializeComponent();
        }

        static TextInputLayout()
        {
            OutlineColorProperty = BindableProperty.Create(nameof(OutlineColor), typeof(Color), typeof(TextInputLayout), defaultValue: ThemeHelper.GetOutlineColor());
            FocusedOutlineColorProperty = BindableProperty.Create(nameof(FocusedOutlineColor), typeof(Color), typeof(TextInputLayout), defaultValue: ThemeHelper.GetFocusedOutlineColor());
            DisabledOutlineColorProperty = BindableProperty.Create(nameof(DisabledOutlineColor), typeof(Color), typeof(TextInputLayout), defaultValue: ThemeHelper.GetDisabledOutlineColor());
            DisabledOutlineOpacityProperty = BindableProperty.Create(nameof(DisabledOutlineOpacity), typeof(float), typeof(TextInputLayout), defaultValue: ThemeHelper.GetDisabledOutlineOpacity());
            DisabledBackgroundColorProperty = BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(TextInputLayout));
            HintProperty = BindableProperty.Create(nameof(Hint), typeof(string), typeof(TextInputLayout));
            DefaultHintColorProperty = BindableProperty.Create(nameof(DefaultHintColor), typeof(Color), typeof(TextInputLayout), defaultValue: ThemeHelper.GetLabelTextColor());
            FocusedHintColorProperty = BindableProperty.Create(nameof(FocusedHintColor), typeof(Color), typeof(TextInputLayout), defaultValue: ThemeHelper.GetFocusedLabelTextColor());
            DisabledHintColorProperty = BindableProperty.Create(nameof(DisabledHintColor), typeof(Color), typeof(TextInputLayout), defaultValue: ThemeHelper.GetDisabledLabelTextColor());
            DisabledHintOpacityProperty = BindableProperty.Create(nameof(DisabledHintOpacity), typeof(float), typeof(TextInputLayout), defaultValue: ThemeHelper.GetDisabledLabelTextOpacity());
            IsHintAnimatedProperty = BindableProperty.Create(nameof(IsHintAnimated), typeof(bool), typeof(TextInputLayout), defaultValue: true);
            EndIconProperty = BindableProperty.Create(nameof(EndIcon), typeof(ImageSource), typeof(TextInputLayout));
            BoxBackgroundModeProperty = BindableProperty.Create(nameof(BoxBackgroundMode), typeof(BoxBackgroundMode), typeof(TextInputLayout), defaultBindingMode: BindingMode.OneTime, propertyChanged: BoxBackgroundModePropertyChanged);
            EndIconVisibilityModeProperty = BindableProperty.Create(nameof(EndIconVisibilityMode), typeof(IconVisibilityMode), typeof(TextInputLayout));
            EndIconColorProperty = BindableProperty.Create(nameof(EndIconColor), typeof(Color), typeof(TextInputLayout), defaultValue: ThemeHelper.GetTrailingIconColor());
            EndIconDisabledColorProperty = BindableProperty.Create(nameof(EndIconColor), typeof(Color), typeof(TextInputLayout), defaultValue: ThemeHelper.GetDisabledTrailingIconColor());
            DisabledEndIconOpacityProperty = BindableProperty.Create(nameof(DisabledEndIconOpacity), typeof(float), typeof(TextInputLayout), defaultValue: ThemeHelper.GetDisabledTrailingIconOpacity());
            PrefixProperty = BindableProperty.Create(nameof(Prefix), typeof(string), typeof(TextInputLayout));
            PrefixTextColorProperty = BindableProperty.Create(nameof(PrefixTextColor), typeof(Color), typeof(TextInputLayout), defaultValue: ThemeHelper.GetInputTextPrefixColor());
            DisabledPrefixTextColorProperty = BindableProperty.Create(nameof(DisabledPrefixTextColor), typeof(Color), typeof(TextInputLayout), defaultValue: ThemeHelper.GetDisabledInputTextColor());
            DisabledPrefixTextColorOpacityProperty = BindableProperty.Create(nameof(DisabledPrefixTextColorOpacity), typeof(float), typeof(TextInputLayout), defaultValue: ThemeHelper.GetDisabledInputTextOpacity());
            SuffixProperty = BindableProperty.Create(nameof(Suffix), typeof(string), typeof(TextInputLayout));
            SuffixTextColorProperty = BindableProperty.Create(nameof(SuffixTextColor), typeof(Color), typeof(TextInputLayout), defaultValue: ThemeHelper.GetInputTextSuffixColor());
            DisabledSuffixTextColorProperty = BindableProperty.Create(nameof(DisabledSuffixTextColor), typeof(Color), typeof(TextInputLayout), defaultValue: ThemeHelper.GetDisabledInputTextColor());
            DisabledSuffixTextColorOpacityProperty = BindableProperty.Create(nameof(DisabledSuffixTextColorOpacity), typeof(float), typeof(TextInputLayout), defaultValue: ThemeHelper.GetDisabledInputTextOpacity());
            SupportingTextProperty = BindableProperty.Create(nameof(SupportingText), typeof(string), typeof(TextInputLayout));
            BoxStrokeCornerRadiusProperty = BindableProperty.Create(nameof(BoxStrokeCornerRadius), typeof(CornerRadius), typeof(TextInputLayout));
            BoxStrokeWidthProperty = BindableProperty.Create(nameof(BoxStrokeWidth), typeof(int), typeof(TextInputLayout), defaultValue: ThemeHelper.GetOutlineWidth());
            BoxStrokeFocusedWidthProperty = BindableProperty.Create(nameof(BoxStrokeFocusedWidth), typeof(int), typeof(TextInputLayout), defaultValue: ThemeHelper.GetFocusedOutlineWidth());
            CounterEnabledProperty = BindableProperty.Create(nameof(CounterEnabled), typeof(bool), typeof(TextInputLayout));
            CounterMaxLengthProperty = BindableProperty.Create(nameof(CounterMaxLength), typeof(int), typeof(TextInputLayout));
            DisabledBackgroundColorOpacityProperty = BindableProperty.Create(nameof(DisabledBackgroundColorOpacity), typeof(float), typeof(TextInputLayout));
            ErrorTextProperty = BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(TextInputLayout));
            EndIconClickedCommandProperty = BindableProperty.Create(nameof(EndIconClickedCommand), typeof(ICommand), typeof(TextInputLayout));
        }

        private static void BoxBackgroundModePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(bindable is not TextInputLayout control || newValue is not BoxBackgroundMode mode)
            {
                return;
            }

            // Outline
            //control.TrySetDefaultProperty(OutlineColorProperty, ThemeHelper.GetOutlineColor());
            //control.TrySetDefaultProperty(FocusedOutlineColorProperty, ThemeHelper.GetFocusedOutlineColor());
            //control.TrySetDefaultProperty(DisabledOutlineColorProperty, ThemeHelper.GetDisabledOutlineColor());
            //control.TrySetDefaultProperty(DisabledOutlineOpacityProperty, ThemeHelper.GetDisabledOutlineOpacity());

            // Hint
            //control.TrySetDefaultProperty(DefaultHintColorProperty, ThemeHelper.GetLabelTextColor());
            //control.TrySetDefaultProperty(FocusedHintColorProperty, ThemeHelper.GetFocusedLabelTextColor());
            //control.TrySetDefaultProperty(DisabledHintColorProperty, ThemeHelper.GetDisabledLabelTextColor());
            //control.TrySetDefaultProperty(DisabledHintOpacityProperty, ThemeHelper.GetDisabledLabelTextOpacity());

            // Background Color / Container Color
            control.TrySetDefaultProperty(BackgroundColorProperty, ThemeHelper.GetContainerColor(mode));
            control.TrySetDefaultProperty(DisabledBackgroundColorProperty, ThemeHelper.GetDisabledContainerColor(mode));
            control.TrySetDefaultProperty(DisabledBackgroundColorOpacityProperty, ThemeHelper.GetDisabledContainerOpacity(mode));

            // End Icon color
            //control.TrySetDefaultProperty(EndIconColorProperty, ThemeHelper.GetTrailingIconColor());
            //control.TrySetDefaultProperty(EndIconDisabledColorProperty, ThemeHelper.GetDisabledTrailingIconColor());
            //control.TrySetDefaultProperty(DisabledEndIconOpacityProperty, ThemeHelper.GetDisabledTrailingIconOpacity());

            control.TrySetDefaultProperty(BoxStrokeCornerRadiusProperty, ThemeHelper.GetContainerShape(mode));
            //control.TrySetDefaultProperty(BoxStrokeWidthProperty, ThemeHelper.GetOutlineWidth());
            //control.TrySetDefaultProperty(BoxStrokeFocusedWidthProperty, ThemeHelper.GetFocusedOutlineWidth());
        }

        private void TrySetDefaultProperty<T>(BindableProperty property, T value)
        {
            if (!IsSet(property))
            {
                SetValue(property, value);
            }
        }


        public static readonly BindableProperty OutlineColorProperty;
        public static readonly BindableProperty FocusedOutlineColorProperty;
        public static readonly BindableProperty DisabledOutlineColorProperty;
        public static readonly BindableProperty DisabledOutlineOpacityProperty;
        public static readonly BindableProperty DisabledBackgroundColorProperty;
        public static readonly BindableProperty DisabledBackgroundColorOpacityProperty;
        public static readonly BindableProperty HintProperty;
        public static readonly BindableProperty DefaultHintColorProperty;
        public static readonly BindableProperty FocusedHintColorProperty;
        public static readonly BindableProperty DisabledHintColorProperty;
        public static readonly BindableProperty DisabledHintOpacityProperty;
        public static readonly BindableProperty IsHintAnimatedProperty;
        public static readonly BindableProperty EndIconProperty;
        public static readonly BindableProperty BoxBackgroundModeProperty;
        public static readonly BindableProperty EndIconVisibilityModeProperty;
        public static readonly BindableProperty EndIconColorProperty;
        public static readonly BindableProperty EndIconDisabledColorProperty;
        public static readonly BindableProperty DisabledEndIconOpacityProperty;
        public static readonly BindableProperty PlaceholderProperty;
        public static readonly BindableProperty PlaceholderColorProperty;
        public static readonly BindableProperty PrefixProperty;
        public static readonly BindableProperty SuffixProperty;
        public static readonly BindableProperty SupportingTextProperty;
        public static readonly BindableProperty ErrorTextProperty;
        public static readonly BindableProperty BoxStrokeCornerRadiusProperty;
        public static readonly BindableProperty BoxStrokeWidthProperty;
        public static readonly BindableProperty BoxStrokeFocusedWidthProperty;
        public static readonly BindableProperty CounterEnabledProperty;
        public static readonly BindableProperty CounterMaxLengthProperty;
        public static readonly BindableProperty SuffixTextColorProperty;
        public static readonly BindableProperty DisabledSuffixTextColorProperty;
        public static readonly BindableProperty DisabledSuffixTextColorOpacityProperty;
        public static readonly BindableProperty PrefixTextColorProperty;
        public static readonly BindableProperty DisabledPrefixTextColorProperty;
        public static readonly BindableProperty DisabledPrefixTextColorOpacityProperty;
        public static readonly BindableProperty EndIconClickedCommandProperty;

        
        public void EndIconClicked()
        {
            if (EndIconClickedCommand is not null)
            {
                EndIconClickedCommand.Execute(null);
                return;
            }

            if (Content is InputView inputView)
            {
                inputView.Text = string.Empty;
            }
            else if (Content is Picker picker)
            {
                picker.SelectedItem = null;
            }
        }
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
        public Color DisabledOutlineColor
        {
            get => (Color)base.GetValue(DisabledOutlineColorProperty);
            set => base.SetValue(DisabledOutlineColorProperty, value);
        }
        public float DisabledOutlineOpacity
        {
            get => (float)base.GetValue(DisabledOutlineOpacityProperty);
            set => base.SetValue(DisabledOutlineOpacityProperty, value);
        }
        public Color DisabledBackgroundColor
        {
            get => (Color)base.GetValue(DisabledBackgroundColorProperty);
            set => base.SetValue(DisabledBackgroundColorProperty, value);
        }

        public float DisabledBackgroundColorOpacity
        {
            get => (float)base.GetValue(DisabledBackgroundColorOpacityProperty);
            set => base.SetValue(DisabledBackgroundColorOpacityProperty, value);
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
        public Color DisabledHintColor
        {
            get => (Color)base.GetValue(DisabledHintColorProperty);
            set => base.SetValue(DisabledHintColorProperty, value);
        }
        public float DisabledHintOpacity
        {
            get => (float)base.GetValue(DisabledOutlineOpacityProperty);
            set => base.SetValue(DisabledOutlineOpacityProperty, value);
        }

        public bool IsHintAnimated
        {
            get => (bool)base.GetValue(IsHintAnimatedProperty);
            set => base.SetValue(IsHintAnimatedProperty, value);
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


        public Color EndIconColor
        {
            get => (Color)GetValue(EndIconColorProperty);
            set => SetValue(EndIconColorProperty, value);
        }

        public Color EndIconDisabledColor
        {
            get => (Color)GetValue(EndIconDisabledColorProperty);
            set => SetValue(EndIconDisabledColorProperty, value);
        }
        public float DisabledEndIconOpacity
        {
            get => (float)GetValue(DisabledEndIconOpacityProperty);
            set => SetValue(DisabledEndIconOpacityProperty, value);
        }

        public string? Prefix
        {
            get => base.GetValue(PrefixProperty)?.ToString();
            set => base.SetValue(PrefixProperty, value);
        }
        public Color PrefixTextColor
        {
            get => (Color)GetValue(PrefixTextColorProperty);
            set => SetValue(PrefixTextColorProperty, value);
        }
        public Color DisabledPrefixTextColor
        {
            get => (Color)GetValue(DisabledPrefixTextColorProperty);
            set => SetValue(DisabledPrefixTextColorProperty, value);
        }
        public float DisabledPrefixTextColorOpacity
        {
            get => (float)GetValue(DisabledPrefixTextColorOpacityProperty);
            set => SetValue(DisabledPrefixTextColorOpacityProperty, value);
        }
        public string? Suffix
        {
            get => base.GetValue(SuffixProperty)?.ToString();
            set => base.SetValue(SuffixProperty, value);
        }
        public Color SuffixTextColor
        {
            get => (Color)GetValue(SuffixTextColorProperty);
            set => SetValue(SuffixTextColorProperty, value);
        }
        public Color DisabledSuffixTextColor
        {
            get => (Color)GetValue(DisabledSuffixTextColorProperty);
            set => SetValue(DisabledSuffixTextColorProperty, value);
        }
        public float DisabledSuffixTextColorOpacity
        {
            get => (float)GetValue(DisabledSuffixTextColorOpacityProperty);
            set => SetValue(DisabledSuffixTextColorOpacityProperty, value);
        }
        public string? SupportingText
        {
            get => base.GetValue(SupportingTextProperty)?.ToString();
            set => base.SetValue(SupportingTextProperty, value);
        }

        public CornerRadius BoxStrokeCornerRadius
        {
            get => (CornerRadius)base.GetValue(BoxStrokeCornerRadiusProperty);
            set => base.SetValue(BoxStrokeCornerRadiusProperty, value);
        }
        public int BoxStrokeWidth
        {
            get => (int)GetValue(BoxStrokeWidthProperty);
            set => SetValue(BoxStrokeWidthProperty, value);
        }
        public int BoxStrokeFocusedWidth
        {
            get => (int)GetValue(BoxStrokeFocusedWidthProperty);
            set => SetValue(BoxStrokeFocusedWidthProperty, value);
        }

        public bool CounterEnabled
        {
            get => (bool)GetValue(CounterEnabledProperty);
            set => SetValue(CounterEnabledProperty, value);
        }
        public int CounterMaxLength
        {
            get => (int)GetValue(CounterMaxLengthProperty);
            set => SetValue(CounterMaxLengthProperty, value);
        }
        public string? ErrorText
        {
            get => GetValue(ErrorTextProperty)?.ToString();
            set => SetValue(ErrorTextProperty, value);
        }

        public ICommand EndIconClickedCommand
        {
            get => (ICommand)GetValue(EndIconClickedCommandProperty);
            set => SetValue(EndIconClickedCommandProperty, value);
        }
    }
}
