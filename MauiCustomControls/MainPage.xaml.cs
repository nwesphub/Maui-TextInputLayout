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
            var bc = new MainPageViewModel(this);
            bc.t1 = textinputlayout1;
            bc.t2 = textinputlayout2;
            BindingContext = bc;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            
        }

        //public TextInputLayout GetTextInputLayout()
        //{
        //    return testEntry;
        //}
    }

    public partial class MainPageViewModel : ObservableObject
    {
        public TextInputLayout t1;
        public TextInputLayout t2;
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
