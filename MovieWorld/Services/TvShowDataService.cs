using MovieWorld.Models;
using System.Collections.ObjectModel;
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
            CurrentSeason = season;
        }
    }
}
