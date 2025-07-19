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

        [RelayCommand]
        private async Task ButtonClicked()
        {
            string text = EntryText;
        }
    }
}
