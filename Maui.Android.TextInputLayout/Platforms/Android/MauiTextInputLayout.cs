using Android.Content;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using AView = Android.Views.View;
using LLayout = Android.Widget.LinearLayout;
namespace Maui.Android.TextInputLayout.Platforms.Android
{
    public class MauiTextInputLayout : Google.Android.Material.TextField.TextInputLayout
    {
        public MauiTextInputEditText MauiTextInputEditText;
        public MauiTextInputLayout(Context context) : base(context)
        {
            SetDefaults(context);
        }
        public MauiTextInputLayout(Context context, IAttributeSet? attrs, int style) : base(context, attrs, style)
        {
            
        }

        private void SetDefaults(Context context)
        {
            // Not needed anymore?
            //LayoutParameters = new LLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
            this.BoxBackgroundMode = Google.Android.Material.TextField.TextInputLayout.BoxBackgroundOutline;
            this.SetBoxCornerRadii(8 ,8, 8, 8);
  
            this.BoxStrokeWidth = 3;
            this.BoxStrokeWidthFocused = 3;

            ContextThemeView(context);

            SetDefaultClearButton();
        }

        public void ContextThemeView(Context context)
        {
            var result = new ContextThemeWrapper(context, Resource.Style.Widget_Material3_TextInputLayout_OutlinedBox);
            MauiTextInputEditText = new MauiTextInputEditText(result);
            this.AddView(MauiTextInputEditText);
        }

        public void NormalView(Context context)
        {
            MauiTextInputEditText = new MauiTextInputEditText(context);
            this.AddView(MauiTextInputEditText);
        }

        public void InflateView()
        {
            LayoutInflater inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);
            Google.Android.Material.TextField.TextInputLayout view = inflater.Inflate(Resource.Layout.maui_text_input_layout, null, true) as Google.Android.Material.TextField.TextInputLayout;
            this.AddView(view);
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
            this.MauiTextInputEditText.SetPadding(40,0,120,0);
            // Reduces vertical padding between the button and the borders. Otherwise the entry would be very tall vertically
            this.EndIconMinSize = 120;
            // Removes the underline under the text in the entry
            this.MauiTextInputEditText.InputType = InputTypes.TextVariationVisiblePassword | InputTypes.TextFlagNoSuggestions;
        }

        public class OnEndIconClickListener : Java.Lang.Object, IOnClickListener
        {
            MauiTextInputLayout _layout;
            public OnEndIconClickListener(MauiTextInputLayout layout)
            {
                _layout = layout;
            }
            public void OnClick(AView? v)
            {
                _layout.MauiTextInputEditText.Text = string.Empty;
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
