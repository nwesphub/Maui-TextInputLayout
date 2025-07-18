using Microsoft.Maui.Handlers;
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
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID)
using PlatformView = System.Object;
#endif


namespace Maui.Android.TextInputLayout
{
    public partial class TextInputLayoutHandler : ITextInputLayoutHandler
    {
        public static IPropertyMapper<ITextInputLayout, ITextInputLayoutHandler> PropertyMapper = new PropertyMapper<TextInputLayout, ITextInputLayoutHandler>(ViewHandler.ViewMapper)
        {
            [nameof(ITextInputLayout.BackgroundColor)] = MapBackgroundColor,
            [nameof(ITextInputLayout.Background)] = MapBackground,
            [nameof(ITextInputLayout.BorderColor)] = MapBorderColor,
            [nameof(ITextInputLayout.FocusedBorderColor)] = MapFocusedBorderColor,
            [nameof(ITextInputLayout.Hint)] = MapHint,
            [nameof(ITextInputLayout.DefaultHintColor)] = MapDefaultHintColor,
            [nameof(ITextInputLayout.FocusedHintColor)] = MapFocusedHintColor,
            [nameof(ITextInputLayout.IsHintAnimated)] = MapIsHintAnimated,

        };

        public static CommandMapper<ITextInputLayout, ITextInputLayoutHandler> CommandMapper = new(ViewHandler.ViewCommandMapper)
        {

        };
        public TextInputLayoutHandler() : base(PropertyMapper, CommandMapper)
        {
        }



        ITextInputLayout? ITextInputLayoutHandler.VirtualView => base.VirtualView;

        public void DisconnectHandler()
        {
        }
    }
}
