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
        internal static async Task<List<TvShow>> GetLatestShowsAsync(int pageIndex)
        {
            return await HttpService.ListLatestShowsAsync(pageIndex);
        }

        //Egy sorozat adatainak letöltése
        internal static async Task GetShowDataAsync(int id)
        {
            var show = await HttpService.GetShowAsync(id);
            var similar = await HttpService.GetSimilarShowsAsync(id);
            show.SimilarSeries = similar;
            CurrentShow = show;
        }

        //Egy évad letöltése
        internal static async Task GetSeasonAsync(int showId, int seasonNumber)
        {
            var season = await HttpService.GetSeasonAsync(showId, seasonNumber);
            var cast = await HttpService.GetSeasonCastAsync(showId, seasonNumber);
            //Csak a fontosabb szereplők
            season.Cast = cast.Where(a => a.Profile_path != null).Take(18).ToList();
            CurrentSeason = season;
        }

        //Sorozatok keresése
        internal static Task<List<TvShow>> SearchShowsAsync(string searchParams, int pageIndex)
        {
            return HttpService.SearchShowsAsync(searchParams, pageIndex);
        }

        //Sorozatok műfaj alapján
        internal static Task<List<TvShow>> GetShowsByGenreAsync(Genre genre, int pageIndex)
        {
            return HttpService.GetTvShowsByGenresAsync(genre.Id, pageIndex);
        }
    }
}
