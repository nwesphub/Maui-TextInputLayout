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
using Nwesp.Maui.Android.Models.Enums;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using AView = Android.Views.View;
using LLayout = Android.Widget.LinearLayout;
using AResource = Android.Resource.Attribute;
using ASound = Android.Views.SoundEffects;
using Nwesp.Maui.Android.Abstractions;
namespace Nwesp.Maui.Android.Platforms.Android
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
            //EndIconVisible = false;
            EndIconMode = Google.Android.Material.TextField.TextInputLayout.EndIconClearText;
            
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

        public class OnStartIconClickListener : Java.Lang.Object, IOnClickListener
        {
            ITextInputLayout _textInputLayout;
            public OnStartIconClickListener(ITextInputLayout textInputLayout)
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
