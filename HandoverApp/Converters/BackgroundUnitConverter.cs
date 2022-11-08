using System;
using System.Globalization;
using HandoverApp.Models;
using Xamarin.Forms;

namespace HandoverApp.Converters
{
    public class BackgroundUnitConverter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return StatusCodeUnit.GetStatusCodeById(value.ToString()).Background;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
