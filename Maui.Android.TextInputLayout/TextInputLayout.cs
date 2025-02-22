using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout
{
    public class TextInputLayout : Layout, ITextInputLayout
    {
       
        public TextInputLayout()
        {
            
        }

        static TextInputLayout()
        {

        }

        protected override ILayoutManager CreateLayoutManager()
        {
            return new TextInputLayoutManager(this);
        }
    }
}
