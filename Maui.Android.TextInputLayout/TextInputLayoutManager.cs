using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILayout = Microsoft.Maui.ILayout;

namespace Maui.Android.TextInputLayout
{
    public class TextInputLayoutManager : LayoutManager
    {
        public TextInputLayoutManager(ILayout layout) : base(layout)
        {
        }

        public override Size ArrangeChildren(Rect bounds)
        {
            return new Size(bounds.Width, bounds.Height);
        }

        public override Size Measure(double widthConstraint, double heightConstraint)
        {
            return new Size(widthConstraint, heightConstraint);
        }
    }
}
