using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if IOS || MACCATALYST
using PlatformView = Nwesp.Maui.Android.Platforms.iOS.MauiTextInputEditText;
#endif
namespace Nwesp.Maui.Android.Platforms.iOS
{
    public class MauiTextInputEditText : UIKit.UIView
    {
    }
}
