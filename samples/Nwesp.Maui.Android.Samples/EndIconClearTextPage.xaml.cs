using System.Windows.Input;

namespace Nwesp.Maui.Android.Samples;

public partial class EndIconClearTextPage : BaseDemoPage
{
	public EndIconClearTextPage()
	{
		InitializeComponent();
		EndIconClickedCommand = new Command(async () =>
		{
			await DisplayAlertAsync("Command", "Custom Click Command", "Ok");
		});
        BindingContext = this;
	}

	public ICommand EndIconClickedCommand { get; }
}