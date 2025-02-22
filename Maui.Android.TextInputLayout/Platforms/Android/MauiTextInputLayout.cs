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

namespace Maui.Android.TextInputLayout.Platforms.Android
{
    public class MauiTextInputLayout : Google.Android.Material.TextField.TextInputLayout
    {
        public MauiTextInputEditText MauiTextInputEditText;
        public MauiTextInputLayout(Context context, ITextInputLayout layout) : base(context)
        {
            MauiTextInputEditText = new MauiTextInputEditText(context);
            
            this.AddView(MauiTextInputEditText);
        }
    }
}
