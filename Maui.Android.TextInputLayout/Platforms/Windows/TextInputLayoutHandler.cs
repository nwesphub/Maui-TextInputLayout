using Maui.Android.TextInputLayout.Platforms.Windows;
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout
{
    public partial class TextInputLayoutHandler : ViewHandler<TextInputLayout, MauiTextInputLayout>
    {
        protected override MauiTextInputLayout CreatePlatformView()
        {
            throw new NotImplementedException();
        }
        public static void MapBackgroundColor(ITextInputLayoutHandler handler, ITextInputLayout view)
        {
            //handler.PlatformView?.();
        }
    }
}
