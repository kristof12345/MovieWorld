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
            if (value is List<Genre>)
            {
                var str = "";
                foreach (var g in (List<Genre>)value) { str += g.Name; str+= " "; }

                return str;
            }
            throw new ArgumentException("Invalid genre.");
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
            if (value is List<Language>)
            {
                var str = "";
                foreach (var g in (List<Language>)value) { str += g.Name; str += " "; }

                return str;
            }
            throw new ArgumentException("Invalid genre.");
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
            if (value is List<Network>)
            {
                var str = "";
                foreach (var g in (List<Network>)value) { str += g.Name; str += " "; }

                return str;
            }
            throw new ArgumentException("Invalid genre.");
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
            if (value is List<Company>)
            {
                var str = "";
                foreach (var g in (List<Company>)value) { str += g.Name; str += " "; }

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
