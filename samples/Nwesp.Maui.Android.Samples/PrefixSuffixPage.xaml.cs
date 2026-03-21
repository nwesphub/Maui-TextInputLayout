using System.Windows.Input;

namespace Nwesp.Maui.Android.Samples;

public partial class PrefixSuffixPage : BaseDemoPage
{
	public PrefixSuffixPage()
	{
        ClickCommand = new Command(() => { IsVisiblee = !IsVisiblee; });
        InitializeComponent();
		BindingContext = this;
        
	}
	public ICommand ClickCommand { get; }
    private bool _isVisible;
    public bool IsVisiblee
    {
        get => _isVisible;
        set
        {
            _isVisible = value;
            OnPropertyChanged();
        }
    }
    private string _prefix = "$";
	public string Prefix
	{
		get => _prefix;
		set
		{
			_prefix = value;
			OnPropertyChanged();
		}
    }

	private string _suffix = "%";
    public string Suffix
    {
        get => _suffix;
        set
        {
            _suffix = value;
            OnPropertyChanged();
        }
    }
}