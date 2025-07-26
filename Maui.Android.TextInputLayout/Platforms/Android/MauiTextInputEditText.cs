using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Widget;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RResource = Android.Resource.Attribute;
using LLayout = Android.Widget.LinearLayout;
namespace Maui.Android.TextInputLayout.Platforms.Android
{
    public class MauiTextInputEditText : Google.Android.Material.TextField.TextInputEditText
    {
        public MauiTextInputEditText(Context context, IAttributeSet? attrs, int style) : base(context, attrs, style)
        {
            SetDefaults();
        }
        public MauiTextInputEditText(Context context) : base(context)
        {
            SetDefaults();
        }

        public void SetDefaults()
        {
            this.TextSize = 14;
            
            // Set minimum width to a high number otherwise the input takes up a very small space and is not clickable
            this.SetMinimumWidth(1000000);
            SetSingleLine(true);
        }
    }
}