
using Android.Widget;
using Nwesp.Maui.Android.Models.Enums;
using Nwesp.Maui.Android.Samples.Services;
using System.Diagnostics;
using System.Windows.Input;

namespace Nwesp.Maui.Android.Samples.Controls;

public partial class ColorPicker : ContentView
{
	public ColorPicker()
	{
        var service = Application.Current?.Handler?.MauiContext?.Services.GetService<BoxBackgroundService>();
        BoxBackgroundMode = service?.GetBackground() ?? BoxBackgroundMode.Outline;
        
        InitializeComponent();
        StartIconClickedCommand = new Command(async () =>
        {
            await Clipboard.Default.SetTextAsync(ColorHex);
            Toast.MakeText(global::Android.App.Application.Context, "Copied!", ToastLength.Short)?.Show();
        });
        EndIconClickedCommand = new Command(async () =>
        {
            ColorHex = await Clipboard.Default.GetTextAsync() ?? string.Empty;
            Toast.MakeText(global::Android.App.Application.Context, "Pasted!", ToastLength.Short)?.Show();
        });
        OnPropertyChanged(nameof(StartIconClickedCommand));
        OnPropertyChanged(nameof(EndIconClickedCommand));
    }

    public ICommand StartIconClickedCommand { get; }
    public ICommand EndIconClickedCommand { get; }

    public event EventHandler<ColorChangedEventArgs>? ColorChanged;

    public static readonly BindableProperty SelectedColorProperty =
    BindableProperty.Create(
        nameof(SelectedColor),
        typeof(Color),
        typeof(ColorPicker),
        Colors.White,
        BindingMode.TwoWay,
        propertyChanged: SelectedColorPropertyChanged);

    public Color SelectedColor
    {
        get => (Color)GetValue(SelectedColorProperty);
        set => SetValue(SelectedColorProperty, value);
    }

    private BoxBackgroundMode _boxBackgroundMode;
    public BoxBackgroundMode BoxBackgroundMode
    {
        get => _boxBackgroundMode;
        set
        {
            _boxBackgroundMode = value;
            OnPropertyChanged();
        }
    }

    private string _colorHex = string.Empty;
    public string ColorHex
    {
        get => _colorHex;
        set
        {
            _colorHex = value;
            OnPropertyChanged();
        }
    }

    static void SelectedColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is not ColorPicker control || newValue is not Color color)
        {
            return;
        }

        if (!control._updatingText)
        {
            control.ColorHex = color.ToArgbHex();
        }
        if(control._isInternalUpdating)
        {
            return;
        }
        
        control.UpdateFromColor(color);
    }
    
    private ColorBoxDrawable _colorBoxDrawable = new();
    public ColorBoxDrawable ColorBoxDrawable
    {
        get => _colorBoxDrawable;
        set
        {
            _colorBoxDrawable = value;
            OnPropertyChanged();
        }
    }

    private HueDrawable _hueDrawable = new();
    public HueDrawable HueDrawable
    {
        get => _hueDrawable;
        set
        {
            _hueDrawable = value;
            OnPropertyChanged();
        }
    }

    float _hue = 0;
    float _saturation = 1;
    float _value = 1;
    float _startX;
    float _startY;
    float _lastHueX;
    float _currentHueX;

    public static void HslToHsv(double h, double s, double l, out double hOut, out double sOut, out double vOut)
    {
        hOut = h;

        double v = l + s * Math.Min(l, 1 - l);
        double newS = v == 0 ? 0 : 2 * (1 - l / v);

        sOut = newS;
        vOut = v;
    }
    void UpdateFromColor(Color color)
    {
        color.ToHsl(out float h, out float s, out float l);
        HslToHsv(h, s, l, out double hsvH, out double hsvS, out double hsvV);

        _hue = (float)hsvH;
        _saturation = (float)hsvS;
        _value = (float)hsvV;

        
        InvalidateHue();

        _currentHueX = _hue * (float)HueBar.Width;
        _lastHueX = _currentHueX;

        // Update color box
        if (ColorBox.Drawable is ColorBoxDrawable colorDrawable)
        {
            colorDrawable.SelectedHue = Color.FromHsv(_hue, 1, 1);

            colorDrawable.SelectorX = _saturation;
            colorDrawable.SelectorY = 1f - _value;

            ColorBox.Invalidate();
        }
    }

    void OnColorBoxPan(object sender, PanUpdatedEventArgs e)
    {
        var view = ColorBox;

        if (view.Width <= 0 || view.Height <= 0)
            return;

        switch (e.StatusType)
        {
            case GestureStatus.Started:
                // Anchor to current selector position
                _startX = (float)(_saturation * view.Width);
                _startY = (float)((1f - _value) * view.Height);
                break;

            case GestureStatus.Running:

                // Compute absolute position from start + total movement
                float x = _startX + (float)e.TotalX;
                float y = _startY + (float)e.TotalY;

                // Clamp to bounds
                x = Math.Clamp(x, 0, (float)view.Width);
                y = Math.Clamp(y, 0, (float)view.Height);

                float saturation = x / (float)view.Width;
                float value = 1f - (y / (float)view.Height);

                UpdateColor(saturation, value);

                if (ColorBox.Drawable is ColorBoxDrawable drawable)
                {
                    drawable.SelectorX = saturation;
                    drawable.SelectorY = y / (float)view.Height;
                    view.Invalidate();
                }

                break;
        }
    }

    void OnColorBoxTapped(object sender, TappedEventArgs e)
    {
        if (sender is not GraphicsView view || view.Width <= 0 || view.Height <= 0)
        {
            return;
        }
    
        var point = e.GetPosition(view);

        if (point == null)
            return;

        float x = (float)point.Value.X;
        float y = (float)point.Value.Y;

        x = Math.Clamp(x, 0, (float)view.Width);
        y = Math.Clamp(y, 0, (float)view.Height);

        float saturation = x / (float)view.Width;
        float value = 1f - (y / (float)view.Height);

        UpdateColor(saturation, value);

        if (ColorBox.Drawable is ColorBoxDrawable drawable)
        {
            drawable.SelectorX = saturation;
            drawable.SelectorY = y / (float)view.Height;
            view.Invalidate();
        }
    }
    

    void UpdateHue(double hue)
    {
        _hue = (float)Math.Clamp(hue, 0, 1);
        InvalidateHue();

        if (ColorBox.Drawable is ColorBoxDrawable colorDrawable)
        {
            colorDrawable.SelectedHue = Color.FromHsv(_hue, 1, 1);
            ColorBox.Invalidate();
        }

        UpdateColor(_saturation, _value);
    }

    private void InvalidateHue()
    {
        if (HueBar.Drawable is HueDrawable hueDrawable)
        {
            hueDrawable.HuePosition = _hue;
            HueBar.Invalidate();
        }
    }

    private bool _isInternalUpdating;
    void UpdateColor(double saturation, double value)
    {
        _saturation = (float)Math.Clamp(saturation, 0, 1);
        _value = (float)Math.Clamp(value, 0, 1);

        _isInternalUpdating = true;
        SelectedColor = Color.FromHsv(_hue, _saturation, _value);
        _isInternalUpdating = false;

        InvokeColorChangeEvent();
    }

    private void InvokeColorChangeEvent()
    {
        ColorChanged?.Invoke(this, new ColorChangedEventArgs(SelectedColor));
    }
    

    void OnHueTapped(object sender, TappedEventArgs e)
    {
        var view = (GraphicsView)sender;

        var point = e.GetPosition(view);
        if (point == null || view.Width <= 0)
            return;

        float x = (float)point.Value.X;
        x = Math.Clamp(x, 0, (float)view.Width);

        float hue = x / (float)view.Width;

        UpdateHue(hue);

        _currentHueX = x;
        _lastHueX = x;

        view.Invalidate();
    }
    void OnHuePan(object sender, PanUpdatedEventArgs e)
    {
        if(sender is not GraphicsView view)
        {
            return;
        }

        switch (e.StatusType)
        {
            case GestureStatus.Started:
                // treat tap start as immediate update
                UpdateHueFromX(_lastHueX, view);
                break;
            case GestureStatus.Running:
                _currentHueX = (float)Math.Clamp(_lastHueX + e.TotalX, 0, view.Width);

                float hue = _currentHueX / (float)view.Width;

                UpdateHue(hue);
                view.Invalidate();
                break;

            case GestureStatus.Completed:
            case GestureStatus.Canceled:
                _lastHueX = _currentHueX;
                break;
        }
    }
    void UpdateHueFromX(float x, GraphicsView view)
    {
        float hue = x / (float)view.Width;
        UpdateHue(hue);
    }

    private bool _updatingText;
    private void MaterialEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        _updatingText = true;
        if(!_isInternalUpdating)
        {
            try
            {
                var color = Color.FromArgb(e.NewTextValue);
                if (color != SelectedColor)
                {
                    SelectedColor = color;
                    InvokeColorChangeEvent();
                }
            }
            catch(Exception)
            {

            }
        }
        _updatingText = false;
    }
}

public class ColorBoxDrawable : IDrawable
{
    public Color SelectedHue { get; set; } = Colors.Blue;
    public float SelectorX { get; set; } = 1f;
    public float SelectorY { get; set; } = 0f;
    public void Draw(ICanvas canvas, RectF rect)
    {
        // Base hue gradient (left ? right: white ? hue)
        var gradient = new LinearGradientPaint
        {
            StartColor = Colors.White,
            EndColor = SelectedHue,
            StartPoint = new Point(0, 0),
            EndPoint = new Point(1, 0)
        };

        canvas.SetFillPaint(gradient, rect);
        canvas.FillRectangle(rect);

        // Overlay: black gradient (top ? bottom)
        var blackGradient = new LinearGradientPaint
        {
            StartColor = Colors.Transparent,
            EndColor = Colors.Black,
            StartPoint = new Point(0, 0),
            EndPoint = new Point(0, 1)
        };

        canvas.SetFillPaint(blackGradient, rect);
        canvas.FillRectangle(rect);

        float x = rect.Left + SelectorX * rect.Width;
        float y = rect.Top + SelectorY * rect.Height;

        float radius = 12;

        // Outer white ring
        canvas.StrokeColor = Colors.White;
        canvas.StrokeSize = 3;
        canvas.DrawCircle(x, y, radius);

        // Inner black ring (for contrast on bright colors)
        canvas.StrokeColor = Colors.Black;
        canvas.StrokeSize = 1;
        canvas.DrawCircle(x, y, radius - 2);
    }
}


public class HueDrawable : IDrawable
{
    public float HuePosition { get; set; } = 0f;
    public void Draw(ICanvas canvas, RectF rect)
    {
        var gradient = new LinearGradientPaint
        {
            GradientStops =
            [
                new PaintGradientStop(0, Colors.Red),
                new PaintGradientStop(0.17f, Colors.Yellow),
                new PaintGradientStop(0.33f, Colors.Green),
                new PaintGradientStop(0.5f, Colors.Cyan),
                new PaintGradientStop(0.67f, Colors.Blue),
                new PaintGradientStop(0.83f, Colors.Magenta),
                new PaintGradientStop(1, Colors.Red)
            ],
            StartPoint = new Point(0, 0),
            EndPoint = new Point(1, 0)
        };

        canvas.SetFillPaint(gradient, rect);
        canvas.FillRoundedRectangle(rect, 10);


        float x = rect.Left + HuePosition * rect.Width;
        float y = rect.Center.Y;

        float radius = 12;

        // Outer white ring
        canvas.StrokeColor = Colors.White;
        canvas.StrokeSize = 3;
        canvas.DrawCircle(x, y, radius);

        // Inner fill (current hue color)
        canvas.FillColor = Color.FromHsv(HuePosition, 1, 1);
        canvas.FillCircle(x, y, radius - 4);
    }
}

public class ColorChangedEventArgs : EventArgs
{
    public Color Color { get; set; }

    public ColorChangedEventArgs(Color color)
    {
        Color = color;
    }
}