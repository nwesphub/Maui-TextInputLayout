using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiCustomControls.Pages;


public partial class HintPage : ContentPage
{
	public HintPage()
	{
		InitializeComponent();
		BindingContext = new HintPageViewModel();

    }

	partial class HintPageViewModel : ObservableObject
    {
		public HintPageViewModel()
		{

		}
        [ObservableProperty]
        string entryText = "test";

        [ObservableProperty]
        Color outlineEntryColor = Color.FromHex("FFFFFF"); //Color.FromHex("19f50a");

        [ObservableProperty]
        bool isEntryEnabled;
    }
}