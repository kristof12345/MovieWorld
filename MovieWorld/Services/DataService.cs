﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MovieWorld.Models;
using System.Linq;

namespace MovieWorld.Services
{
    public static class DataService
    {
        public static ObservableCollection<Movie> MovieList { get; set; } = new ObservableCollection<Movie>();

        public static Movie DetailedMovie { get; set; }

        private static HttpService HttpService { get; set; } = new HttpService();

        //Filmek letöltése a szerverről
        public static async Task GetMovieListAsync()
        {
            if (MovieList.Count == 0)
            {
                var list = await HttpService.ListTopMoviesAsync();
                MovieList.Clear();

                foreach (var movie in list)
                {
                    var cast  = await HttpService.GetCastAsync(movie.Id);
                    movie.Cast = cast.Where(c => c.Profile_path !=null).Take(12).ToList();
                    var details = await HttpService.GetMovieAsync(movie.Id);
                    movie.Genres = details.Genres;
                    MovieList.Add(movie);
                }
            }
        }

        //Egy színész adatai
        internal static async Task<Actor> GetActorDataAsync(int id)
        {
            var actor = await HttpService.GetActorAsync(id);
            actor.Roles = await HttpService.GetMoviesForActorAsync(id);
            return actor;
        }

        //Egy film részletes adatai

        internal static async Task GetMovieAsync(Movie movie)
        {
            var detailedMovie = await HttpService.GetMovieAsync(movie.Id);
            movie.Cast = await HttpService.GetCastAsync(movie.Id);
        }
        

        //Egy személy részletei
        /*internal static async Task GetActorAsync(int id)
        {
            await HttpService.GetActorAsync(id);
        }*/
    }
}
