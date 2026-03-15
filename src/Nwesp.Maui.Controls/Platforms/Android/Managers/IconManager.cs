using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Graphics;
using Nwesp.Maui.Android.Models.Enums;
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
using static Nwesp.Maui.Android.Platforms.Android.MauiTextInputLayout;
using AndroidX.Core.Graphics.Drawable;
using MColor = Microsoft.Maui.Graphics.Color;
using Nwesp.Maui.Android.Abstractions;
using static Google.Android.Material.TextField.TextInputLayout;
using System.Collections.Concurrent;
using Microsoft.Maui;
using Android.Text;
using System.Runtime.CompilerServices;

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
        }

        private static async Task<Drawable?> MapCustomIcon(ImageSource icon, IMauiContext? mauiContext)
        {
            if (icon is null || mauiContext is null)
            {
                return null;
            }
            
            Drawable? result = null;
            try
            {
                if (icon is FileImageSource fileImageSource)
                {
                    if (DrawableDictionary.TryGetValue(fileImageSource.File, out Drawable? image))
                    {
                        result = image;
                    }
                    else
                    {
                        result = (await icon.GetPlatformImageAsync(mauiContext))?.Value;
                        if (result is not null)
                        {
                            DrawableDictionary.TryAdd(fileImageSource.File, result);
                        }
                    }
                }
                else
                {
                    result = (await icon.GetPlatformImageAsync(mauiContext))?.Value;
                }
            }
            catch(Exception ex) 
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            return result;
        }
    }
}
