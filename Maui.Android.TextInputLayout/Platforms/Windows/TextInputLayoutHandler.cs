using Maui.Android.TextInputLayout.Platforms.Windows;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout
{
    public partial class TextInputLayoutHandler : ViewHandler<ITextInputLayout, MauiTextInputLayout>
    {
        protected override MauiTextInputLayout CreatePlatformView()
        {
            throw new NotImplementedException();
        }
        public static void MapBackgroundColor(ITextInputLayoutHandler handler, ITextInputLayout view)
        {
            //handler.PlatformView?.();
        }

        public static void MapBorderColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {

        }
        public static void MapFocusedBorderColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {

        }
        public static void MapHint(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {

        }
        public static void MapDefaultHintColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {

        }
        public static void MapFocusedHintColor(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {

        }
        public static void MapIsHintAnimated(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {

        }
        public static async void MapEndIcon(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
        }
        public static async void MapBoxBackgroundMode(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
        }
    }
}
