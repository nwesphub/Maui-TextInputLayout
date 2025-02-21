using Android.Content.PM;
using Maui.Android.TextInputLayout.Platforms.Android;
using Microsoft.Maui.Handlers;
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
        

        protected override MauiTextInputLayout CreatePlatformView()
        {
            return new MauiTextInputLayout(Context, VirtualView);
        }

        protected override void ConnectHandler(MauiTextInputLayout platformView)
        {
            base.ConnectHandler(platformView);
        }

        public static void MapBackgroundColor(ITextInputLayoutHandler handler, ITextInputLayout view)
        {
            handler.PlatformView.SetBackgroundColor(new AColor(200, 200, 200));
        }
    }
}
