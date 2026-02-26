using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Internal;
using Google.Android.Material.TextField;
using Java.Lang;
using Maui.Android.TextInputLayout.Models.Enums;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using AView = Android.Views.View;
using LLayout = Android.Widget.LinearLayout;
using AResource = Android.Resource.Attribute;
namespace Maui.Android.TextInputLayout.Platforms.Android
{
    public class MauiTextInputLayout : Google.Android.Material.TextField.TextInputLayout
    {
        public bool HasTextAndFocus => !string.IsNullOrEmpty(EditText?.Text) && EditText?.HasFocus == true;
        public MauiTextInputLayout(Context context, BoxBackgroundMode boxBackgroundMode) : base(context)
        {
            SetDefaults(boxBackgroundMode);
        }
        public MauiTextInputLayout(Context context, IAttributeSet? attrs, int style, BoxBackgroundMode boxBackgroundMode) : base(context, attrs, style)
        {
            SetDefaults(boxBackgroundMode);
        }

        private void SetDefaults(BoxBackgroundMode boxBackgroundMode)
        {
            
            
            
            SetDefaultClearButton();
        }


        private void SetDefaultClearButton()
        {

            // IMPORTANT: Test focus navigation when changing this code
            //this.EndIconMode = Google.Android.Material.TextField.TextInputLayout.EndIconClearText;
            
            //Post(() =>
            //{
            //    this.EndIconVisible = true;

            //});
            //this.SetEndIconDrawable(Resource.Drawable.ic_clear_2);
            // IMPORTANT: Test focus navigation when changing this code

            //var endiconview = this.FindViewById(Resource.Id.text_input_end_icon);
            //endiconview.Focusable = false;
            //endiconview.FocusableInTouchMode = false;
            //endiconview.SetFocusable(ViewFocusability.NotFocusable);
            this.SetStartIconDrawable(Resource.Drawable.ic_search_black_24);
            // Set icon callback function
            //this.SetEndIconOnClickListener(new OnEndIconClickListener(this));
            // set icon visibility
            //this.EndIconVisible = true;
            // Padding to prevent text from overlapping the button
            //this.MauiTextInputEditText.SetPadding(40,0,120,0);
            // Reduces vertical padding between the button and the borders. Otherwise the entry would be very tall vertically
            //this.EndIconMinSize = 120;
            
            //Task.Run(async () =>
            //{
            //    await Task.Delay(10000);
            //    var startIcon = this.FindViewById<CheckableImageButton>(
            //Resource.Id.text_input_start_icon);
            //    var padding1 = startIcon.PaddingLeft;
            //    var padding3 = startIcon.PaddingRight;
            //    var padding5 = startIcon.PaddingBottom;
            //    var padding4 = startIcon.PaddingTop;
            //});

            //var endicon = this.FindViewById<CheckableImageButton>(
            //Resource.Id.text_input_end_icon);
            ////endicon.SetMinimumHeight(132);
            //endicon.SetMinimumWidth(132);
            //endicon.SetPaddingRelative(24,24,24,24);
            //this.SetPadding(PaddingLeft, PaddingTop, PaddingRight + 48, PaddingBottom);
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
            ITextInputLayout _textInputLayout;
            public OnEndIconClickListener(ITextInputLayout textInputLayout)
            {
                _textInputLayout = textInputLayout;
            }

            public void OnClick(AView? v)
            {
                _textInputLayout.EndIconClicked();
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
