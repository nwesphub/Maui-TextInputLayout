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
using Android.Views;
using Maui.Android.TextInputLayout.Models.Enums;
namespace Maui.Android.TextInputLayout.Platforms.Android
{
    public class MauiTextInputEditText : Google.Android.Material.TextField.TextInputEditText
    {
        public new bool HasFocus { get; set; }
        public MauiTextInputEditText(Context context, IAttributeSet? attrs, int style) : base(context, attrs, style)
        {
            SetDefaults();
        }
        public MauiTextInputEditText(Context context) : base(context)
        {
            SetDefaults();
        }

        public MauiTextInputEditText(Context context, BoxBackgroundMode boxBackgroundMode) : base(context)
        {
            SetDefaults();
            this.SetPadding(40, 38, 100, 30);
        }

        public void SetDefaults()
        {
            this.TextSize = 14;
            
            // Set minimum width to a high number otherwise the input takes up a very small space and is not clickable
            this.SetMinimumWidth(1000000);
            // this.SetPadding(40, 38, 100, 30); - Potential padding for layout with border - box background
            this.SetPadding(PaddingLeft, PaddingTop, PaddingRight, PaddingBottom);
         
            SetSingleLine(true);
        }
    }
}