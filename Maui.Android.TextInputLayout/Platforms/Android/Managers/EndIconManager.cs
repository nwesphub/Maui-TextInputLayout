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

namespace Maui.Android.TextInputLayout.Platforms.Android.Managers
{
    public static class EndIconManager
    {
        public static void MapEndIconVisibilityMode(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            
            handler.PlatformEntry.FocusChange -= EndIconVisibilityFocusChanged;
            handler.PlatformEntry.TextChanged -= EndIconVisibilityFocusChanged;
            switch (entry.EndIconVisibilityMode)
            {
                case IconVisibilityMode.Never:
                    handler.PlatformView.EndIconVisible = false;
                    break;
                case IconVisibilityMode.Always:
                    handler.PlatformView.EndIconVisible = true;
                    break;
                case IconVisibilityMode.WhileEditing:
                    if (string.IsNullOrWhiteSpace(handler.PlatformEntry.Text))
                    {
                        handler.PlatformView.EndIconVisible = false;
                    }
                    handler.PlatformEntry.FocusChange += EndIconVisibilityFocusChanged;
                    handler.PlatformEntry.TextChanged += EndIconVisibilityFocusChanged;
                    break;
            }
        }

        private static void EndIconVisibilityFocusChanged(object? sender, global::Android.Text.TextChangedEventArgs e)
        {
            if (sender is EditText editText && editText?.Parent?.Parent is MauiTextInputLayout layout)
            {
                EndIconVisibilityChanged(editText, layout);
            }
        }

        private static void EndIconVisibilityFocusChanged(object? sender, AView.FocusChangeEventArgs e)
        {
            if (sender is EditText editText && editText?.Parent?.Parent is MauiTextInputLayout layout)
            {
                //editText.HasFocus = e.HasFocus;
                EndIconVisibilityChanged(editText, layout);
            }
        }

        private static void EndIconVisibilityChanged(EditText editText, MauiTextInputLayout layout)
        {
            
            if (editText.HasFocus && !string.IsNullOrWhiteSpace(editText.Text) && editText.Enabled)
            {
                layout.EndIconVisible = true;
            }
            else
            {
                layout.EndIconVisible = false;
            }
        }

        public static void MapIsEnabled(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            EndIconVisibilityChanged(handler.PlatformEntry, handler.PlatformView);
        }

        public static void MapEndIconColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            if (entry.EndIconColor is null)
            {
                return;
            }
            var color = entry.EndIconColor.ToAndroid();
            handler.PlatformView.SetEndIconTintList
            (
                new ColorStateList
                (
                    [
                        [-RResource.StateFocused],
                        [RResource.StateFocused],
                    ],
                    [
                        color,
                        color
                    ]
                )
            );
        }

        public static async void MapEndIcon(ITextInputLayoutHandler handler, ITextInputLayout entry)
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
                float density = handler.PlatformView.Context.Resources.DisplayMetrics.Density;
                int sizePx = (int)(targetDp * (density + 0.5f)); // round to nearest pixel
                sizePx = (int)GetIdealSize(density); ;
                IImageSourceServiceResult<Drawable>? drawable = await entry.EndIcon.GetPlatformImageAsync(handler.MauiContext);

                var bitmapDrawable = ((BitmapDrawable)drawable.Value).Bitmap;
                var bitmap = Bitmap.CreateScaledBitmap(bitmapDrawable, sizePx, sizePx, false);
                Drawable drawable2 = new BitmapDrawable(bitmap);
                handler.PlatformView.EndIconDrawable = drawable2;
                handler.PlatformView.SetEndIconTintList(null);
            }
            catch (Exception ex)
            {

            }
        }

        private static double GetIdealSize(double density)
        {
            return 120 * density - 130;
        }
    }
}
