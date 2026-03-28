using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Graphics.Drawable;
using Google.Android.Material.TextField;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Nwesp.Maui.Android.Abstractions;
using Nwesp.Maui.Android.Models.Enums;
using Nwesp.Maui.Android.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Google.Android.Material.TextField.TextInputLayout;
using static Nwesp.Maui.Android.Platforms.Android.MauiTextInputLayout;
using AResource = Android.Resource.Attribute;
using AView = Android.Views.View;
using MColor = Microsoft.Maui.Graphics.Color;

namespace Nwesp.Maui.Android.Platforms.Android.Managers
{
    public static class IconManager
    {
        private static ConcurrentDictionary<string, Drawable> DrawableDictionary = new ();

        public static void UpdateEndIconMode(this MauiTextInputLayout platformView, ITextInputLayout virtualView, IMauiContext? mauiContext)
        {
            platformView.CustomEndIconMode = virtualView.EndIconMode;

            if(platformView.CustomEndIconMode == EndIconMode.Password && virtualView.Content is IEntry entry)
            {
                if(entry.IsPassword)
                {
                    platformView.SetToggleOffPasswordIcon(mauiContext);
                }
                else
                {
                    platformView.SetToggleOnPasswordIcon(mauiContext);
                }
            }
        }

        public static async void SetToggleOffPasswordIcon(this MauiTextInputLayout platformView, IMauiContext? mauiContext)
        {
            platformView.IsPassword = true;
            platformView.EndIconDrawable = await MapCustomIcon(ImageSource.FromFile("eye_off2.svg"), mauiContext);
        }

        public static async void SetToggleOnPasswordIcon(this MauiTextInputLayout platformView, IMauiContext? mauiContext)
        {
            platformView.IsPassword = false;
            platformView.EndIconDrawable = await MapCustomIcon(ImageSource.FromFile("eye_on2.svg"), mauiContext);
        }

        public static void ShowEndIcon(this MauiTextInputLayout platformView)
        {
            platformView.Post(() =>
            {
                platformView.EndIconVisible = true;
            });
        }

        public static void HideEndIcon(this MauiTextInputLayout platformView)
        {
            platformView.Post(() =>
            {
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

        public static async Task MapCustomEndIcon(this MauiTextInputLayout handler, ITextInputLayout entry, IMauiContext? mauiContext)
        {
            handler.EndIconDrawable = await MapCustomIcon(entry.EndIcon, mauiContext);
        }

        public static async Task MapCustomStartIcon(this MauiTextInputLayout handler, ITextInputLayout entry, IMauiContext? mauiContext)
        {
            handler.StartIconDrawable = await MapCustomIcon(entry.StartIcon, mauiContext);
            var startIcon = handler.FindViewById<AppCompatImageButton>(Resource.Id.text_input_start_icon);
            if(startIcon is not null)
            {
                startIcon.Focusable = false;
                startIcon.FocusableInTouchMode = false;
            }
        }

        private static async Task<Drawable?> MapCustomIcon(ImageSource icon, IMauiContext? mauiContext)
        {
            if (icon is null || mauiContext is null)
            {
                return null;
            }
            
            Drawable? drawable = null;
            try
            {
                if (icon is FileImageSource fileImageSource)
                {
                    if (DrawableDictionary.TryGetValue(fileImageSource.File, out Drawable? image))
                    {
                        drawable = image;
                    }
                    else
                    {
                        drawable = await CreateScaledDrawable(icon, mauiContext);
                        if (drawable is not null)
                        {
                            DrawableDictionary.TryAdd(fileImageSource.File, drawable);
                        }
                    }
                }
                else
                {
                    drawable = await CreateScaledDrawable(icon, mauiContext);
                }
            }
            catch(Exception ex) 
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            return drawable;
        }

        private static async Task<Drawable?> CreateScaledDrawable(ImageSource icon, IMauiContext mauiContext)
        {
            var drawable = (await icon.GetPlatformImageAsync(mauiContext))?.Value;
            if (drawable is BitmapDrawable bitmapDrawable && bitmapDrawable.Bitmap is not null)
            {
                var density = DisplayHelper.GetDensity(mauiContext?.Context);
                int sizePx = (int)(DisplayHelper.IconSize * density);

                var scaled = Bitmap.CreateScaledBitmap(
                    bitmapDrawable.Bitmap,
                    sizePx,
                    sizePx,
                    true);

                drawable = new BitmapDrawable(mauiContext?.Context?.Resources, scaled);
            }

            return drawable;
        }
    }
}
