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
            
            //    int[][] states =
            //[
            //    [-RResource.StateFocused],
            //    [RResource.StateFocused],
            //];
            //    var surface = Color.FromArgb("#121212");   // your dark background
            //    var orange = Color.FromArgb("#FF9800");   // your accent

                
            //    var backgroundColor = Colors.Transparent;
            //    if (v is VisualElement view && view.BackgroundColor is not null)
            //    {
            //        backgroundColor = view.BackgroundColor;
            //    }
            //    int[] colors =
            //    [
            //        backgroundColor.ToPlatform(),
            //        backgroundColor.ToPlatform()
            //    ];
                
             //   ColorStateList csl = new ColorStateList(states, colors);

               // h.PlatformView.BackgroundTintList = csl;
            });
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("Placeholder", (h, v) =>
            {
                if (v.TitleColor is not null)
                {
                    h.PlatformView.SetHintTextColor(v.TitleColor.ToPlatform());
                    h.PlatformView.Focusable = false;
                }

            });
            return builder.ConfigureMauiHandlers(config =>
            {
                //config.AddHandler<TextInputEditText, TextInputEditTextHandler>();
                config.AddHandler<TextInputEditText, TextInputEditTextHandler>();
                config.AddHandler<TextInputLayout, TextInputLayoutHandler>();
                config.AddHandler<MaterialEntry, MaterialEntryHandler>();
                config.AddHandler<MaterialPicker, MaterialPickerHandler>();
            });


        }

        public static void Test()
        {
           
        }
    }
}
