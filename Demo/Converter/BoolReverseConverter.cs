using MahApps.Metro;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Demo.Converter
{
    public class BoolReverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool ? !(bool)value : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool ? !(bool)value : value;
        }
    }
}
