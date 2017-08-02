using MahApps.Metro;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Demo.Converter
{
    /// <summary>
    /// True = Visibility.Hidden
    /// False = Visibility.Visible
    /// </summary>
    public class BoolToVisibilityHiddenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return (bool)value ? Visibility.Hidden : Visibility.Visible;
            }
            throw new ArgumentException("converter target is not [bool] type");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new ArgumentException("can not convert [Visibility] type back to [bool]");
        }
    }
}
