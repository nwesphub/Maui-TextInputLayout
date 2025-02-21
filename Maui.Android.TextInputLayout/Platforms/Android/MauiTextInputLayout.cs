using Android.Content;
using Android.Views;
using Android.Widget;
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
        public MauiTextInputLayout(Context context, ITextInputLayout layout) : base(context)
        {
            RelativeLayout relativeLayout = new RelativeLayout(context)
            {
                LayoutParameters = new CoordinatorLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent)
                {
                    Gravity = (int)GravityFlags.Center
                }
            };

            // Create a VideoView and position it in the RelativeLayout
            Google.Android.Material.TextField.TextInputLayout view = new Google.Android.Material.TextField.TextInputLayout(context)
            {
                LayoutParameters = new RelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent)
            };

            LayoutInflater inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);
            var view2 = inflater.Inflate(Resource.Layout.maui_text_input_layout, null, true);
            this.AddView(view2);
            // Add to the layouts
            relativeLayout.AddView(view);
            AddView(relativeLayout);
        }
    }
}
