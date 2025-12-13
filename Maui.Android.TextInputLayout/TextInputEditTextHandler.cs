
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
#if ANDROID
using PlatformView = Maui.Android.TextInputLayout.Platforms.Android.MauiTextInputEditText;
#elif WINDOWS
using PlatformView = Maui.Android.TextInputLayout.Platforms.Windows.MauiTextInputEditText;
#elif IOS || MACCATALYST
using PlatformView = Maui.Android.TextInputLayout.Platforms.iOS.MauiTextInputEditText;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID)
using PlatformView = System.Object;
#endif
namespace Maui.Android.TextInputLayout
{
    public partial class TextInputEditTextHandler : ITextInputEditTextHandler
    {
        public static IPropertyMapper<ITextInputEditText, ITextInputEditTextHandler> PropertyMapper = new PropertyMapper<TextInputEditText, ITextInputEditTextHandler>(ViewHandler.ViewMapper)
        {
            [nameof(ITextInputEditText.BackgroundColor)] = MapBackgroundColor,
            [nameof(IEntry.Text)] = MapText,
            [nameof(IEntry.TextColor)] = MapTextColor,
            [nameof(IEntry.IsEnabled)] = EntryHandler.MapIsEnabled

        };

        public static CommandMapper<ITextInputEditText, ITextInputEditTextHandler> CommandMapper = new(ViewHandler.ViewCommandMapper)
        {
            
        };
        public TextInputEditTextHandler() : base(PropertyMapper, CommandMapper)
        {
        }


        IEntry? IEntryHandler.VirtualView => base.VirtualView;
        ITextInputEditText? ITextInputEditTextHandler.VirtualView => base.VirtualView;

        

        public void DisconnectHandler()
        {
        }
    }
}
