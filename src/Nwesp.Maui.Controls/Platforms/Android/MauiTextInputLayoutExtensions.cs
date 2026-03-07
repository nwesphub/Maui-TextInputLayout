using Android.Graphics.Drawables;
using Android.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maui.Android.TextInputLayout.Models.Enums;

namespace Maui.Android.TextInputLayout.Platforms.Android
{
    public static class MauiTextInputLayoutExtensions
    {
        public static void UpdateBoxBackgroundMode(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            switch (virtualView.BoxBackgroundMode)
            {
                case BoxBackgroundMode.None:
                    break;
                case BoxBackgroundMode.Outline:
                    platformView.BoxBackgroundMode = Google.Android.Material.TextField.TextInputLayout.BoxBackgroundOutline;
                    break;
                case BoxBackgroundMode.Filled:
                    platformView.BoxBackgroundMode = Google.Android.Material.TextField.TextInputLayout.BoxBackgroundFilled;
                    break;
            }
        }
    }
}
