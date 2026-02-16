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
using Color = Microsoft.Maui.Graphics.Color;
using Maui.Android.TextInputLayout.Models.Exceptions;
using Java.Lang;
using Microsoft.Maui.Controls.Platform;
using JMode = Android.Text.JustificationMode;
using Android.Text;
using ATextAlignment = Android.Views.TextAlignment;
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
                return new MauiTextInputLayout(Context, _boxBackgroundMode);
            }
            int style = Resource.Style.Widget_Material3_TextInputLayout_OutlinedBox_Dense;
            if (_boxBackgroundMode == BoxBackgroundMode.Filled)
            {
                style = Resource.Style.Widget_Material3_TextInputLayout_FilledBox_Dense;
            }
            var contextThemeWrapper = new ContextThemeWrapper(Context, style);
            var result =  new MauiTextInputLayout(contextThemeWrapper, _boxBackgroundMode);
            return result;
        }

        public TaskCompletionSource TaskCompletionSource { get; set; } = new();
        public override void SetVirtualView(IView view)
        {
            if(view is not ContentView contentView)
            {
                return;
            }

            if(view is ITextInputLayout layout && layout.Content is IMaterialEntry materialEntry)
            {
                _boxBackgroundMode = layout.BoxBackgroundMode;
                materialEntry.BoxBackgroundMode = layout.BoxBackgroundMode;
            }
            
            PlatformEntry = contentView.Content.ToPlatform(MauiContext) as EditText ?? throw IllegalContentException.ThrowTextInputLayoutIllegalContent();
            MauiTextInputEditText.SetStaticDefaults(PlatformEntry);
            base.SetVirtualView(view);
            PlatformView.AddView(PlatformEntry);
        }

        protected override void ConnectHandler(MauiTextInputLayout platformView)
        {
            PlatformView.SetEndIconOnClickListener(VirtualView);

            // This is the only way I know how to set the text cursor color - which sets other theme colors
            PlatformView.Context.Theme.ApplyStyle(PlatformView.Context.Resources.GetIdentifier("CursorColor", "style", Context.PackageName), true);
        }

        
        
        public static void MapBackgroundColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            int[][] states =
        [
            new[] { RResource.StateFocused, RResource.StateEnabled },
            new[] { RResource.StateEnabled },                  // normal

            new[] { -RResource.StateEnabled },                 // disabled
        ];

            int[] colors =
            [
                entry.BackgroundColor.ToPlatform(),
                entry.BackgroundColor.ToPlatform(),
                entry.DisabledBackgroundColor.WithAlpha(0.04f).ToPlatform(),
                
            ];
            ColorStateList csl = new ColorStateList(states, colors);

            handler.PlatformView.SetBoxBackgroundColorStateList(csl);
        }

        public static void MapDisabledBackgroundColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            int[][] states =
        [
            new[] { RResource.StateFocused, RResource.StateEnabled },
            new[] { RResource.StateEnabled },
            new[] { -RResource.StateEnabled },                 // disabled
                             // normal
        ];

            int[] colors =
            [
                entry.BackgroundColor.ToPlatform(),
                entry.BackgroundColor.ToPlatform(),

                entry.DisabledBackgroundColor.WithAlpha(0.04f).ToPlatform(),
            ];
            ColorStateList csl = new ColorStateList(states, colors);

            handler.PlatformView.SetBoxBackgroundColorStateList(csl);
        }

        public static void MapBackground(ITextInputLayoutHandler handler, ITextInputLayout entry) 
        {
            
        }
        public static void MapOutlineColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            OutlineManager.ApplyOutlineColors(handler, entry);
        }
        public static void MapFocusedOutlineColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            OutlineManager.ApplyOutlineColors(handler, entry);
        }
        public static void MapDisabledOutlineColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            OutlineManager.ApplyOutlineColors(handler, entry);
        }
        
        public static void MapHint(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            HintManager.MapHint(handler, entry);
        }
        public static void MapDefaultHintColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            HintManager.ApplyHintColors(handler, entry);
        }
        public static void MapFocusedHintColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            HintManager.ApplyHintColors(handler, entry);
        }
        public static void MapDisabledHintColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            HintManager.ApplyHintColors(handler, entry);
        }


        public static void MapIsHintAnimated(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            HintManager.MapIsHintAnimated(handler, entry);
        }

        public static void MapCursorColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            
        }

        

        public static void MapBoxBackgroundMode(ITextInputLayoutHandler handler, ITextInputLayout entry)
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
            
        }

        // Note:
        // If IsEnabled changes - End icon, end icon color, text color, hint color, need to be updated
        // If placeholder is set - hint location needs to be updated
        // Add IsPassword
        // Focus/Unfocus events
    }
    public class MaterialEntryHandler : EntryHandler
    {
        protected override AppCompatEditText CreatePlatformView()
        {
            var editText = ContextThemeHelper.BuildContextThemeWrapper(Context, _boxBackgroundMode, (t) => new AppCompatEditText(t));
           
            return editText;
        }
        private BoxBackgroundMode _boxBackgroundMode;
        public override void SetVirtualView(IView view)
        {
            _boxBackgroundMode = IMaterialEntry.ParseBoxBackgroundMode(view);
            base.SetVirtualView(view);

        }

    }
    public class MaterialPickerHandler : PickerHandler
    {
        private BoxBackgroundMode _boxBackgroundMode;
        protected override MauiPicker CreatePlatformView()
        {
            return ContextThemeHelper.BuildContextThemeWrapper(Context, _boxBackgroundMode, (t) => new MauiPicker(t));
        }

        public override void SetVirtualView(IView view)
        {
            _boxBackgroundMode = IMaterialEntry.ParseBoxBackgroundMode(view);
            base.SetVirtualView(view);
        }
    }

    /// <summary>
    /// Enabled
    /// Outlined text field outline color #79747E
    /// </summary>
    public static class ContextThemeHelper
    {

        public static T BuildContextThemeWrapper<T>(Context context, BoxBackgroundMode boxBackgroundMode, Func<Context, T> constructor) where T: EditText
        {
            if (boxBackgroundMode == BoxBackgroundMode.None)
            {
                return constructor(context);
            }

            int style = Resource.Style.ThemeOverlay_Material3_TextInputEditText_OutlinedBox_Dense;
            if (boxBackgroundMode == BoxBackgroundMode.Filled)
            {
                style = Resource.Style.ThemeOverlay_Material3_TextInputEditText_FilledBox_Dense;
            }
            var contextThemeWrapper = new ContextThemeWrapper(context, style);

            T editText = constructor(contextThemeWrapper);
            MauiTextInputEditText.SetStaticDefaults(editText);
            return editText;
        }
    }

    
}
