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
using AResource = Android.Resource.Attribute;
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
using static Android.Views.View;
using static Android.Views.ViewTreeObserver;
using Layout = Microsoft.Maui.Controls.Layout;
using Android.Views.InputMethods;
using static Maui.Android.TextInputLayout.Platforms.Android.MauiTextInputLayout;
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
            var mauiContext = MauiContext;
            
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

            if(view is ITextInputLayout layout)
            {
                _boxBackgroundMode = layout.BoxBackgroundMode;
                // Setting some default values in the Maui component is not working properly.
                layout.DisabledHintOpacity = ThemeHelper.GetDisabledLabelTextOpacity();
                if (layout.Content is IMaterialEntry materialEntry)
                {
                    materialEntry.BoxBackgroundMode = layout.BoxBackgroundMode;
                    VirtualEntry = materialEntry;
                }
            }
            
            PlatformEntry = contentView.Content.ToPlatform(MauiContext!) as EditText ?? throw IllegalContentException.ThrowTextInputLayoutIllegalContent();
            PlatformEntry.SetMinimumWidth(int.MaxValue);
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
        }

        protected override void DisconnectHandler(MauiTextInputLayout platformView)
        {
            base.DisconnectHandler(platformView);
            if (PlatformEntry is not null)
            {
                PlatformEntry.TextChanged -= PlatformEntry_TextChanged;
                PlatformEntry.FocusChange -= PlatformEntry_FocusChange;
            }
            platformView.SetEndIconOnClickListener(null);
        }

        private void PlatformEntry_FocusChange(object? sender, AView.FocusChangeEventArgs e)
        {
            // Disabling for now. When end icon mode is set to custom, advancing focus past disabled entries causes the end icon to receive focus.
            return;
            if(VirtualView.EndIconVisibilityMode != IconVisibilityMode.WhileEditing)
            {
                return;
            }

            if (e.HasFocus)
            {
                PlatformView?.ShowEndIcon(VirtualView, MauiContext);
            }
            else
            {
                PlatformView?.HideEndIcon();
            }
        }

        private void PlatformEntry_TextChanged(object? sender, global::Android.Text.TextChangedEventArgs e)
        {
            // Disabling for now. When end icon mode is set to custom, advancing focus past disabled entries causes the end icon to receive focus.
            return;
            if(VirtualView.EndIconVisibilityMode != IconVisibilityMode.HasText)
            {
                return;
            }
            
            if (!string.IsNullOrWhiteSpace(e.Text?.ToString()))
            {
                PlatformView?.ShowEndIcon(VirtualView, MauiContext);
            }
            else
            {
                PlatformView?.HideEndIcon();
            }
        }



        public static void MapBackgroundColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            
            int[][] states =
            [
                [AResource.StateFocused, AResource.StateEnabled],
                [AResource.StateEnabled],
                [-AResource.StateEnabled],
            ];

            int[] colors =
            [
                entry.BackgroundColor.ToPlatform(),
                entry.BackgroundColor.ToPlatform(),
                entry.DisabledBackgroundColor.WithAlpha(entry.DisabledBackgroundColorOpacity).ToPlatform(),
                
            ];

            handler.PlatformView.SetBoxBackgroundColorStateList(new ColorStateList(states, colors));
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
            handler.PlatformView?.MapHint(entry);
        }
        public static void MapHintColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.ApplyHintColors(entry);
        }
        public static void MapHintOpacity(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.ApplyHintColors(entry);
        }

        public static void MapIsHintAnimated(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler?.PlatformView?.MapIsHintAnimated(entry);
        }  

        public static void MapBoxBackgroundMode(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateBoxBackgroundMode(entry);
        }

        public static void MapEndIconColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateEndIconColor(entry);
        }

        public static void MapEndIcon(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.MapCustomEndIcon(entry, handler.MauiContext);
        }

        public static void MapEndIconVisibilityMode(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            // Todo fix end icon visibility modes
            handler.PlatformView?.ShowEndIcon(entry, handler.MauiContext);
            return;
            if (entry.EndIconVisibilityMode == IconVisibilityMode.Always)
            {
                handler.PlatformView?.ShowEndIcon(entry, handler.MauiContext);
            }
            else if(entry.EndIconVisibilityMode == IconVisibilityMode.Never)
            {
                handler.PlatformView?.HideEndIcon();
            }
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
        private static void MapErrorText(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.Error = entry.ErrorText;
        }
        private static void MapPrefixTextColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            int[][] states =
            [
                [AResource.StateEnabled],
                [-AResource.StateEnabled]
            ];

            int[] colors =
            [
                entry.PrefixTextColor.ToPlatform(),
                entry.DisabledPrefixTextColor.WithAlpha(entry.DisabledPrefixTextColorOpacity).ToPlatform()
            ];
            handler.PlatformView.PrefixTextColor = new ColorStateList(states, colors);
        }
        private static void MapSuffixTextColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            int[][] states =
            [
                [AResource.StateEnabled],
                [-AResource.StateEnabled]
            ];

            int[] colors =
            [
                entry.SuffixTextColor.ToPlatform(),
                entry.DisabledSuffixTextColor.WithAlpha(entry.DisabledSuffixTextColorOpacity).ToPlatform()
            ];
            handler.PlatformView.SuffixTextColor = new ColorStateList(states, colors);
        }

        private static void MapCounterEnabled(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.CounterEnabled = entry.CounterEnabled;
        }
        private static void MapCounterMaxLength(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView.CounterMaxLength = entry.CounterMaxLength;
        }
        private static void MapPadding(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            var padding = entry.Padding;
            handler.PlatformView?.SetPadding((int)padding.Left, (int)padding.Top, (int)padding.Right, (int)padding.Bottom);
        }
        //private static void MapIsMultiLine(ITextInputLayoutHandler handler, ITextInputLayout entry)
        //{
        //    handler.PlatformEntry.SetSingleLine(!entry.IsMultiLine);

        //    return;
        //    // Hacky solution to prevent border getting cut off on entries below the multi line. InvalidateMeasure(view) needs to be called on the affected views

        //    if (entry is Microsoft.Maui.Controls.View view)
        //    {
        //        view.SizeChanged += View_SizeChanged;
        //    }

        //}

        private static void View_SizeChanged(object? sender, EventArgs e)
        {
            if (sender is Microsoft.Maui.Controls.View view)
            {
                if (view.Parent is Layout layout)
                {
                    if (layout.Handler is LayoutHandler layoutHandler)
                    {
                        //layoutHandler.PlatformView.Invalidate();
                        //layoutHandler.PlatformView.InvalidateMeasure(view);
                        //layoutHandler.PlatformView.RefreshDrawableState();
                    }
                }
                if (view is TextInputLayout til && til.Handler is ITextInputLayoutHandler itilh)
                {
                    //itilh.PlatformView.Invalidate();
                    itilh.PlatformView.InvalidateMeasure(view);
                    //itilh.PlatformView.RefreshDrawableState();
                }
            }
        }

    }
    public partial class MaterialEntryHandler : EntryHandler
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
