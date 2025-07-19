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

        MauiTextInputLayout _nativeEntry;
        protected override MauiTextInputLayout CreatePlatformView()
        {
            return InternalCreateContextThemeView();
        }

        private MauiTextInputLayout InternalCreatePlatformView()
        {
            _nativeEntry = new MauiTextInputLayout(Context);
            return _nativeEntry;
        }

        private MauiTextInputLayout InternalCreateContextThemeView()
        {
            var result = new ContextThemeWrapper(Context, Resource.Style.Widget_Material3_TextInputLayout_OutlinedBox_Dense); // Widget_Material3_TextInputEditText_OutlinedBox
            _nativeEntry = new MauiTextInputLayout(result);
            return _nativeEntry;
        }

        public override void SetVirtualView(IView view)
        {
            base.SetVirtualView(view);
        }
        protected override void ConnectHandler(MauiTextInputLayout platformView)
        {
            base.ConnectHandler(platformView);
        }

        public static void MapBackgroundColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            //handler.PlatformView.SetBackgroundColor(view?.BackgroundColor?.ToPlatform() ?? new AColor());
            handler.PlatformView.MauiTextInputEditText.SetBackgroundColor(entry?.BackgroundColor?.ToPlatform() ?? new AColor());
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
            handler.PlatformView.MauiTextInputEditText.BackgroundTintList = csl;
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
    }
}
