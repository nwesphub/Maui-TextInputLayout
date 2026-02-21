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
using System.Resources;
using ATheme = Android.Content.Res;
using ARect = Android.Graphics.Rect;
using AndroidX.Core.Widget;
using AndroidX.Core.Graphics.Drawable;
using Maui.Android.TextInputLayout.Utilities;
namespace Maui.Android.TextInputLayout
{
    public partial class TextInputLayoutHandler : ViewHandler<ITextInputLayout, MauiTextInputLayout>
    {
        private BoxBackgroundMode _boxBackgroundMode;
        protected override MauiTextInputLayout CreatePlatformView()
        {
            if(_boxBackgroundMode == BoxBackgroundMode.None)
            {
                return new MauiTextInputLayout(Context, _boxBackgroundMode);
            }
            int theme = Resource.Style.ThemeOverlay_Material3_TextInputEditText_OutlinedBox_Dense;
            if (_boxBackgroundMode == BoxBackgroundMode.Filled)
            {
                theme = Resource.Style.ThemeOverlay_Material3_TextInputEditText_FilledBox_Dense;
                
            }
            
            var contextThemeWrapper = new ContextThemeWrapper(Context, theme);
            var textInputLayout =  new MauiTextInputLayout(contextThemeWrapper, _boxBackgroundMode);
            
            // Hack. For some reason when the box background mode is set to filled, the hint is positioned too high when focused and/or has text
            textInputLayout.BoxCollapsedPaddingTop = 20;

            return textInputLayout;
        }

        public override async void SetVirtualView(IView view)
        {
            if(view is not ContentView contentView)
            {
                return;
            }

            if(view is ITextInputLayout layout && layout.Content is IMaterialEntry materialEntry)
            {
                _boxBackgroundMode = layout.BoxBackgroundMode;
                materialEntry.BoxBackgroundMode = layout.BoxBackgroundMode;
                // Setting default values in the Maui component is not working properly.
                layout.DisabledHintOpacity = ThemeHelper.GetDisabledLabelTextOpacity(layout.BoxBackgroundMode);
                VirtualEntry = materialEntry;
            }
            
            PlatformEntry = contentView.Content.ToPlatform(MauiContext!) as EditText ?? throw IllegalContentException.ThrowTextInputLayoutIllegalContent();
            MauiTextInputEditText.SetStaticDefaults(PlatformEntry);
            base.SetVirtualView(view);
            PlatformView.AddView(PlatformEntry);
            //DrawableCompat.SetTintList(PlatformEntry.TextCursorDrawable, Colors.Red.ToDefaultColorStateList());
        }

        protected override void ConnectHandler(MauiTextInputLayout platformView)
        {
            base.ConnectHandler(platformView);
            if (PlatformEntry is not null)
            {
                PlatformEntry.TextChanged += PlatformEntry_TextChanged;
                PlatformEntry.FocusChange += PlatformEntry_FocusChange;
            }
            
            platformView.SetEndIconOnClickListener(VirtualView);
        }

        private void PlatformEntry_FocusChange(object? sender, AView.FocusChangeEventArgs e)
        {
            
        }

        private void PlatformEntry_TextChanged(object? sender, global::Android.Text.TextChangedEventArgs e)
        {
            
        }

        protected override void DisconnectHandler(MauiTextInputLayout platformView)
        {
            base.DisconnectHandler(platformView);
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
                entry.DisabledBackgroundColor.WithAlpha(entry.DisabledBackgroundColorOpacity).ToPlatform(),
                
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
        public static void MapDisabledOutlineOpacity(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            OutlineManager.ApplyOutlineColors(handler, entry);
        }
        public static void MapBoxStrokeCornerRadius(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            var rect = entry.BoxStrokeCornerRadius;
            handler.PlatformView.SetBoxCornerRadii((float)rect.TopLeft, (float)rect.TopRight, (float)rect.BottomLeft, (float)rect.BottomRight);
        }
        public static void MapBoxStrokeWidth(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.BoxStrokeWidth = entry.BoxStrokeWidth;
        }
        public static void MapBoxStrokeFocusedWidth(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.BoxStrokeWidthFocused = entry.BoxStrokeFocusedWidth;
        }
        public static void MapHint(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            HintManager.MapHint(handler, entry);
        }
        public static void MapHintColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            HintManager.ApplyHintColors(handler, entry);
        }
        public static void MapHintOpacity(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            var opacity = entry.DisabledHintOpacity;
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
            //EndIconManager.MapIsEnabled(handler, entry);
            
        }
        private static void MapPrefix(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            if(string.Equals(handler.PlatformView.PrefixText, entry.Prefix, StringComparison.CurrentCulture))
            {
                return;
            }

            // Prefix gets misaligned from input text.
            handler.PlatformView.Post(() =>
            {
                handler.PlatformView.PrefixText = entry.Prefix;
            });
        }

        private static void MapSuffix(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.SuffixText = entry.Suffix;
        }
        private static void MapSupportingText(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.HelperText = entry.SupportingText;
        }

        private static void MapCounterEnabled(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.CounterEnabled = entry.CounterEnabled;
        }
        private static void MapCounterMaxLength(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.CounterMaxLength = entry.CounterMaxLength;
        }

    }
    public class MaterialEntryHandler : EntryHandler
    {
        protected override AppCompatEditText CreatePlatformView()
        {
            int theme = Resource.Style.ThemeOverlay_Material3_TextInputEditText_OutlinedBox_Dense;
            if (_boxBackgroundMode == BoxBackgroundMode.Filled)
            {
                theme = Resource.Style.ThemeOverlay_Material3_TextInputEditText_FilledBox_Dense;
            }

            var contextThemeWrapper = new ContextThemeWrapper(Context, theme);
            var editText = new AppCompatEditText(contextThemeWrapper);
            
           
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
