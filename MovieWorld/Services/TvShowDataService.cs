using MovieWorld.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.Services
{
    public static class TvShowDataService
    {
        private static HttpService HttpService { get; set; } = new HttpService();

        public static ObservableCollection<TvShow> TopTvShowsList { get; set; } = new ObservableCollection<TvShow>();

        //Top sorozatok letöltése a szerverről
        internal static async Task GetTopShowsAsync()
        {
            if (TopTvShowsList.Count == 0)
            {
                var list = await HttpService.ListTopShowsAsync();
                TopTvShowsList.Clear();

                foreach (var show in list)
                {
                    var details = await HttpService.GetShowAsync(show.Id);
                    TopTvShowsList.Add(details);
                }
            }
        }
    }
}
