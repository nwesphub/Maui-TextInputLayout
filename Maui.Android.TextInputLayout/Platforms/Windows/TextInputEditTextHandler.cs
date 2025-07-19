using Maui.Android.TextInputLayout.Platforms.Windows;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout
{
    public partial class TextInputEditTextHandler : ViewHandler<ITextInputEditText, MauiTextInputEditText>
    {
        protected override MauiTextInputEditText CreatePlatformView()
        {
            throw new NotImplementedException();
        }
        public static async void MapBackgroundColor(ITextInputEditTextHandler handler, ITextInputEditText entry)
        {

        }
    }
}
