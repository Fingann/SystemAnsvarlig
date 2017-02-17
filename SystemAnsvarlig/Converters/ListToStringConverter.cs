using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemAnsvarlig.Converters
{
    using System.Globalization;
    using System.Windows.Data;
    class ListToStringConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<string>)
            {
                var list = value as List<string>;
                return list.Aggregate((a, b) => a + ", " + b);
            }
            return "Ikke satt";
        }
           

          

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
