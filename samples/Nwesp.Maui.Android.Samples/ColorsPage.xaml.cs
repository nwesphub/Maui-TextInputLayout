using Nwesp.Maui.Android.Abstractions;
using Nwesp.Maui.Android.Controls;
using Nwesp.Maui.Android.Samples.Controls;
using Nwesp.Maui.Android.Utilities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Nwesp.Maui.Android.Samples;

public partial class ColorsPage : BaseDemoPage
{
	public ColorsPage()
    {
        InitializeComponent();
        _initialBackgroundColor = BackgroundColor;
        ResetCurrentPropertyCommand = new Command(() =>
        {
            var properties = GetInitialProperties();
            SelectedColor = properties.FirstOrDefault(x => x.GetHashCode() == SelectedProperty?.GetHashCode())?.Color ?? Colors.Transparent;
        });

        ResetAllPropertiesCommand = new Command(() =>
        {
            ResetProperties();
            foreach(var property in Properties)
            {
                UpdateProperty(property);
            }
        });
        ResetProperties();
        _selectedProperty = Properties.FirstOrDefault()!;
        BindingContext = this;
    }

    private const string _pageBackgroundColorDisplayName = "Page Background Color";
    private const string _entryTextColorDisplayName = "Input Text Color";
    Color _initialBackgroundColor = Colors.Transparent;

	private ObservableCollection<TextInputLayoutColorPicker> _properties = [];
	public ObservableCollection<TextInputLayoutColorPicker> Properties
	{
		get => _properties;
		set
		{
			_properties = value;
			OnPropertyChanged();
        }
    }

    private TextInputLayoutColorPicker _selectedProperty;
    public TextInputLayoutColorPicker SelectedProperty
    {
        get => _selectedProperty;
        set
        {
            _selectedProperty = value;
            if (value is not null)
            {
                SelectedColor = value.Color;
            }
            OnPropertyChanged();
        }
    }

    private Color _selectedColor = Colors.Transparent;
    public Color SelectedColor
    {
        get => _selectedColor;
        set
        {
            _selectedColor = value;
            OnPropertyChanged();
        }
    }

    public ICommand ResetCurrentPropertyCommand { get; set; }
    public ICommand ResetAllPropertiesCommand { get; set; }

    private void ResetProperties()
    {
        Properties = new(GetInitialProperties());
    }

    public IEnumerable<TextInputLayoutColorPicker> GetInitialProperties()
	{
        return new List<TextInputLayoutColorPicker>()
        {
            new (nameof(ScrollView.BackgroundColor), _initialBackgroundColor, _pageBackgroundColorDisplayName),
            new (nameof(MaterialEntry.TextColor), ThemeHelper.GetInputTextColor(), _entryTextColorDisplayName),
            new (nameof(TextInputLayout.BackgroundColor), ThemeHelper.GetContainerColor(BoxBackgroundMode), "Background Color"),
            new (nameof(TextInputLayout.OutlineColor), ThemeHelper.GetOutlineColor(), "Outline Color"),
            new (nameof(TextInputLayout.FocusedOutlineColor), ThemeHelper.GetFocusedOutlineColor(), "Focused Outline Color"),
            new (nameof(TextInputLayout.HintColor), ThemeHelper.GetLabelTextColor(), "Hint Color"),
            new (nameof(TextInputLayout.FocusedHintColor), ThemeHelper.GetFocusedLabelTextColor(), "Focused Hint Color"),
            new (nameof(TextInputLayout.EndIconColor), ThemeHelper.GetTrailingIconColor(), "End Icon Color"),
            new (nameof(TextInputLayout.SupportingTextColor), ThemeHelper.GetSupportingTextColor(), "Supporting Text Color"),
            new (nameof(TextInputLayout.CursorColor), ThemeHelper.GetCaretColor(), "Cursor Color"),
        }
        .OrderBy(x => x.DisplayName);
    }
    
    private void ColorPicker_ColorChanged(object sender, ColorChangedEventArgs e)
    {
        if (SelectedProperty is not null)
        {
            SelectedProperty.Color = e.Color;
            UpdateProperty(SelectedProperty);
        }
    }

    private void UpdateProperty(TextInputLayoutColorPicker selectedProperty)
    {
        if (selectedProperty.DisplayName == _pageBackgroundColorDisplayName)
        {
            SetPropertyValue(ScrollView, selectedProperty.PropertyName, selectedProperty.Color);
        }
        else if (selectedProperty.DisplayName == _entryTextColorDisplayName)
        {
            SetPropertyValue(MaterialEntry1, selectedProperty.PropertyName, selectedProperty.Color);
            SetPropertyValue(MaterialEntry2, selectedProperty.PropertyName, selectedProperty.Color);
        }
        else
        {
            SetPropertyValue(TextInputLayout1, selectedProperty.PropertyName, selectedProperty.Color);
            SetPropertyValue(TextInputLayout2, selectedProperty.PropertyName, selectedProperty.Color);
        }
    }

    public static void SetPropertyValue(object target, string propertyName, object value)
    {
        var type = target.GetType();
        var prop = type.GetProperty(propertyName);

        if (prop == null || !prop.CanWrite)
            return;

        var propType = prop.PropertyType;

        if (value != null && !propType.IsAssignableFrom(value.GetType()))
        {
            value = Convert.ChangeType(value, propType);
        }

        prop.SetValue(target, value);
    }
}


public class TextInputLayoutColorPicker : INotifyPropertyChanged
{
    public TextInputLayoutColorPicker(string propertyName, Color color, string? displayName = null)
    {
        PropertyName = propertyName;
        Color = color;
        DisplayName = displayName ?? PropertyName;
    }

    private string _propertyName = string.Empty;
    public string PropertyName
    {
        get => _propertyName;
        set
        {
            _propertyName = value;
            OnPropertyChanged();
        }
    }

    private string _displayName = string.Empty;
    public string DisplayName
    {
        get => _displayName;
        set
        {
            _displayName = value;
            OnPropertyChanged();
        }
    }


    private Color _color = Colors.Transparent;
    public Color Color
    {
        get => _color;
        set
        {
            _color = value;
            OnPropertyChanged();
        }
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(PropertyName, DisplayName);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
