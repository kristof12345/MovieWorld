using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Helpers
{
    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is List<object>)
            {
                var str = "";
                foreach (var g in (List<object>)value) { str += g.ToString(); str+= " "; }

                return str;
            }
            throw new ArgumentException("Invalid genre.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
