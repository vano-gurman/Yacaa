using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Yacaa.Xaml.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && (bool)value ? new SolidColorBrush(Colors.Firebrick) : new SolidColorBrush(Colors.ForestGreen);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}