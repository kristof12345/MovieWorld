using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MovieWorld.Models;

namespace MovieWorld.Services
{
    public static class DataService
    {
        public static ObservableCollection<Movie> MovieList { get; set; } = new ObservableCollection<Movie>();
        public static Movie DetailedMovie { get; set; }

        //Filmek letöltése a szerverről
        public static async Task GetMovieListAsync()
        {
            var list = await HttpService.ListTopMoviesAsync();
            MovieList.Clear();
            foreach(var movie in list) { MovieList.Add(movie); }
        }

        //Egy film részletes adatai
        internal static async Task GetMovieAsync(Movie movie)
        {
            var detailedMovie = await HttpService.GetMovieAsync(movie.Id);
            detailedMovie.Detailed = true;
            detailedMovie.Cast = await HttpService.GetCastAsync(movie.Id);
            DetailedMovie = detailedMovie;
        }

        //Egy személy részletei
        internal static async Task GetActorAsync(int id)
        {
            await HttpService.GetActorAsync(id);
        }
    }
}
