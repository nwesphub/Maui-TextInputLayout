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
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            InitializeComponent();
            BindingContext = new MainPageViewModel(this);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            
        }

        public TextInputLayout GetTextInputLayout()
        {
            return testEntry;
        }
    }

    public partial class MainPageViewModel : ObservableObject
    {
        MainPage _mainPage;
        public MainPageViewModel(MainPage mainPage)
        {
            _mainPage = mainPage;
        }
        [ObservableProperty]
        string entryText = "test";

        [ObservableProperty]
        Color outlineEntryColor = Color.FromHex("FFFFFF"); //Color.FromHex("19f50a");

        [ObservableProperty]
        bool isEntryEnabled;

        [RelayCommand]
        private async Task ButtonClicked()
        {
            IsEntryEnabled = !IsEntryEnabled;
        }
    }
}
