using Nwesp.Maui.Android.Models.Enums;

namespace Nwesp.Maui.Android.Samples;

public partial class PasswordPage : BaseDemoPage
{
	public PasswordPage()
	{
        BindingContext = this;
        InitializeComponent();
		
	}

    public Array Items => Enum.GetValues(typeof(IconVisibilityMode));

	private IconVisibilityMode _selectedIconVisibilityMode = IconVisibilityMode.HasTextWhileEditing;
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