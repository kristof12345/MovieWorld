﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MovieWorld.Models;
using System.Linq;

namespace MovieWorld.Services
{
    public static class MovieDataService
    {
        private static HttpService HttpService { get; set; } = new HttpService();

        public static ObservableCollection<Movie> TopMoviesList { get; set; } = new ObservableCollection<Movie>();

        //Top filmek letöltése a szerverről
        internal static async Task GetTopMoviesAsync()
        {
            if (TopMoviesList.Count == 0)
            {
                var list = await HttpService.ListTopMoviesAsync();
                TopMoviesList.Clear();

                foreach (var movie in list)
                {
                    var details = await HttpService.GetMovieAsync(movie.Id);
                    var cast  = await HttpService.GetCastAsync(movie.Id);
                    if (cast != null)
                    {
                        details.Cast = cast.Where(c => c.Profile_path != null).Take(12).ToList();
                        TopMoviesList.Add(details);
                    }
                }
            }
        }
    }
}
