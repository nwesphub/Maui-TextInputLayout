using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if IOS || MACCATALYST
using PlatformView = Maui.Android.TextInputLayout.Platforms.iOS.MauiTextInputLayout;
#endif
namespace Maui.Android.TextInputLayout.Platforms.iOS
{
    public class MauiTextInputLayout : UIKit.UIView
    {
    }
}
