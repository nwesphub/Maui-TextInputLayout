using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout
{
    public class TextInputLayout : View, ITextInputLayout
    {
        public class test : Paint
        {

        }
        public TextInputLayout()
        {
            
        }

        static TextInputLayout()
        {
            BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(TextInputLayout));
        }

        public static readonly BindableProperty BackgroundColorProperty;
        public Color BackgroundColor
        {
            get => (Color)base.GetValue(BackgroundColorProperty);
            set => base.SetValue(BackgroundColorProperty, value);
        }

        public string AutomationId { get; set; }

        public FlowDirection FlowDirection { get; set; }

        public Microsoft.Maui.Primitives.LayoutAlignment HorizontalLayoutAlignment { get; set; }

        public Microsoft.Maui.Primitives.LayoutAlignment VerticalLayoutAlignment { get; set; }

        public Semantics? Semantics { get; set; }

        public IShape? Clip { get; set; }

        public IShadow? Shadow { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsFocused { get; set; }

        public Visibility Visibility { get; set; }

        public double Opacity { get; set; }

        public Paint? Background { get; set; }

        public Rect Frame { get; set; }

        public double Width { get; set; }

        public double MinimumWidth { get; set; }

        public double MaximumWidth { get; set; }

        public double Height { get; set; }

        public double MinimumHeight { get; set; }

        public double MaximumHeight { get; set; }

        public Thickness Margin { get; set; }

        public Size DesiredSize { get; set; }

        public int ZIndex { get; set; }

        public IViewHandler? Handler { get; set; }

        public bool InputTransparent { get; set; }

        public IElement? Parent { get; set; }

        public double TranslationX { get; set; }

        public double TranslationY { get; set; }

        public double Scale { get; set; }

        public double ScaleX { get; set; }

        public double ScaleY { get; set; }

        public double Rotation { get; set; }

        public double RotationX { get; set; }

        public double RotationY { get; set; }

        public double AnchorX { get; set; }

        public double AnchorY { get; set; }

        IElementHandler? IElement.Handler { get; set; }

        public Size Arrange(Rect bounds)
        {
            return new Size(bounds.Width, bounds.Height);
        }

        public bool Focus()
        {
            return true;
        }

        public void InvalidateArrange()
        {
        }

        public void InvalidateMeasure()
        {
        }

        public Size Measure(double widthConstraint, double heightConstraint)
        {
            return new Size(widthConstraint, heightConstraint);
        }

        public void Unfocus()
        {
        }
    }
}
