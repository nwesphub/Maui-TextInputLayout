using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if ANDROID
using NativeEntry = Maui.Android.TextInputLayout.Platforms.Android.MauiTextInputEditText;
using PlatformView = Maui.Android.TextInputLayout.Platforms.Android.MauiTextInputLayout;
using ATextInputLayout = Google.Android.Material.TextField.TextInputLayout;
#elif WINDOWS
using PlatformView = Maui.Android.TextInputLayout.Platforms.Windows.MauiTextInputLayout;
using NativeEntry = Maui.Android.TextInputLayout.Platforms.Windows.MauiTextInputEditText;
using ATextInputLayout = object;
#elif IOS || MACCATALYST
using PlatformView = Maui.Android.TextInputLayout.Platforms.iOS.MauiTextInputLayout;
using NativeEntry = Maui.Android.TextInputLayout.Platforms.iOS.MauiTextInputEditText;
#endif
namespace Maui.Android.TextInputLayout
{
    public interface ITextInputLayoutHandler : IViewHandler
    {
        new ITextInputLayout? VirtualView { get; }
        new PlatformView PlatformView { get; }
        //public MauiTextInputLayout NativeLayout;
        //public NativeEntry NativeEntry { get; set; }
        //public ITextInputEditText PlatformEntry { get; set; }

    }
}
