using Android.Content;
using Android.Widget;
using AndroidX.AppCompat.View;
using Nwesp.Maui.Android.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nwesp.Maui.Android.Utilities
{
    public static class ContextThemeHelper
    {
        public static T BuildContextThemeWrapper<T>(Context context, BoxBackgroundMode boxBackgroundMode, Func<Context, T> constructor) where T : EditText
        {
            if (boxBackgroundMode == BoxBackgroundMode.None)
            {
                return constructor(context);
            }

            int style = Resource.Style.ThemeOverlay_Material3_TextInputEditText_OutlinedBox_Dense;
            if (boxBackgroundMode == BoxBackgroundMode.Filled)
            {
                style = Resource.Style.ThemeOverlay_Material3_TextInputEditText_FilledBox_Dense;
            }
            var contextThemeWrapper = new ContextThemeWrapper(context, style);

            T editText = constructor(contextThemeWrapper);
            return editText;
        }
    }
}
