using Android.Content.PM;
using Android.Content.Res;
using Android.Views;
using AndroidX.AppCompat.View;
using Maui.Android.TextInputLayout.Platforms.Android;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Icu.Text.CaseMap;
using static Android.Provider.MediaStore;
using AColor = Android.Graphics.Color;
using ContextThemeWrapper = AndroidX.AppCompat.View.ContextThemeWrapper;
using RResource = Android.Resource.Attribute;
using AView = Android.Views.View;
using Maui.Android.TextInputLayout.Platforms.Android.Managers;
using Javax.Crypto;
using Android.Graphics.Drawables;
using Android.Graphics;
using Maui.Android.TextInputLayout.Models.Enums;
using Android.Content;
using Android.Widget;
using Google.Android.Material.TextField;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace Maui.Android.TextInputLayout
{
    public partial class TextInputLayoutHandler : ViewHandler<ITextInputLayout, MauiTextInputLayout>
    {
        protected override MauiTextInputLayout CreatePlatformView()
        {
            var contextThemeWrapper = new ContextThemeWrapper(Context, Resource.Style.Widget_Material3_TextInputLayout_OutlinedBox_Dense);
            return new MauiTextInputLayout(contextThemeWrapper);
        }

        public TaskCompletionSource TaskCompletionSource { get; set; } = new();
        public override void SetVirtualView(IView view)
        {
            base.SetVirtualView(view);
            VirtualEntry = VirtualView.Content as ITextInputEditText ?? throw new Exception("VirtualView.Content is not ITextInputEditText");
            if(MauiContext is null)
            {
                throw new Exception("MauiContext is null");
            }
            MauiTextInputEditText editText =  VirtualView.Content.ToPlatform(MauiContext) as MauiTextInputEditText ?? throw new Exception("content is not MauiTextInputEditText");
            editText.SetDefaults();
            
            PlatformEntry = editText;
            
            float targetDp = 48f;

            // Convert DP to pixels using screen density

            ImageView icon = new ImageView(Context);
            icon.SetImageResource(Resource.Drawable.ic_clear);

            //int sizePx = 100;
            //IImageSourceServiceResult<Drawable>? drawable = await entry.EndIcon.GetPlatformImageAsync(handler.MauiContext);
            PlatformView.LayoutParameters = new RelativeLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent,
                ViewGroup.LayoutParams.WrapContent
            );
            var iconParams = new RelativeLayout.LayoutParams(
                24,
                24
            );
            iconParams.AddRule(LayoutRules.AlignParentStart);
            iconParams.AddRule(LayoutRules.CenterVertical);
            iconParams.SetMargins(24, 0, 24, 0);
            icon.LayoutParameters = iconParams;
            //var bitmapDrawable = ((BitmapDrawable)drawable.Value).Bitmap;
            //var bitmap = Bitmap.CreateScaledBitmap(bitmapDrawable, sizePx, sizePx, false);
            //Drawable drawable2 = new BitmapDrawable(bitmap);
            //handler.PlatformView.EndIconDrawable = drawable2;
            //handler.PlatformView.SetEndIconTintList(null);
            RelativeLayout container = new RelativeLayout(Context);
            container.LayoutParameters = new RelativeLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent,
                ViewGroup.LayoutParams.WrapContent
            );
            container.AddView(icon);
            PlatformView.AddView(PlatformEntry);
            //container.AddView(PlatformView);
            TaskCompletionSource.SetResult();
        }

        protected override void ConnectHandler(MauiTextInputLayout platformView)
        {
            PlatformView.SetEndIconOnClickListener(VirtualView);
        }

        public static void MapBackgroundColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            return;

        }

        public static void MapBackground(ITextInputLayoutHandler handler, ITextInputLayout entry) 
        {
            
        }
        public static void MapBorderColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            var style = handler.MauiContext.Context.Resources.GetIdentifier("CursorColor", "style", handler.MauiContext.Context.PackageName);
            handler.PlatformView.Context.Theme.ApplyStyle(style, true);
            BorderManager.MapBorderColor(handler, entry);
        }
        public static void MapFocusedBorderColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            BorderManager.MapFocusedBorderColor(handler, entry);
        }
        public static void MapHint(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            HintManager.MapHint(handler, entry);
        }
        public static void MapDefaultHintColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            HintManager.MapDefaultHintTextColor(handler, entry);
        }
        public static void MapFocusedHintColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            HintManager.MapFocusedHintTextColor(handler, entry);
        }
        public static void MapIsHintAnimated(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            HintManager.MapIsHintAnimated(handler, entry);
        }
        public static async void MapEndIcon(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            return;
            if(entry.EndIcon is null)
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
            catch(Exception ex)
            {

            }
        }

        public static double GetIdealSize(double density)
        {
            return 120 * density - 130;
        }
        public static async void MapBoxBackgroundMode(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            switch (entry.BoxBackgroundMode)
            {
                case BoxBackgroundMode.None:
                    break;
                case BoxBackgroundMode.Outline:
                    handler.PlatformView.BoxBackgroundMode = Google.Android.Material.TextField.TextInputLayout.BoxBackgroundOutline;
                    
                    break;
                case BoxBackgroundMode.Filled:
                    handler.PlatformView.BoxBackgroundMode = Google.Android.Material.TextField.TextInputLayout.BoxBackgroundFilled;
                    break;
            }
        }
        public static async void MapEndIconVisibilityMode(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            // TODO: refactor to remove tcs
            if (handler is TextInputLayoutHandler h2)
            {
                await h2.TaskCompletionSource.Task;
            }
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
                    if(string.IsNullOrWhiteSpace(handler.PlatformEntry.Text))
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
            if (sender is MauiTextInputEditText editText && editText?.Parent?.Parent is MauiTextInputLayout layout)
            {
                EndIconVisibilityChanged(editText, layout);
            }
        }

        private static void EndIconVisibilityFocusChanged(object? sender, AView.FocusChangeEventArgs e)
        {
            if (sender is MauiTextInputEditText editText && editText?.Parent?.Parent is MauiTextInputLayout layout)
            {
                editText.HasFocus = e.HasFocus;
                EndIconVisibilityChanged(editText, layout);
            }
        }

        private static void EndIconVisibilityChanged(MauiTextInputEditText editText, MauiTextInputLayout layout)
        {
            if(editText.HasFocus && !string.IsNullOrWhiteSpace(editText.Text))
            {
                layout.EndIconVisible = true;
            }
            else
            {
                layout.EndIconVisible = false;
            }
        }
    }
}
