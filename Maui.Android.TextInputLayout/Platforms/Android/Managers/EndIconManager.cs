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

namespace Maui.Android.TextInputLayout.Platforms.Android.Managers
{
    public static class EndIconManager
    {
        public static async void MapEndIconVisibilityMode(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            //return;
            handler.PlatformEntry.FocusChange -= EndIconVisibilityFocusChangedWhileEditing;
            handler.PlatformEntry.TextChanged -= EndIconVisibilityFocusChangedWhileEditing;
            await Task.Delay(5000);
            switch (entry.EndIconVisibilityMode)
            {
                case IconVisibilityMode.Never:
                    handler.PlatformView.EndIconVisible = false;
                    break;
                case IconVisibilityMode.Always:
                    handler.PlatformView.Post(() =>
                    {
                        handler.PlatformView.EndIconVisible = true;

                    });
                    break;
                case IconVisibilityMode.WhileEditing:
                    if (string.IsNullOrWhiteSpace(handler.PlatformEntry.Text))
                    {
                        handler.PlatformView.EndIconVisible = false;
                    }
                    var text = handler.PlatformView.EditText.Text;
                    var text2 = handler.PlatformEntry.Text;
                    handler.PlatformView.EditText.FocusChange += EndIconVisibilityFocusChangedWhileEditing;
                    handler.PlatformView.EditText.TextChanged += EndIconVisibilityFocusChangedWhileEditing;
                    break;
                case IconVisibilityMode.HasText:
                    break;
            }

            
        }

        private static void EndIconVisibilityFocusChangedWhileEditing(object? sender, global::Android.Text.TextChangedEventArgs e)
        {
            if (sender is EditText editText && editText?.Parent?.Parent is MauiTextInputLayout layout)
            {
                EndIconVisibilityChangedWhileEditing(editText, layout);
            }
        }

        private static void EndIconVisibilityFocusChangedWhileEditing(object? sender, AView.FocusChangeEventArgs e)
        {
            if (sender is EditText editText && editText?.Parent?.Parent is MauiTextInputLayout layout)
            {
                EndIconVisibilityChangedWhileEditing(editText, layout);
            }
        }

        private static void EndIconVisibilityChangedWhileEditing(EditText editText, MauiTextInputLayout layout)
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
            EndIconVisibilityChangedWhileEditing(handler.PlatformEntry, handler.PlatformView);
        }

        public static void MapEndIconColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {

            if (entry.EndIconColor is null)
            {
                handler.PlatformView.SetEndIconTintList(null);
                return;
            }

            handler.PlatformView.SetEndIconTintList
            (
                new ColorStateList
                (
                    [
                        [-RResource.StateEnabled],
                        [RResource.StateEnabled],
                    ],
                    [
                        entry.EndIconDisabledColor.WithAlpha(entry.DisabledEndIconOpacity).ToAndroid(),
                        entry.EndIconColor.ToAndroid()
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
                int sizePx = (int)GetIdealSize(density);
                IImageSourceServiceResult<Drawable>? drawable = await entry.EndIcon.GetPlatformImageAsync(handler.MauiContext);

                var bitmapDrawable = ((BitmapDrawable)drawable.Value).Bitmap;
                var bitmap = Bitmap.CreateScaledBitmap(bitmapDrawable, sizePx, sizePx, false);
                Drawable drawable2 = new BitmapDrawable(bitmap);
                handler.PlatformView.EndIconDrawable = drawable2;
                //await Task.Delay(5000);
                handler.PlatformView.SetEndIconTintList(null);
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
