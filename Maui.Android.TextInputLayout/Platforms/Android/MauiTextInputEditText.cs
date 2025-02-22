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
            LayoutParameters = new LLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.MatchParent);
            SetMaxLines(1);
            SetSingleLine(true);
        }
    }
}