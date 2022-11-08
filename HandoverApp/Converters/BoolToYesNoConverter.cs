using System;
using System.Globalization;
using HandoverApp.Resources;
using Xamarin.Forms;

namespace HandoverApp.Converters
{
    public class BoolToYesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Language.khong;
            if ((bool)value)
            {
                return Language.co;
            }
            else
            {
                return Language.khong;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
