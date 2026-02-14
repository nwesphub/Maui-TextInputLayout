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
using AndroidX.ConstraintLayout.Core.Widgets;
using Android.Util;
using AndroidX.AppCompat.Widget;
using static Google.Android.Material.TextField.TextInputLayout;

namespace Maui.Android.TextInputLayout
{
    public partial class TextInputLayoutHandler : ViewHandler<ITextInputLayout, MauiTextInputLayout>
    {
        private BoxBackgroundMode _boxBackgroundMode;
        protected override MauiTextInputLayout CreatePlatformView()
        {
            //Resource.Style.Widget_Material3_TextInputLayout_OutlinedBox_Dense
            //var contextThemeWrapper = new ContextThemeWrapper(Context, Resource.Style.Widget_Material3_TextInputLayout_FilledBox_Dense);
            if(_boxBackgroundMode == BoxBackgroundMode.None)
            {
                return new MauiTextInputLayout(Context);
            }
            int style = Resource.Style.Widget_Material3_TextInputLayout_OutlinedBox_Dense;
            if (_boxBackgroundMode == BoxBackgroundMode.Filled)
            {
                style = Resource.Style.Widget_Material3_TextInputLayout_FilledBox_Dense;
            }
            var ctx = new ContextThemeWrapper(Context, style);
            var contextThemeWrapper = new ContextThemeWrapper(Context, style);
            return new MauiTextInputLayout(contextThemeWrapper);
        }

        public TaskCompletionSource TaskCompletionSource { get; set; } = new();
        public override void SetVirtualView(IView view)
        {
            if(view is ITextInputLayout layout && layout.Content is IMaterialEntry materialEntry)
            {
                _boxBackgroundMode = layout.BoxBackgroundMode;
                materialEntry.BoxBackgroundMode = layout.BoxBackgroundMode;
            }
            base.SetVirtualView(view);
            PlatformView.AddView(PlatformEntry);
        }

        protected override void ConnectHandler(MauiTextInputLayout platformView)
        {
            // This code used to be in SetVirtualView
            //VirtualEntry = VirtualView.Content as ITextInputEditText ?? throw new Exception("VirtualView.Content is not ITextInputEditText");
            //EditText editText = VirtualView.Content.ToPlatform(MauiContext) as EditText ?? throw new Exception("content is not MauiTextInputEditText");
            //Test();
            //MauiTextInputEditText.SetStaticDefaults(editText);
            //PlatformEntry = editText;
            // This code used to be in SetVirtualView
            PlatformEntry = VirtualView.Content.ToPlatform(MauiContext) as EditText;
            MauiTextInputEditText.SetStaticDefaults(PlatformEntry);
            

            //platformView.BoxBackgroundMode = TextInputLayout.BoxBackgroundOutline;
            PlatformView.SetEndIconOnClickListener(VirtualView);

            // This is the only way I know how to set the text cursor color - which sets other theme colors
            PlatformView.Context.Theme.ApplyStyle(PlatformView.Context.Resources.GetIdentifier("CursorColor", "style", Context.PackageName), true);
        }

        
        
        public static void MapBackgroundColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            
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

        public static void MapEndIconVisibilityMode(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            EndIconManager.MapEndIconVisibilityMode(handler, entry);
        }

        private static void MapIsEnabled(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            ViewHandler.MapIsEnabled(handler, entry);
            EndIconManager.MapIsEnabled(handler, entry);
            HintManager.UpdateHintColors(handler, entry);
   
        }

        // Note:
        // If IsEnabled changes - End icon, end icon color, text color, hint color, need to be updated
        // If placeholder is set - hint location needs to be updated
        // Add IsPassword
        // Focus/Unfocus events
    }
    public class MyEntryHandler : EntryHandler
    {
        protected override AppCompatEditText CreatePlatformView()
        {
            //Widget_Material3_TextInputLayout_FilledBox
            //ThemeOverlay_Material3_TextInputEditText_OutlinedBox_Dense
            //var ctx = new ContextThemeWrapper(Context, Resource.Style.ThemeOverlay_Material3_TextInputEditText_FilledBox_Dense);
            if (_boxBackgroundMode == BoxBackgroundMode.None)
            {
                return new AppCompatEditText(Context);
            }
            
            int style = Resource.Style.ThemeOverlay_Material3_TextInputEditText_OutlinedBox_Dense;
            if (_boxBackgroundMode == BoxBackgroundMode.Filled)
            {
                style = Resource.Style.ThemeOverlay_Material3_TextInputEditText_FilledBox_Dense;
            }
            var ctx = new ContextThemeWrapper(Context, style);
            var editText = new AppCompatEditText(ctx);

            // any defaults
            MauiTextInputEditText.SetStaticDefaults(editText);

            return editText;
        }
        private BoxBackgroundMode _boxBackgroundMode;
        public override void SetVirtualView(IView view)
        {
            if(view is IMaterialEntry materialEntry)
            {
                _boxBackgroundMode = materialEntry.BoxBackgroundMode;
            }
            base.SetVirtualView(view);

        }

    }
    public class MyPickerHandler : PickerHandler
    {
        protected override MauiPicker CreatePlatformView()
        {

            
            var ctx = new ContextThemeWrapper(Context, Resource.Style.ThemeOverlay_Material3_TextInputEditText_OutlinedBox_Dense);
            var editText = new MauiPicker(ctx);

            // any defaults
            MauiTextInputEditText.SetStaticDefaults(editText);

            return editText;
        }

        public override void SetVirtualView(IView view)
        {

            base.SetVirtualView(view);

            //int[][] states =
            //[
            //    [-RResource.StateFocused],
            //    [RResource.StateFocused],
            //];
            //if (view is not Picker picker)
            //{
            //    return;
            //}
            //int[] colors =
            //[
            //    picker?.BackgroundColor?.ToPlatform() ?? new AColor(),
            //    picker?.BackgroundColor?.ToPlatform() ?? new AColor()
            //];
            //ColorStateList csl = new ColorStateList(states, colors);

            //PlatformView.BackgroundTintList = csl;
        }
    }
}
