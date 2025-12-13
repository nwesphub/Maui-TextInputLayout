using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.Android.TextInputLayout;

namespace MauiCustomControls
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }

    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string entryText;

        [ObservableProperty]
        Color outlineEntryColor = Color.FromHex("FFFFFF"); //Color.FromHex("19f50a");

        [RelayCommand]
        private async Task ButtonClicked()
        {
            string text = EntryText;
            EntryText = "sdfsdfsdf";
        }
    }
}
