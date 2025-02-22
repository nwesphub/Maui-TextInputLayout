using Android.Content.PM;
using Android.Content.Res;
using Android.Views;
using AndroidX.AppCompat.View;
using Maui.Android.TextInputLayout.Platforms.Android;
using Microsoft.Maui.Controls.PlatformConfiguration;
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
using ContextThemeWrapper = AndroidX.AppCompat.View.ContextThemeWrapper;
using RResource = Android.Resource.Attribute;
using AView = Android.Views.View;
namespace Maui.Android.TextInputLayout
{
    public partial class TextInputLayoutHandler : ViewHandler<ITextInputLayout, MauiTextInputLayout>
    {

        MauiTextInputLayout _nativeEntry;
        protected override MauiTextInputLayout CreatePlatformView()
        {
            return InternalCreatePlatformView();
        }

        private MauiTextInputLayout InternalCreatePlatformView()
        {
            _nativeEntry = new MauiTextInputLayout(Context);
            return _nativeEntry;
        }

        private MauiTextInputLayout InternalCreateContextThemeView()
        {
            var result = new ContextThemeWrapper(Context, Resource.Style.Widget_Material3_TextInputLayout_OutlinedBox_Dense); // Widget_Material3_TextInputEditText_OutlinedBox
            _nativeEntry = new MauiTextInputLayout(result);
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
            handler.PlatformView.UpdateBackground(entry);
            TestHandler(handler, entry);
            
        }

        public static void MapMaxLines(ITextInputLayoutHandler handler, ITextInputLayout view)
        {
            handler.PlatformView.MauiTextInputEditText.SetMaxLines(1);
        }

        public static void TestHandler(ITextInputLayoutHandler handler, ITextInputLayout entry)
        {
            var platform = handler.PlatformView;


            //handler.PlatformView.BoxStrokeColor = 23423423; -- Changes the bottom underline color

            int[][] states =
            [
                [ RResource.Enabled ],
                [-RResource.Enabled ],
                [-RResource.Checked ],
                [ RResource.Checked ]
            ];

            int[] colors = 
            [
                Colors.Black.ToPlatform(),
                Colors.Green.ToPlatform(),
                Colors.Green.ToPlatform(),
                Colors.Blue.ToPlatform()
            ];
            ColorStateList csl = new ColorStateList(states, colors);

            handler.PlatformView.UpdateBorder(entry);
            handler.PlatformView.SetBoxStrokeColorStateList(csl);

        }
    }
}
