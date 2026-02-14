using Android.Content.Res;
using Maui.Android.TextInputLayout;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RResource = Android.Resource.Attribute;
namespace Maui.Android.TextInputLayout.Hosting
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder AddTextInputLayout(this MauiAppBuilder builder)
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("Placeholder", (h, v) =>
            {
                //h.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
                //h.PlatformView.UpdateBackground(v);
                int[][] states =
            [
                [-RResource.StateFocused],
                [RResource.StateFocused],
            ];

                int[] colors =
                [
                    Colors.Orange.ToPlatform(),
                    Colors.Orange.ToPlatform()
                ];
                ColorStateList csl = new ColorStateList(states, colors);

                h.PlatformView.BackgroundTintList = csl;
            });
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("Placeholder", (h, v) =>
            {
                Color titleColor = v.TitleColor;

                if (titleColor is not null)
                {
                    h.PlatformView.SetHintTextColor(titleColor.ToPlatform());
                }

            });
            return builder.ConfigureMauiHandlers(config =>
            {
                //config.AddHandler<TextInputEditText, TextInputEditTextHandler>();
                config.AddHandler<TextInputEditText, TextInputEditTextHandler>();
                config.AddHandler<TextInputLayout, TextInputLayoutHandler>();
                config.AddHandler<MaterialEntry, MyEntryHandler>();
                config.AddHandler<Picker, MyPickerHandler>();
            });


        }

        
    }
}
