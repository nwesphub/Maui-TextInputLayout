using Android.Content.PM;
using Android.Content.Res;
using Android.Views;
using AndroidX.AppCompat.View;
using Nwesp.Maui.Android.Platforms.Android;
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
using Nwesp.Maui.Android.Platforms.Android.Managers;
using Javax.Crypto;
using Android.Graphics.Drawables;
using Android.Graphics;
using Nwesp.Maui.Android.Models.Enums;
using Android.Content;
using Android.Widget;
using Google.Android.Material.TextField;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using AndroidX.ConstraintLayout.Core.Widgets;
using Android.Util;
using AndroidX.AppCompat.Widget;
using static Google.Android.Material.TextField.TextInputLayout;
using Color = Microsoft.Maui.Graphics.Color;
using Nwesp.Maui.Android.Models.Exceptions;
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
using Nwesp.Maui.Android.Utilities;
using static Android.Views.View;
using static Android.Views.ViewTreeObserver;
using Layout = Microsoft.Maui.Controls.Layout;
using Android.Views.InputMethods;
using AViewGroup = Android.Views.ViewGroup;
using static Nwesp.Maui.Android.Platforms.Android.MauiTextInputLayout;
using AViewStates = Android.Views.ViewStates;
using Microsoft.Maui.Graphics;
using Google.Android.Material.Internal;
using Android.Graphics.Drawables.Shapes;
using AShapeDrawable = Android.Graphics.Drawables.ShapeDrawable;
using Android.Animation;
using ABlendMode = Android.Graphics.BlendMode;
using AProgressBar = Android.Widget.ProgressBar;
using Nwesp.Maui.Android.Abstractions;
using Nwesp.Maui.Android.Controls;
namespace Nwesp.Maui.Android
{

    public partial class TextInputLayoutHandler : ViewHandler<ITextInputLayout, MauiTextInputLayout>
    {
        protected override MauiTextInputLayout CreatePlatformView()
        {
 
            var textInputLayout =  new MauiTextInputLayout(Context);
            return textInputLayout;
        }

        public override void SetVirtualView(IView view)
        {
            if(view is not ContentView contentView)
            {
                return;
            }

            if(view is ITextInputLayout layout)
            {
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
        }


        protected override void ConnectHandler(MauiTextInputLayout platformView)
        {
            base.ConnectHandler(platformView);
            
            if (PlatformEntry is not null)
            {
                PlatformEntry.TextChanged += PlatformEntry_TextChanged;
                PlatformEntry.FocusChange += PlatformEntry_FocusChange;
            }
            PlatformView.SetStartIconOnClickListener(new OnStartIconClickListener(VirtualView));
            
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
            platformView.SetStartIconOnClickListener(null);
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
            handler.PlatformView?.UpdateBackgroundColor(entry);
        }

        public static void MapOutlineColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateOutlineColor(entry);
        }

        public static void MapFocusedOutlineColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateOutlineColor(entry);
        }

        public static void MapDisabledOutlineColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateOutlineColor(entry);
        }

        public static void MapDisabledOutlineOpacity(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateOutlineColor(entry);
        }

        public static void MapBoxStrokeCornerRadius(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateBoxCornerRadius(entry);
        }

        public static void MapBoxStrokeWidth(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateBoxStrokeWidth(entry);
        }

        public static void MapBoxStrokeFocusedWidth(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateBoxStrokeFocusedWidth(entry);
        }

        public static void MapHint(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.MapHint(entry);
        }

        public static void MapHintColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateHintColors(entry);
        }

        public static void MapHintOpacity(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateHintColors(entry);
        }

        public static void MapIsHintAnimated(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler?.PlatformView?.MapIsHintAnimated(entry);
        }

        public static void MapBoxBackgroundMode(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateBoxBackgroundMode(entry);
        }

        public static void MapEndIcon(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.MapCustomEndIcon(entry, handler.MauiContext);
        }

        public static void MapEndIconColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateEndIconColor(entry);
        }

        public static void MapStartIcon(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.MapCustomStartIcon(entry, handler.MauiContext);
        }

        public static void MapStartIconColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateStartIconColor(entry);
        }

        public static void MapEndIconVisibilityMode(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
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

        public static void MapPrefix(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdatePrefixText(entry);
        }

        public static void MapPrefixTextColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdatePrefixTextColor(entry);
        }

        public static void MapSuffix(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateSuffixText(entry);
        }

        public static void MapSuffixTextColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateSuffixTextColor(entry);
        }

        public static void MapSupportingText(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateSupportingText(entry);
        }

        public static void MapErrorText(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateErrorText(entry);
        }

        public static void MapCounterEnabled(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateCounterEnabled(entry);
        }

        public static void MapCounterMaxLength(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdateCounterMaxLength(entry);
        }

        public static void MapPadding(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            handler.PlatformView?.UpdatePadding(entry);
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
}
