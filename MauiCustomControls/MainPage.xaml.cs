using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCustomControls.Pages;
using System.Collections.ObjectModel;
using Nwesp.Maui.Android.Controls;

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
      
            BindingContext = bc;
            var font = materialentry.FontFamily;
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

        [ObservableProperty]
        bool isEnabled;

        [RelayCommand]
        private async Task ButtonClicked()
        {
            IsEntryEnabled = !IsEntryEnabled;
            IsEnabled = !IsEnabled;
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

        [RelayCommand]
        private async Task EndIconClicked()
        {

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
