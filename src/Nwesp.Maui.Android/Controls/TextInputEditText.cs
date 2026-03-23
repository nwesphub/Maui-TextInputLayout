//using Nwesp.Maui.Android.Abstractions;
//using Nwesp.Maui.Android.Models.Enums;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Nwesp.Maui.Android.Controls
//{
//    [Obsolete]
//    public class TextInputEditText : Entry, ITextInputEditText
//    {
//        public TextInputEditText()
//        {

//        }
//        ITextInputLayout ITextInputEditText.Parent => Parent as ITextInputLayout;
//        static TextInputEditText()
//        {
//            BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(TextInputEditText));
//            BoxBackgroundModeProperty = BindableProperty.Create(nameof(BoxBackgroundMode), typeof(BoxBackgroundMode), typeof(TextInputEditText));
//        }

//        public static new readonly BindableProperty BackgroundColorProperty;
//        public static readonly BindableProperty BoxBackgroundModeProperty;
//        public new Color BackgroundColor
//        {
//            get => (Color)GetValue(BackgroundColorProperty);
//            set => SetValue(BackgroundColorProperty, value);
//        }
//        public BoxBackgroundMode BoxBackgroundMode
//        {
//            get => (BoxBackgroundMode)GetValue(BoxBackgroundModeProperty);
//            set => SetValue(BoxBackgroundModeProperty, value);
//        }
//    }
//}
