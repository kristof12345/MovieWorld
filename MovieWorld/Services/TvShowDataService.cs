using MovieWorld.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWorld.Services
{
    public static class TvShowDataService
    {
        private static HttpService HttpService { get; set; } = new HttpService();

        public static ObservableCollection<TvShow> TopTvShowsList { get; private set; } = new ObservableCollection<TvShow>();
        public static Season CurrentSeason { get; private set; }
        public static TvShow CurrentShow { get; private set; }
        public static ObservableCollection<TvShow> LatestTvShowsList { get; private set; } = new ObservableCollection<TvShow>();
        public static ObservableCollection<Genre> Genres = new ObservableCollection<Genre>();

        //Top sorozatok letöltése a szerverről
        internal static async Task GetTopShowsAsync()
        {
            if (TopTvShowsList.Count == 0)
            {
                var list = await HttpService.ListTopShowsAsync();
                TopTvShowsList.Clear();

                foreach (var show in list)
                {
                    TopTvShowsList.Add(show);
                }
            }
        }

        //A legújabb sorozatok letöltése a szerverről
        internal static async Task GetLatestShowsAsync()
        {
            if (LatestTvShowsList.Count == 0)
            {
                var list = await HttpService.ListLatestShowsAsync();
                LatestTvShowsList.Clear();

                foreach (var show in list)
                {
                    LatestTvShowsList.Add(show);
                }
            }
        }

        //Egy sorozat adatainak letöltése
        internal static async Task GetShowDataAsync(int id)
        {
            var show = await HttpService.GetShowAsync(id);
            var similar = await HttpService.GetSimilarShowsAsync(id);
            show.SimilarSeries = similar;
            CurrentShow = show;
        }

        internal static async Task GetSeasonAsync(int showId, int seasonNumber)
        {
            var season = await HttpService.GetSeasonAsync(showId, seasonNumber);
            var cast = await HttpService.GetSeasonCastAsync(showId, seasonNumber);
            //Csak a fontosabb szereplők
            season.Cast = cast.Where(a => a.Profile_path != null).Take(18).ToList();
            CurrentSeason = season;
        }

        internal static Task<List<TvShow>> SearchShowsAsync(string searchParams)
        {
            return HttpService.SearchShowsAsync(searchParams);
        }

        internal static async Task GetGenresAsync()
        {
            Genres.Clear();
            var genres = await HttpService.GetGenresAsync();
            foreach (var g in genres) Genres.Add(g);
        }

        internal static Task<List<TvShow>> GetShowsByGenreAsync(Genre genre)
        {
            return HttpService.GetTvShowsByGenresAsync(genre.Id);
        }
    }
}
