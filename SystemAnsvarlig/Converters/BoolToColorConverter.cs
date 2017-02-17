using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemAnsvarlig.Converters
{
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    class BoolToColorConverter: IValueConverter
    {

        public Brush TrueBrush { get; set; } = Brushes.OrangeRed;

        public Brush FalseBrush { get; set; } = Brushes.LimeGreen;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = value as bool? ?? true;
            if (parameter != null && parameter.ToString() == "!")
            {
                boolValue = !boolValue;
            }

            if (boolValue)
            {
                return TrueBrush;
            }
            return FalseBrush;
        }
    

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
