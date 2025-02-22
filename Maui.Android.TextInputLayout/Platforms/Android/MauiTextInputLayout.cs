using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.CoordinatorLayout.Widget;
using Google.Android.Material.TextField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LLayout = Android.Widget.LinearLayout;
using AView = Android.Views.View;
using Android.Util;
namespace Maui.Android.TextInputLayout.Platforms.Android
{
    public class MauiTextInputLayout : Google.Android.Material.TextField.TextInputLayout
    {
        public MauiTextInputEditText MauiTextInputEditText;
        public MauiTextInputLayout(Context context) : base(context)
        {
            SetAttributes(context);
        }
        public MauiTextInputLayout(Context context, IAttributeSet? attrs, int style) : base(context, attrs, style)
        {
            
        }

        private void SetAttributes(Context context)
        {
            LayoutParameters = new LLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
            NormalView(context);
            //ContextThemeView(context);
            //InflateView();
        }

        public void ContextThemeView(Context context)
        {
            var result = new ContextThemeWrapper(context, Resource.Style.Widget_MaterialComponents_TextInputEditText_OutlinedBox);
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
    }
}
