using MovieWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
