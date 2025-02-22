using Android.Content;
using Android.Widget;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LLayout = Android.Widget.LinearLayout;
namespace Maui.Android.TextInputLayout.Platforms.Android
{
    public class MauiTextInputEditText : Google.Android.Material.TextField.TextInputEditText
    {
        public MauiTextInputEditText(Context context) : base(context)
        {
            SetWidth(50000);

            // Set minimum width to a high number otherwise the input takes up a very small space and is not clickable
            this.SetMinimumWidth(1000000);
            LayoutParameters = new LLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
            
            SetMaxLines(1);
            SetSingleLine(true);
        }
    }
}