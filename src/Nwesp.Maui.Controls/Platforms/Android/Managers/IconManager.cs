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

namespace Nwesp.Maui.Android.Platforms.Android.Managers
{
    public static class IconManager
    {

        public static async void ShowEndIcon(this MauiTextInputLayout platformView, ITextInputLayout virtualView, IMauiContext mauiContext)
        {
    
            platformView.Post(async () =>
            {
                platformView.EndIconVisible = true;
                await platformView.MapCustomEndIcon(virtualView, mauiContext);
                platformView.SetEndIconOnClickListener(new OnEndIconClickListener(virtualView));
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
            handler.StartIconDrawable =  await MapCustomIcon(entry.StartIcon, mauiContext);
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
                result = (await icon.GetPlatformImageAsync(mauiContext))?.Value;
            }
            catch(Exception) 
            { 
            }

            return result;
        }

    }
}
