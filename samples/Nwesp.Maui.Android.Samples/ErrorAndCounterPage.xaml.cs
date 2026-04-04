using Nwesp.Maui.Android.Utilities;
using System.Windows.Input;

namespace Nwesp.Maui.Android.Samples;

public partial class ErrorAndCounterPage : BaseDemoPage
{
	public ErrorAndCounterPage()
	{
		InitializeComponent();
        ButtonClickedCommand = new Command(() =>
        {
            IsErrorEnabled = !IsErrorEnabled;
        });
        BindingContext = this;
	}

    private bool _isErrorEnabled;
    public bool IsErrorEnabled
    {
        get => _isErrorEnabled;
        set
        {
            _isErrorEnabled = value;
            OnPropertyChanged();
        }
    }
    private string _exceededCounterLengthText;
    public string ExceededCounterLengthText
    {
        get => _exceededCounterLengthText;
        set
        {
            _exceededCounterLengthText = value;
            OnPropertyChanged();
        }
    }


    public ICommand ButtonClickedCommand { get; }
}