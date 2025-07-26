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
using Maui.Android.TextInputLayout.Models;

namespace Maui.Android.TextInputLayout
{
    public partial class TextInputEditTextHandler : ViewHandler<ITextInputEditText, MauiTextInputEditText>
    {
        public TextInputEditTextHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
        {
        }

        private BoxBackgroundMode _boxBackgroundMode;
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
            return new MauiTextInputEditText(result);
        }

        public override void SetVirtualView(IView view)
        {
            if(view is ITextInputEditText editText)
            {
                _boxBackgroundMode = editText.BoxBackgroundMode;
            }
            base.SetVirtualView(view);
        }
        protected override void ConnectHandler(MauiTextInputEditText platformView)
        {
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
    }

}
