using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MovieWorld.Models;

namespace MovieWorld.Services
{
    public static class MovieDataService
    {
        private static HttpService HttpService { get; set; } = new HttpService();

        public static ObservableCollection<Movie> TopMoviesList { get; private set; } = new ObservableCollection<Movie>();
        public static Movie CurrentMovie { get; private set; }
        public static ObservableCollection<Genre> Genres = new ObservableCollection<Genre>();

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

        //Legújabb filmek letöltése a szerverről
        internal static async Task<List<Movie>> GetLatestMoviesAsync(int pageIndex)
        {
            return await HttpService.ListLatestMoviesAsync(pageIndex);
        }

        //Egy film részletes adatainak letöltése
        internal static async Task GetMovieDataAsync(int id)
        {
            var movie = await HttpService.GetMovieAsync(id);
            var cast = await HttpService.GetCastAsync(id);
            var similar = await HttpService.GetSimilarMoviesAsync(id);
            //Csak a fontosabb szereplők
            movie.Cast = cast.Where(a => a.Profile_path != null).Take(18).ToList();
            //Csak az első 12 találat
            movie.SimilarMovies = similar.Take(12).ToList();
            CurrentMovie = movie;
        }

        //Filmek keresése
        internal static Task<List<Movie>> SearchMoviesAsync(string searchParams, int pageIndex)
        {
            return HttpService.SearchMoviesAsync(searchParams, pageIndex);
        }

        //Műfajok letöltése
        internal static async Task GetGenresAsync()
        {
            Genres.Clear();
            var genres = await HttpService.GetGenresAsync();
            foreach (var g in genres) Genres.Add(g);
        }

        //Filmek listázása műfaj alapján
        internal static Task<List<Movie>> GetMoviesByGenreAsync(Genre genre, int pageIndex)
        {
            return HttpService.GetMoviesByGenresAsync(genre.Id, pageIndex);
        }
    }
}
