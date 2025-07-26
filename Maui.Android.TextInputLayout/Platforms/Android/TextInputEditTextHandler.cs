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

namespace Maui.Android.TextInputLayout
{
    public partial class TextInputEditTextHandler : ViewHandler<ITextInputEditText, MauiTextInputEditText>
    {
        public TextInputEditTextHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
        {
        }

        protected override MauiTextInputEditText CreatePlatformView()
        {
            // Required
            var result = new ContextThemeWrapper(Context, Resource.Style.Widget_Material3_TextInputLayout_OutlinedBox); // Widget_Material3_TextInputEditText_OutlinedBox
            return new MauiTextInputEditText(result);
        }

        public override void SetVirtualView(IView view)
        {
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
