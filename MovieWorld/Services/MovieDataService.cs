using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MovieWorld.Models;

namespace MovieWorld.Services
{
    public static class MovieDataService
    {
        private static HttpService HttpService { get; set; } = new HttpService();

        public static ObservableCollection<Movie> TopMoviesList { get; private set; } = new ObservableCollection<Movie>();
        public static Movie CurrentMovie { get; private set; }

        //Top filmek letöltése a szerverről
        internal static async Task GetTopMoviesAsync()
        {
            if (TopMoviesList.Count == 0)
            {
                var list = await HttpService.ListTopMoviesAsync();
                TopMoviesList.Clear();

                foreach (var movie in list)
                {
                    TopMoviesList.Add(movie);
                }
            }
        }

        //Egy film részletes adatainak letöltése
        internal static async Task GetMovieDataAsync(int id)
        {
            var movie = await HttpService.GetMovieAsync(id);
            movie.Cast = await HttpService.GetCastAsync(id);
            CurrentMovie = movie;
        }
    }
}
