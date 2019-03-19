using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MovieWorld.Models;
using System;

namespace MovieWorld.Services
{
    public static class DataService
    {
        public static ObservableCollection<Movie> MovieList { get; set; } = new ObservableCollection<Movie>();

        public static ObservableCollection<Movie> FavouriteMovies { get; set; } = new ObservableCollection<Movie>();

        //Filmek letöltése a szerverről
        public static async Task<IEnumerable<Movie>> GetMovieListAsync()
        {
            return await HttpService.ListTopMoviesAsync();
        }

        //Kedvenc filmek
        public static ObservableCollection<Movie> GetFavouriteMovies()
        {
            return FavouriteMovies;
        }

        internal static async Task<Movie> GetMovieAsync(Movie movie)
        {
            return await HttpService.GetMovieAsync(movie.Id);
        }

        internal static async Task<List<Actor>> GetCastAsync(Movie movie)
        {
            return await HttpService.GetCastAsync(movie.Id);
        }
    }
}
