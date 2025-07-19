using Maui.Android.TextInputLayout;
using Microsoft.Maui.Hosting;
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
            });
        }
    }
}
