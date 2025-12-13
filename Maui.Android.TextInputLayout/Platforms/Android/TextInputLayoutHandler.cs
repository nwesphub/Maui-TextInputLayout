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
            PlatformView.AddView(PlatformEntry);
            TaskCompletionSource.SetResult();
        }

        protected override void ConnectHandler(MauiTextInputLayout platformView)
        {
            // This code used to be in SetVirtualView
            VirtualEntry = VirtualView.Content as ITextInputEditText ?? throw new Exception("VirtualView.Content is not ITextInputEditText");
            MauiTextInputEditText editText = VirtualView.Content.ToPlatform(MauiContext) as MauiTextInputEditText ?? throw new Exception("content is not MauiTextInputEditText");
            editText.SetDefaults();
            PlatformEntry = editText;
            // This code used to be in SetVirtualView

            PlatformView.SetEndIconOnClickListener(VirtualView);
        }

        public static void MapBackgroundColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {

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

        public static void MapCursorColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            
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

        public static void MapEndIconColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            EndIconManager.MapEndIconColor(handler, entry);
        }

        public static void MapEndIcon(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            EndIconManager.MapEndIcon(handler, entry);
        }

        public static async void MapEndIconVisibilityMode(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            EndIconManager.MapEndIconVisibilityMode(handler, entry);
        }

        private static void MapIsEnabled(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            ViewHandler.MapIsEnabled(handler, entry);
            EndIconManager.MapIsEnabled(handler, entry);
        }
    }
}
