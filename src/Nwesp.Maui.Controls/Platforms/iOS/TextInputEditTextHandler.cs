using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout
{

    public partial class TextInputEditTextHandler : ViewHandler<TextInputEditText, MauiTextInputEditText>
    {
        protected override MauiTextInputEditText CreatePlatformView()
        {
            throw new NotImplementedException();
        }
        public static async void MapBackgroundColor(ITextInputEditTextHandler handler, ITextInputEditText entry)
        {

        }
    }
}
