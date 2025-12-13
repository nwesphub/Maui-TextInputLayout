using Android.Content.Res;
using AndroidX.AppCompat.View;
using Maui.Android.TextInputLayout.Platforms.Android;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RResource = Android.Resource.Attribute;
using AColor = Android.Graphics.Color;
using Maui.Android.TextInputLayout.Models.Enums;
using AndroidX.AppCompat.Widget;
using Android.Widget;
using Android.Text;
using Maui.Android.TextInputLayout.Platforms.Android.Managers;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Maui.Android.TextInputLayout.Platforms.Android.Helpers;

namespace Maui.Android.TextInputLayout
{
    public partial class TextInputEditTextHandler : ViewHandler<ITextInputEditText, MauiTextInputEditText>
    {
        public TextInputEditTextHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
        {
        }
        AppCompatEditText IEntryHandler.PlatformView => PlatformView;
        private BoxBackgroundMode _boxBackgroundMode;
        public DataFlowDirection DataFlowDirection { get; set; }
        protected override MauiTextInputEditText CreatePlatformView()
        {
            if(_boxBackgroundMode == BoxBackgroundMode.None)
            {
                return new MauiTextInputEditText(Context);
            }

            int style = Resource.Style.Widget_Material3_TextInputLayout_OutlinedBox;
            if(_boxBackgroundMode == BoxBackgroundMode.Filled)
            {
                style = Resource.Style.Widget_Material3_TextInputLayout_FilledBox;
            }
            var result = new ContextThemeWrapper(Context, style);
            return new MauiTextInputEditText(result, _boxBackgroundMode);
        }

        public override void SetVirtualView(IView view)
        {
            if(view is ITextInputEditText editText)
            {
                _boxBackgroundMode = editText.BoxBackgroundMode;
            }
            base.SetVirtualView(view);
        }


        private void PlatformView_TextChanged(object? sender, global::Android.Text.TextChangedEventArgs e)
        {
            DataFlowDirection = DataFlowDirection.FromPlatform;
            VirtualView.UpdateText(e);
            DataFlowDirection = DataFlowDirection.ToPlatform;
        }

        protected override void ConnectHandler(MauiTextInputEditText platformView)
        {
            this.PlatformView.TextChanged += PlatformView_TextChanged;
            base.ConnectHandler(platformView);
        }

        public static async void MapBackgroundColor(ITextInputEditTextHandler handler, ITextInputEditText entry)
        {
            
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

            handler.PlatformView.BackgroundTintList = csl;
        }
        public static void MapText(ITextInputEditTextHandler handler, ITextInputEditText entry)
        {
            if (handler is TextInputEditTextHandler textHandler && textHandler.DataFlowDirection == DataFlowDirection.FromPlatform && entry is Entry editText)
            {
                handler.PlatformView.UpdateTextFromPlatform(editText);
                return;
            }

            handler.PlatformView.UpdateText(entry);
        }

        public static void MapTextColor(ITextInputEditTextHandler handler, ITextInputEditText entry)
        {
            if(entry.TextColor is null)
            {
                return;
            }
            int[][] _states =
            [
                [-RResource.StateSelected],
                [RResource.StateSelected]
            ];
            ColorStateList colorStateList;
            if (entry.IsEnabled)
            {
                colorStateList = new ColorStateList(_states, [entry.TextColor.ToAndroid(), entry.TextColor.ToAndroid()]);
            }
            else
            {
                colorStateList = new ColorStateList(_states, [ColorHelper.GetDesaturatedColor(entry.TextColor.ToAndroid()), ColorHelper.GetDesaturatedColor(entry.TextColor.ToAndroid())]);
            }
            //handler.PlatformView.TextColors = colorStateList;
            //handler.PlatformView.UpdateTextColor();
            handler.PlatformView.SetTextColor(colorStateList);
        }
    }
}
