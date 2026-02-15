using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.Android.TextInputLayout;
using MauiCustomControls.Pages;
using System.Collections.ObjectModel;

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
            Pages = new (TestPage.GetPages());
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

        [ObservableProperty]
        ObservableCollection<string> pages = [];

        [RelayCommand]
        private async Task GoToPage(object obj)
        {
            if (string.IsNullOrWhiteSpace(obj?.ToString()))
            {
                return;
            }

            await Shell.Current.GoToAsync(obj.ToString());
        }
    }

    public class TestPage
    {
        public string Name { get; set; }

        public static IEnumerable<string> GetPages()
        {
            return
            [
                nameof(HintPage)
            ];

        }
    }
}
