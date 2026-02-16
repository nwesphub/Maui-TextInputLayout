using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if ANDROID
using PlatformView = Maui.Android.TextInputLayout.Platforms.Android.MauiTextInputLayout;
using PlatformEntry = Android.Widget.EditText;
#elif WINDOWS
using PlatformView = Maui.Android.TextInputLayout.Platforms.Windows.MauiTextInputLayout;
using PlatformEntry = Maui.Android.TextInputLayout.Platforms.Windows.MauiTextInputEditText;
#elif IOS || MACCATALYST
using PlatformView = Maui.Android.TextInputLayout.Platforms.iOS.MauiTextInputLayout;
using PlatformEntry = Maui.Android.TextInputLayout.Platforms.iOS.MauiTextInputLayout;
#endif

namespace Maui.Android.TextInputLayout
{
    public partial class TextInputLayoutHandler : ITextInputLayoutHandler
    {
        public ITextInputEditText VirtualEntry { get; set; }

        public static IPropertyMapper<ITextInputLayout, ITextInputLayoutHandler> PropertyMapper = new PropertyMapper<TextInputLayout, ITextInputLayoutHandler>(ViewHandler.ViewMapper)
        {
            [nameof(ITextInputLayout.BackgroundColor)] = MapBackgroundColor,
            [nameof(ITextInputLayout.DisabledBackgroundColor)] = MapBackgroundColor,
            [nameof(ITextInputLayout.Background)] = MapBackground,
            [nameof(ITextInputLayout.OutlineColor)] = MapOutlineColor,
            [nameof(ITextInputLayout.FocusedOutlineColor)] = MapFocusedOutlineColor,
            [nameof(ITextInputLayout.DisabledOutlineColor)] = MapDisabledOutlineColor,
            [nameof(ITextInputLayout.Hint)] = MapHint,
            [nameof(ITextInputLayout.DefaultHintColor)] = MapDefaultHintColor,
            [nameof(ITextInputLayout.FocusedHintColor)] = MapFocusedHintColor,
            [nameof(ITextInputLayout.DisabledHintColor)] = MapDisabledHintColor,
            [nameof(ITextInputLayout.IsHintAnimated)] = MapIsHintAnimated,
            [nameof(ITextInputLayout.EndIcon)] = MapEndIcon,
            [nameof(ITextInputLayout.BoxBackgroundMode)] = MapBoxBackgroundMode,
            [nameof(ITextInputLayout.EndIconVisibilityMode)] = MapEndIconVisibilityMode,
            [nameof(ITextInputLayout.EndIconColor)] = MapEndIconColor,
            [nameof(ITextInputLayout.IsEnabled)] = MapIsEnabled
        };

        public static CommandMapper<ITextInputLayout, ITextInputLayoutHandler> CommandMapper = new(ViewHandler.ViewCommandMapper)
        {

        };
        public TextInputLayoutHandler() : base(PropertyMapper, CommandMapper)
        {

        }

        //public MauiTextInputEditText NativeEntry { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        ITextInputLayout? ITextInputLayoutHandler.VirtualView => base.VirtualView;

        private PlatformEntry _platformEntry = default!;

        public PlatformEntry PlatformEntry
        {
            get => _platformEntry;
            set => _platformEntry = value;
        }

        public void DisconnectHandler()
        {
        }
    }
}
