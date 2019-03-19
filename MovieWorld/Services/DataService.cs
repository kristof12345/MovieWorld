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

        public static ObservableCollection<Movie> FavouriteMovies { get; set; } = new ObservableCollection<Movie>();

        //Filmek letöltése a szerverről
        public static async Task<IEnumerable<Movie>> GetMovieListAsync()
        {
            return await HttpService.ListTopMoviesAsync();
        }

        //Egy film részletes adatai
        internal static async Task<Movie> GetMovieAsync(Movie movie)
        {
            return await HttpService.GetMovieAsync(movie.Id);
        }

        //A stáb első 12 tagja
        internal static async Task<List<Actor>> GetCastAsync(Movie movie)
        {
            var data = await HttpService.GetCastAsync(movie.Id);
            return data.Take(12).ToList();
        }

        //Egy személy részletei
        internal static async Task<Actor> GetActorAsync(int id)
        {
            return await HttpService.GetActorAsync(id);
        }
    }
}
