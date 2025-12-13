using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using AView = Android.Views.View;
using LLayout = Android.Widget.LinearLayout;
using RResource = Android.Resource.Attribute;
namespace Maui.Android.TextInputLayout.Platforms.Android
{
    public class MauiTextInputLayout : Google.Android.Material.TextField.TextInputLayout
    {
        public MauiTextInputLayout(Context context) : base(context)
        {
            SetDefaults();
        }
        public MauiTextInputLayout(Context context, IAttributeSet? attrs, int style) : base(context, attrs, style)
        {
            
        }

        private void SetDefaults()
        {
            this.SetBoxCornerRadii(8 ,8, 8, 8);
            this.BoxStrokeWidth = 1;
            this.BoxStrokeWidthFocused = 2;
            
            SetDefaultClearButton();
        }

        public void SetEndIconOnClickListener(ITextInputLayout textInputLayout)
        {
            if(textInputLayout is not null)
            {
                this.SetEndIconOnClickListener(new OnEndIconClickListener(this, textInputLayout));
            }
        }
        private void SetDefaultClearButton()
        {
            
            // Set end icon - clear button
            this.SetEndIconDrawable(Resource.Drawable.ic_clear_2);
            // Set icon callback function
            this.SetEndIconOnClickListener(new OnEndIconClickListener(this));
            // set icon visibility
            this.EndIconVisible = true;
            // Padding to prevent text from overlapping the button
            //this.MauiTextInputEditText.SetPadding(40,0,120,0);
            // Reduces vertical padding between the button and the borders. Otherwise the entry would be very tall vertically
            this.EndIconMinSize = 120;

            // Removes the underline under the text in the entry
            //this.MauiTextInputEditText.InputType = InputTypes.TextVariationVisiblePassword | InputTypes.TextFlagNoSuggestions;

            //// Set end icon - clear button
            //this.SetStartIconDrawable(Resource.Drawable.ic_clear_2);
            //// Set icon callback function
            //this.SetStartIconOnClickListener(new OnEndIconClickListener(this));
            //// set icon visibility
            //this.StartIconVisible = true;
            //// Padding to prevent text from overlapping the button
            ////this.MauiTextInputEditText.SetPadding(40,0,120,0);
            //// Reduces vertical padding between the button and the borders. Otherwise the entry would be very tall vertically
            //this.StartIconMinSize = 120;
        }

        public class OnEndIconClickListener : Java.Lang.Object, IOnClickListener
        {
            MauiTextInputLayout? _mauiTextInputLayout;
            ITextInputLayout? _textInputLayout;
            public OnEndIconClickListener(MauiTextInputLayout mauiTextInputLayout, ITextInputLayout? textInputLayout = null)
            {
                _mauiTextInputLayout = mauiTextInputLayout;
                _textInputLayout = textInputLayout;
            }

            public void OnClick(AView? v)
            {
                if (_textInputLayout is not null)
                {
                    _textInputLayout.EndIconEventHandler?.RaiseEvent(_mauiTextInputLayout, _mauiTextInputLayout?.EditText?.Text);
                }
                else if (_mauiTextInputLayout?.EditText is not null)
                {
                    _mauiTextInputLayout.EditText.Text = string.Empty;
                }
            }
        }

        public class TextChangedListener : Java.Lang.Object, ITextWatcher
        {
            public void AfterTextChanged(IEditable? s)
            {
                throw new NotImplementedException();
            }

            public void BeforeTextChanged(ICharSequence? s, int start, int count, int after)
            {
                throw new NotImplementedException();
            }

            public void OnTextChanged(ICharSequence? s, int start, int before, int count)
            {
                if(s is null)
                {
                    return;
                }
                foreach(char seq in s)
                {
                    
                }
            }
        }
    }
}
