using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace StockAlarm.ViewModel
{
    public abstract class BaseOnewayConverter : MarkupExtension, IValueConverter
    {
        public BaseOnewayConverter() { }
        // source to binding target
        public abstract object Convert(object value, Type targetType,
                               object parameter, CultureInfo culture);
        // binding target to source
        public object ConvertBack(object value, Type targetType,
                      object parameter, CultureInfo culture)
        {
            return new NotImplementedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }

    public class VisivilityConverter : BaseOnewayConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)    return Visibility.Visible;
            else return Visibility.Collapsed;
        }
    }
}
