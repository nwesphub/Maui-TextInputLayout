using AndroidX.Lifecycle;
using Nwesp.Maui.Android.Models.Enums;
using Nwesp.Maui.Android.Samples.Services;
using System.Collections.ObjectModel;

namespace Nwesp.Maui.Android.Samples;

public partial class BaseDemoPage : ContentPage
{
	public BaseDemoPage()
	{
        var service = Application.Current?.Handler?.MauiContext?.Services.GetService<BoxBackgroundService>();
        BoxBackgroundMode = service.GetBackground();
        InitializeComponent();
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

    public Array IconVisibilityModes => Enum.GetValues(typeof(IconVisibilityMode));

    private IconVisibilityMode _selectedIconVisibilityMode = IconVisibilityMode.Always;
    public IconVisibilityMode SelectedIconVisibilityMode
    {
        get => _selectedIconVisibilityMode;
        set
        {
            _selectedIconVisibilityMode = value;
            OnPropertyChanged();
        }
    }
}