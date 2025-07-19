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

namespace Maui.Android.TextInputLayout
{
    public partial class TextInputLayoutHandler : ViewHandler<ITextInputLayout, MauiTextInputLayout>
    {
        public MauiTextInputLayout NativeLayout { get; set; }
        public MauiTextInputEditText NativeEntry { get; set; }
        public ITextInputEditText PlatformEntry { get; set; }

        protected override MauiTextInputLayout CreatePlatformView()
        {
            return InternalCreateContextThemeView();
        }

        private MauiTextInputLayout InternalCreatePlatformView()
        {
            NativeLayout = new MauiTextInputLayout(Context);
            return NativeLayout;
        }

        TaskCompletionSource tcs = new();
        private MauiTextInputLayout InternalCreateContextThemeView()
        {
            var result = new ContextThemeWrapper(Context, Resource.Style.Widget_Material3_TextInputLayout_OutlinedBox_Dense); // Widget_Material3_TextInputEditText_OutlinedBox
            NativeLayout = new MauiTextInputLayout(result);
            return NativeLayout;
        }

        public override void SetVirtualView(IView view)
        {
            base.SetVirtualView(view);
            PlatformEntry = VirtualView.Content as ITextInputEditText ?? throw new Exception("VirtualView.Content is not ITextInputEditText");
            if(MauiContext is null)
            {
                throw new Exception("MauiContext is null");
            }
            MauiTextInputEditText content =  VirtualView.Content.ToPlatform(MauiContext) as MauiTextInputEditText ?? throw new Exception("content is not MauiTextInputEditText");
            content.SetDefaults();
            NativeEntry = content;
 
            PlatformView.AddView(NativeEntry);
            tcs.SetResult();
        }
        protected override void ConnectHandler(MauiTextInputLayout platformView)
        {
            base.ConnectHandler(platformView);
        }

        public static async void MapBackgroundColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            
            //handler.PlatformView.SetBackgroundColor(entry?.BackgroundColor?.ToPlatform() ?? new AColor());
            //handler.PlatformView.MauiTextInputEditText.SetBackgroundColor(entry?.BackgroundColor?.ToPlatform() ?? new AColor());
            int[][] states =
            [
                [-RResource.StateFocused],
                [RResource.StateFocused],
            ];

            int[] colors =
            [
                entry?.BackgroundColor?.ToPlatform() ?? new AColor(),
                entry?.BackgroundColor?.ToPlatform() ?? new AColor()
            ];
            ColorStateList csl = new ColorStateList(states, colors);
            
            if(handler is TextInputLayoutHandler layoutHandler)
            {
                await layoutHandler.tcs.Task;
                if (layoutHandler.NativeEntry is not null) {
                    layoutHandler.NativeEntry.SetBackgroundColor(entry?.BackgroundColor?.ToPlatform() ?? new AColor());
                    layoutHandler.NativeEntry.BackgroundTintList = csl;
                }
            }
            //handler.PlatformView.MauiTextInputEditText.BackgroundTintList = csl;

        }

        public static void MapBackground(ITextInputLayoutHandler handler, ITextInputLayout entry) 
        {
            
        }
        public static void MapBorderColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
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
        public static void MapContent(ITextInputLayoutHandler handler, ITextInputLayout layout)
        {
            
        }
    }
}
