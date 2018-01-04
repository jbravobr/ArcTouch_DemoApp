using System;
using System.Globalization;
using Xamarin.Forms;

namespace ArcTouch.TestApp
{
    public class TextChangedEventArgsToTextChangedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as TextChangedEventArgs;
            return eventArgs.NewTextValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}