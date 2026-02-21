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
            if (boxBackgroundMode == BoxBackgroundMode.Outline)
            {
                // Pixel 5 - 2.75x
                int left = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 14.54f, Context.Resources.DisplayMetrics);
                int top = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 13.81f, Context.Resources.DisplayMetrics);
                int right = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 36.36f, Context.Resources.DisplayMetrics);
                int bottom = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 10.91f, Context.Resources.DisplayMetrics);
                //this.SetPadding(left, top, right, bottom);
                //this.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 48, Context.Resources.DisplayMetrics)); // Fix for 240 dp devices having a ton of padding when focused
                //this.SetPadding(40, 38, 100, 30);
            }
        }

        public void SetDefaults()
        {
            this.TextSize = 14;
            
            // Set minimum width to a high number otherwise the input takes up a very small space and is not clickable
            this.SetMinimumWidth(1000000);
            // this.SetPadding(40, 38, 100, 30); - Potential padding for layout with border - box background
            //this.SetPadding(PaddingLeft, PaddingTop, PaddingRight + 24, PaddingBottom);
         
            SetSingleLine(true);
        }

        public static void SetStaticDefaults(EditText editText)
        {
            //editText.TextSize = 14;

            // Set minimum width to a high number otherwise the input takes up a very small space and is not clickable
            editText.SetMinimumWidth(1000000);
            // this.SetPadding(40, 38, 100, 30); - Potential padding for layout with border - box background
            //editText.SetPadding(PaddingLeft, PaddingTop, PaddingRight, PaddingBottom);
            // + 24 if icon?
            //editText.SetPadding(editText.PaddingLeft, editText.PaddingTop, editText.PaddingRight + 24, editText.PaddingBottom);
            editText.SetSingleLine(true);
        }
    }
}