using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if IOS || MACCATALYST
using PlatformView = Maui.Android.TextInputLayout.Platforms.iOS.MauiTextInputEditText;
#endif
namespace Maui.Android.TextInputLayout.Platforms.iOS
{
    public class MauiTextInputEditText : UIKit.UIView
    {
    }
}
