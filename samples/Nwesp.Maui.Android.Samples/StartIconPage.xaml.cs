using System.Windows.Input;

namespace Nwesp.Maui.Android.Samples;

public partial class StartIconPage : BaseDemoPage
{
	public StartIconPage()
	{
		InitializeComponent();
		StartIconClickedCommand = new Command(() =>
		{

		});
		BindingContext = this;
	}

	public ICommand StartIconClickedCommand { get; }
}