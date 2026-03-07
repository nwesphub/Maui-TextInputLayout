using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Graphics;
using Maui.Android.TextInputLayout.Models.Enums;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AView = Android.Views.View;
using AResource = Android.Resource.Attribute;
using Android.Widget;
using Microsoft.Maui.Platform;
using Google.Android.Material.TextField;
using static Maui.Android.TextInputLayout.Platforms.Android.MauiTextInputLayout;
using AndroidX.Core.Graphics.Drawable;
using MColor = Microsoft.Maui.Graphics.Color;

namespace Maui.Android.TextInputLayout.Platforms.Android.Managers
{
    public static class IconManager
    {

        public static async void ShowEndIcon(this MauiTextInputLayout platformView, ITextInputLayout virtualView, IMauiContext mauiContext)
        {
           
            platformView.EndIconVisible = true;
            platformView.Post(() =>
            {
            
                platformView.EndIconMode = Google.Android.Material.TextField.TextInputLayout.EndIconClearText;
                platformView.SetEndIconDrawable(Resource.Drawable.ic_clear_2);
                platformView.MapCustomEndIcon(virtualView, mauiContext);
                platformView.SetEndIconOnClickListener(new OnEndIconClickListener(virtualView));
            });
            
        }

        public static void HideEndIcon(this MauiTextInputLayout platformView)
        {
            
            platformView.Post(() =>
            {
                platformView.EndIconMode = Google.Android.Material.TextField.TextInputLayout.EndIconNone;
                platformView.EndIconVisible = false;
            });
        }


        public static void UpdateEndIconColor(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            if (virtualView.EndIconColor is null)
            {
                platformView.SetEndIconTintList(null);
                return;
            }

            platformView.SetEndIconTintList(GetIconColorStateList(virtualView.EndIconColor, virtualView.DisabledEndIconColor, virtualView.DisabledEndIconOpacity));
        }

        private static ColorStateList GetIconColorStateList(MColor iconColor, MColor disabledColor, float disabledColorOpacity)
        {
            int[][] states =
            [
                [-AResource.StateEnabled],
                [AResource.StateEnabled],
            ];
            int[] colors =
            [
                disabledColor.WithAlpha(disabledColorOpacity).ToAndroid(),
                iconColor.ToAndroid()
            ];
            return new ColorStateList(states, colors);
        }

        public static void UpdateStartIconColor(this MauiTextInputLayout platformView, ITextInputLayout virtualView)
        {
            if (virtualView.StartIconColor is null)
            {
                platformView.SetStartIconTintList(null);
                return;
            }

            platformView.SetStartIconTintList(GetIconColorStateList(virtualView.StartIconColor, virtualView.DisabledStartIconColor, virtualView.DisabledStartIconOpacity));
        }

        public static async void MapCustomEndIcon(this MauiTextInputLayout handler, ITextInputLayout entry, IMauiContext mauiContext)
        {
            //return;
            if (entry.EndIcon is null)
            {
                return;
            }
            try
            {


                var result = await entry.EndIcon.GetPlatformImageAsync(mauiContext);
                if (result?.Value is not BitmapDrawable bitmapDrawable)
                    return;

                // Convert 24dp to pixels
                float density = handler.Context.Resources.DisplayMetrics.Density;
                int sizePx = (int)(24 * density + 0.5f);

                var scaledBitmap = Bitmap.CreateScaledBitmap(
                    bitmapDrawable.Bitmap,
                    sizePx,
                    sizePx,
                    true);

                var drawable = new BitmapDrawable(handler.Context.Resources, scaledBitmap);

                handler.EndIconDrawable = drawable;
                handler.SetEndIconTintList(null);
                
            }
            catch (Exception ex)
            {

            }
        }

        public static async void MapCustomStartIcon(this MauiTextInputLayout handler, ITextInputLayout entry, IMauiContext mauiContext)
        {
            //return;
            if (entry.StartIcon is null)
            {
                return;
            }
            try
            {
                var result = await entry.StartIcon.GetPlatformImageAsync(mauiContext);
                handler.StartIconDrawable = result.Value;
                handler.SetStartIconTintList(null);

            }
            catch (Exception ex)
            {

            }
        }


    }
}
