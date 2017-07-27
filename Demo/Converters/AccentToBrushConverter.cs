using MahApps.Metro;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Demo.Converters
{
    public class AccentToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Accent accent)
            {
                return accent.Resources["AccentColorBrush"];
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Can not convert Brush to Accent !");
        }
    }
}
