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
using RResource = Android.Resource.Attribute;
using Android.Widget;
using Microsoft.Maui.Platform;
using Google.Android.Material.TextField;
using static Maui.Android.TextInputLayout.Platforms.Android.MauiTextInputLayout;

namespace Maui.Android.TextInputLayout.Platforms.Android.Managers
{
    public static class EndIconManager
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

            platformView.SetEndIconTintList
            (
                new ColorStateList
                (
                    [
                        [-RResource.StateEnabled],
                        [RResource.StateEnabled],
                    ],
                    [
                        virtualView.EndIconDisabledColor.WithAlpha(virtualView.DisabledEndIconOpacity).ToAndroid(),
                        virtualView.EndIconColor.ToAndroid()
                    ]
                )
            );
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
                // higher density needs to be bigger
                // lower density needs to be smaller
                // high density = 2.75
                // low density = 1.5
                // high density = 156
                // low density = 96

                // low density ideal = 50
                // high density ideal = 200
                // Target size in DP
                float targetDp = 48f;

                // Convert DP to pixels using screen density
                float density = handler.Context.Resources.DisplayMetrics.Density;
                int sizePx = (int)GetIdealSize(density);
                IImageSourceServiceResult<Drawable>? drawable = await entry.EndIcon.GetPlatformImageAsync(mauiContext);

                var bitmapDrawable = ((BitmapDrawable)drawable.Value).Bitmap;
                var bitmap = Bitmap.CreateScaledBitmap(bitmapDrawable, sizePx, sizePx, false);
                Drawable drawable2 = new BitmapDrawable(bitmap);
                handler.EndIconDrawable = drawable2;
                //await Task.Delay(5000);
                handler.SetEndIconTintList(null);
            }
            catch (Exception ex)
            {

            }
        }

        private static double GetIdealSize(double density)
        {
            return 150 * density - 130;
        }
    }
}
