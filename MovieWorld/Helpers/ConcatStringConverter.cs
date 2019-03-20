using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Helpers
{
    class ConcatStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string && parameter is string)
            {
                return (string)value + (string)parameter;
            }
            throw new ArgumentException("Invalid value.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
