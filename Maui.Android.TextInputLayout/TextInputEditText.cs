using Maui.Android.TextInputLayout.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout
{
    public class TextInputEditText : Entry, ITextInputEditText
    {
        public TextInputEditText()
        {
            
        }
        static TextInputEditText()
        {
            BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(TextInputEditText));
            BoxBackgroundModeProperty = BindableProperty.Create(nameof(BoxBackgroundMode), typeof(BoxBackgroundMode), typeof(TextInputEditText));
        }

        public static new readonly BindableProperty BackgroundColorProperty;
        public static readonly BindableProperty BoxBackgroundModeProperty;
        public new Color BackgroundColor
        {
            get => (Color)base.GetValue(BackgroundColorProperty);
            set => base.SetValue(BackgroundColorProperty, value);
        }
        public BoxBackgroundMode BoxBackgroundMode
        {
            get => (BoxBackgroundMode)base.GetValue(BoxBackgroundModeProperty);
            set => base.SetValue(BoxBackgroundModeProperty, value);
        }
    }
}
