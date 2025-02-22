using Android.Content;
using Android.Widget;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AText = Android.Text.InputTypes;
using ALayout = Android.Views.ViewGroup;
using AContext = Android.Content.Context;
namespace Maui.Android.TextInputLayout.Platforms.Android
{
    public class MauiTextInputEditText : Google.Android.Material.TextField.TextInputEditText
    {
        AContext _context;
        public MauiTextInputEditText(Context context) : base(context)
        {
            _context = context;
        
            
            //this.LayoutParameters = new ALayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
            this.SetSingleLine(true);
        }
    }
}