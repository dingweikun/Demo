using Demo.Module;
using MahApps.Metro;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Demo.Converter
{
    public class ModuleCategoryToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ProjectModuleCategory category)
            {
                return (int)category;
            }
            return -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           if(Enum.IsDefined(typeof(ProjectModuleCategory), (int)value))
            {
                return (ProjectModuleCategory)(int)(value);
            }
            else
            {
                return null;
            }

        }
    }
}
