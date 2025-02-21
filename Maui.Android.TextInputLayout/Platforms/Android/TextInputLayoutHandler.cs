using Android.Content.PM;
using Maui.Android.TextInputLayout.Platforms.Android;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Icu.Text.CaseMap;
using static Android.Provider.MediaStore;
using AColor = Android.Graphics.Color;
namespace Maui.Android.TextInputLayout
{
    public partial class TextInputLayoutHandler : ViewHandler<ITextInputLayout, MauiTextInputLayout>
    {

        MauiTextInputLayout _nativeEntry;
        protected override MauiTextInputLayout CreatePlatformView()
        {
            _nativeEntry = new MauiTextInputLayout(Context, VirtualView);
            return _nativeEntry;
        }

        public override void SetVirtualView(IView view)
        {
            base.SetVirtualView(view);
        }
        protected override void ConnectHandler(MauiTextInputLayout platformView)
        {
            base.ConnectHandler(platformView);
        }

        public static void MapBackgroundColor(ITextInputLayoutHandler handler, ITextInputLayout view)
        {
            handler.PlatformView.SetBackgroundColor(view?.BackgroundColor?.ToPlatform() ?? new AColor());
        }

        public static void MapBackground(ITextInputLayoutHandler handler, ITextInputLayout entry) 
        {
            handler.PlatformView?.UpdateBackground(entry);
            
        }

        

        public static void TestHandler(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            var platform = handler.PlatformView;
            


        }
    }
}
