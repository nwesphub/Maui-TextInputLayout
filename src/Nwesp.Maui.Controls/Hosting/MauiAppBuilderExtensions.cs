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
namespace Maui.Android.TextInputLayout.Hosting
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder AddTextInputLayout(this MauiAppBuilder builder)
        {
            return builder.ConfigureMauiHandlers(config =>
            {
                //config.AddHandler<TextInputEditText, TextInputEditTextHandler>();
                config.AddHandler<TextInputEditText, TextInputEditTextHandler>();
                config.AddHandler<TextInputLayout, TextInputLayoutHandler>();
                config.AddHandler<MaterialEntry, MaterialEntryHandler>();
                config.AddHandler<MaterialPicker, MaterialPickerHandler>();
            });
        }
    }
}
