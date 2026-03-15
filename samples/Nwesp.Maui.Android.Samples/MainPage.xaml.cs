using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Nwesp.Maui.Android.Samples
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            Data = new(PageRoute.GetPages());
            PageCommand = new Command<object>(GoToPage);
        }

        private ObservableCollection<PageRoute> _data;
        public ObservableCollection<PageRoute> Data
        {
            get => _data;
            set
            {
                _data = value;
                OnPropertyChanged();
            }
        }

        public ICommand PageCommand { get; }

 
        private async void GoToPage(object obj)
        {
            if(obj is not string page)
            {
                return;
            }

            await Shell.Current.GoToAsync(page);
        }
    }


    public class PageRoute
    {
        public string Route { get; set; }
        public string Description { get; set; }

        public PageRoute(string route, string description)
        {
            Route = route;
            Description = description;
        }

        public static IEnumerable<PageRoute> GetPages()
        {
            return [
                new PageRoute(nameof(PasswordPage), "Password Demo")
            ];
        }
    }
}
