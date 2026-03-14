using AndroidX.AppCompat.View;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Nwesp.Maui.Android.Abstractions;
using Nwesp.Maui.Android.Controls;
using Nwesp.Maui.Android.Models.Enums;
using Nwesp.Maui.Android.Platforms.Android;
using Nwesp.Maui.Android.Platforms.Android.Managers;
using Nwesp.Maui.Android.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nwesp.Maui.Android
{
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

        protected override AppCompatEditText CreatePlatformView()
        {
            return ContextThemeHelper.BuildContextThemeWrapper(Context, _boxBackgroundMode, (t) => new AppCompatEditText(t));
        }

        private BoxBackgroundMode _boxBackgroundMode;
        public override void SetVirtualView(IView view)
        {
            _boxBackgroundMode = OutlineManager.ParseBoxBackgroundMode(view);
            base.SetVirtualView(view);
        }

        public static void MapTextColor(MaterialEntryHandler handler, MaterialEntry view)
        {
            handler.PlatformView?.UpdateTextColor(view);
        }
    }
}
