using MovieWorld.Models;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Helpers
{
    public class LanguageToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is List<Language>)
            {
                var str = "";
                foreach (var g in (List<Language>)value) { str += g.Name; str+= " "; }

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
