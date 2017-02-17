using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemAnsvarlig.Converters
{
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    class PriceToVisibilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = value.ToString();
            var visability = string.IsNullOrEmpty(stringValue) ? Visibility.Collapsed : Visibility.Visible;
            return visability;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
