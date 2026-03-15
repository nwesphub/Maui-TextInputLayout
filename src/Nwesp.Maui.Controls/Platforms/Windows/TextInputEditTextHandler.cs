using Nwesp.Maui.Android.Platforms.Windows;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nwesp.Maui.Android
{
    public partial class TextInputEditTextHandler : ViewHandler<ITextInputEditText, MauiTextInputEditText>
    {
        TextBox IEntryHandler.PlatformView => PlatformView;
        protected override MauiTextInputEditText CreatePlatformView()
        {
            throw new NotImplementedException();
        }
        public static async void MapBackgroundColor(ITextInputEditTextHandler handler, ITextInputEditText entry)
        {

        }
        public static async void MapText(ITextInputEditTextHandler handler, ITextInputEditText entry)
        {

        }
    }
}
