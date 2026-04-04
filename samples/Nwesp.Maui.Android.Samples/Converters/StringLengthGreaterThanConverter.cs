using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Nwesp.Maui.Android.Samples.Converters
{
    public class StringLengthGreaterThanConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is not string text || !int.TryParse(parameter?.ToString(), out var number))
            {
                return false;
            }
            return text.Length > number;
 
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
