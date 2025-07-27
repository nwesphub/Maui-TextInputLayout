using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if ANDROID
using PlatformView = Maui.Android.TextInputLayout.Platforms.Android.MauiTextInputEditText;
#elif WINDOWS
using PlatformView = Maui.Android.TextInputLayout.Platforms.Windows.MauiTextInputEditText;
using ATextInputLayout = object;
#elif IOS || MACCATALYST
using PlatformView = Maui.Android.TextInputLayout.Platforms.iOS.MauiTextInputEditText;
#endif
namespace Maui.Android.TextInputLayout
{
    public interface ITextInputEditTextHandler : IEntryHandler
    {
        new ITextInputEditText? VirtualView { get; }
        new PlatformView PlatformView { get; }
    }
}