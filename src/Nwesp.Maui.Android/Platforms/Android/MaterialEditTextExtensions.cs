using Android.Content.Res;
using Android.Widget;
using Nwesp.Maui.Android.Utilities;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AResource = Android.Resource.Attribute;
using Nwesp.Maui.Android.Abstractions;
using Android.Text;
using Microsoft.Maui;
namespace Nwesp.Maui.Android.Platforms.Android
{
    public static class MaterialEditTextExtensions
    {
        public static void UpdateTextColor(this EditText editText, IMaterialEntry entry)
        {
            int[][] states =
            [
                [AResource.StateEnabled],
                [-AResource.StateEnabled]
            ];
            
            int[] colors =
            [
                entry.TextColor.ToPlatform(),
                entry.DisabledTextColor.WithAlpha(entry.DisabledTextColorOpacity).ToPlatform()
            ];

            editText.SetTextColor(new ColorStateList(states, colors));
        }

        public static void TogglePasswordOn(this EditText editText)
        {
            if (editText.InputType.HasFlag(InputTypes.ClassText))
                editText.InputType |= InputTypes.TextVariationPassword;
            if (editText.InputType.HasFlag(InputTypes.ClassNumber))
                editText.InputType |= InputTypes.NumberVariationPassword;
        }

        public static void TogglePasswordOff(this EditText editText)
        {
            if (editText.InputType.HasFlag(InputTypes.ClassText))
                editText.InputType &= ~InputTypes.TextVariationPassword;
            if (editText.InputType.HasFlag(InputTypes.ClassNumber))
                editText.InputType &= ~InputTypes.NumberVariationPassword;
        }
    }
}
