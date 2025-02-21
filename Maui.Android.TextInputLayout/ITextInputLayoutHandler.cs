using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if ANDROID
using PlatformView = Maui.Android.TextInputLayout.Platforms.Android.MauiTextInputLayout;
#elif WINDOWS
using PlatformView = Maui.Android.TextInputLayout.Platforms.Windows.MauiTextInputLayout;
#elif IOS || MACCATALYST
using PlatformView = Maui.Android.TextInputLayout.Platforms.iOS.MauiTextInputLayout;
#endif
namespace Maui.Android.TextInputLayout
{
    public interface ITextInputLayoutHandler : IViewHandler
    {
        new ITextInputLayout? VirtualView { get; }
        new PlatformView PlatformView { get; }
    }
}
