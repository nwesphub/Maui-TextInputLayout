using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if ANDROID
using PlatformView = Nwesp.Maui.Android.Platforms.Android.MauiTextInputEditText;
#elif WINDOWS
using PlatformView = Nwesp.Maui.Android.Platforms.Windows.MauiTextInputEditText;
using ATextInputLayout = object;
#elif IOS || MACCATALYST
using PlatformView = Nwesp.Maui.Android.Platforms.iOS.MauiTextInputEditText;
#endif
namespace Nwesp.Maui.Android
{
    [Obsolete]
    public interface ITextInputEditTextHandler : IEntryHandler
    {
        new ITextInputEditText? VirtualView { get; }
        new PlatformView PlatformView { get; }
    }
}