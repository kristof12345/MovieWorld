using MovieWorld.Models;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Helpers
{
    public class GenreToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var str = "";
            if (value is List<Genre>)
            {
                foreach (var g in (List<Genre>)value) { str += g.Name; str+= " "; } 
            }
            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class LanguageToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var str = "";
            if (value is List<Language>)
            {
                foreach (var g in (List<Language>)value) { str += g.Name; str += " "; }
            }
            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class NetworkToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var str = "";
            if (value is List<Network>)
            {
                foreach (var g in (List<Network>)value) { str += g.Name; str += " "; }
            }
            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class CompanyToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var str = "";
            if (value is List<Company>)
            {
                foreach (var g in (List<Company>)value) { str += g.Name; str += " "; }
            }
            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
