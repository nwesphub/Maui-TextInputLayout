using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content.Res;
using Microsoft.Maui.Platform;
using Nwesp.Maui.Android.Utilities;
using Nwesp.Maui.Android.Platforms.Android;
using Nwesp.Maui.Android.Abstractions;
using Nwesp.Maui.Android.Controls;



#if ANDROID
using PlatformView = Nwesp.Maui.Android.Platforms.Android.MauiTextInputLayout;
using PlatformEntry = Android.Widget.EditText;
#elif WINDOWS
using PlatformView = Nwesp.Maui.Android.Platforms.Windows.MauiTextInputLayout;
using PlatformEntry = Nwesp.Maui.Android.Platforms.Windows.MauiTextInputEditText;
#elif IOS || MACCATALYST
using PlatformView = Nwesp.Maui.Android.Platforms.iOS.MauiTextInputLayout;
using PlatformEntry = Nwesp.Maui.Android.Platforms.iOS.MauiTextInputLayout;
#endif
using AResource = Android.Resource.Attribute;
namespace Nwesp.Maui.Android
{
    public partial class TextInputLayoutHandler : ITextInputLayoutHandler
    {
        public IMaterialEntry VirtualEntry { get; set; }
        public PlatformEntry PlatformEntry { get; set; }

        public static IPropertyMapper<ITextInputLayout, ITextInputLayoutHandler> PropertyMapper = new PropertyMapper<TextInputLayout, ITextInputLayoutHandler>(ViewHandler.ViewMapper)
        {
            [nameof(ITextInputLayout.BackgroundColor)] = MapBackgroundColor,
            [nameof(ITextInputLayout.DisabledBackgroundColor)] = MapBackgroundColor,
            [nameof(ITextInputLayout.DisabledBackgroundColorOpacity)] = MapBackgroundColor,
            [nameof(ITextInputLayout.OutlineColor)] = MapOutlineColor,
            [nameof(ITextInputLayout.FocusedOutlineColor)] = MapFocusedOutlineColor,
            [nameof(ITextInputLayout.DisabledOutlineColor)] = MapDisabledOutlineColor,
            [nameof(ITextInputLayout.Hint)] = MapHint,
            [nameof(ITextInputLayout.DefaultHintColor)] = MapHintColor,
            [nameof(ITextInputLayout.FocusedHintColor)] = MapHintColor,
            [nameof(ITextInputLayout.DisabledHintColor)] = MapHintColor,
            [nameof(ITextInputLayout.DisabledHintOpacity)] = MapHintOpacity,
            [nameof(ITextInputLayout.IsHintAnimated)] = MapIsHintAnimated,
            [nameof(ITextInputLayout.EndIcon)] = MapEndIcon,
            [nameof(ITextInputLayout.EndIconColor)] = MapEndIconColor,
            [nameof(ITextInputLayout.DisabledEndIconColor)] = MapEndIconColor,
            [nameof(ITextInputLayout.DisabledEndIconOpacity)] = MapEndIconColor,
            [nameof(ITextInputLayout.StartIcon)] = MapStartIcon,
            [nameof(ITextInputLayout.StartIconColor)] = MapStartIconColor,
            [nameof(ITextInputLayout.DisabledStartIconColor)] = MapStartIconColor,
            [nameof(ITextInputLayout.DisabledStartIconOpacity)] = MapStartIconColor,
            [nameof(ITextInputLayout.BoxBackgroundMode)] = MapBoxBackgroundMode,
            [nameof(ITextInputLayout.EndIconVisibilityMode)] = MapEndIconVisibilityMode,
            
            [nameof(ITextInputLayout.Prefix)] = MapPrefix,
            [nameof(ITextInputLayout.Suffix)] = MapSuffix,
            [nameof(ITextInputLayout.SupportingText)] = MapSupportingText,
            [nameof(ITextInputLayout.DisabledOutlineOpacity)] = MapDisabledOutlineOpacity,
            [nameof(ITextInputLayout.BoxStrokeCornerRadius)] = MapBoxStrokeCornerRadius,
            [nameof(ITextInputLayout.BoxStrokeWidth)] = MapBoxStrokeWidth,
            [nameof(ITextInputLayout.BoxStrokeFocusedWidth)] = MapBoxStrokeFocusedWidth,
            [nameof(ITextInputLayout.CounterEnabled)] = MapCounterEnabled,
            [nameof(ITextInputLayout.CounterMaxLength)] = MapCounterMaxLength,
            [nameof(ITextInputLayout.ErrorText)] = MapErrorText,
            [nameof(ITextInputLayout.PrefixTextColor)] = MapPrefixTextColor,
            [nameof(ITextInputLayout.DisabledPrefixTextColor)] = MapPrefixTextColor,
            [nameof(ITextInputLayout.DisabledPrefixTextColorOpacity)] = MapPrefixTextColor,
            [nameof(ITextInputLayout.SuffixTextColor)] = MapSuffixTextColor,
            [nameof(ITextInputLayout.DisabledSuffixTextColor)] = MapSuffixTextColor,
            [nameof(ITextInputLayout.DisabledSuffixTextColor)] = MapSuffixTextColor,
            [nameof(IPadding.Padding)] = MapPadding, // Padding isn't mapped by default.
        };

        public static CommandMapper<ITextInputLayout, ITextInputLayoutHandler> CommandMapper = new(ViewHandler.ViewCommandMapper);
        public TextInputLayoutHandler() : base(PropertyMapper, CommandMapper)
        {
            
        }
    }

    public partial class MaterialEntryHandler : EntryHandler
    {
        public static new IPropertyMapper<MaterialEntry, MaterialEntryHandler> Mapper = new PropertyMapper<MaterialEntry, MaterialEntryHandler>(EntryHandler.Mapper)
        {
            [nameof(IMaterialEntry.TextColor)] = MapTextColor,
            [nameof(IMaterialEntry.DisabledTextColor)] = MapTextColor,
            [nameof(IMaterialEntry.DisabledTextColorOpacity)] = MapTextColor,
        };
        public static CommandMapper<MaterialEntry, MaterialEntryHandler> CommandMapper = new(ViewHandler.ViewCommandMapper)
        {
           
        };

        

        public MaterialEntryHandler() : base(Mapper, CommandMapper)
        {
        }

        public static void MapTextColor(MaterialEntryHandler handler, MaterialEntry view)
        {
            
            handler.PlatformView?.UpdateTextColor(view);
        }
    }
}
