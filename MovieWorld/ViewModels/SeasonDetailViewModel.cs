using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MovieWorld.Models;
using MovieWorld.Services;

namespace MovieWorld.ViewModels
{
    public class SeasonDetailViewModel : ViewModelBase
    {
        private Season season;

        public Season Season
        {
            get { return season; }
            set { Set(ref season, value); }
        }

        public SeasonDetailViewModel()
        {
        }

        public async Task Initialize(int id)
        {
            await TvShowDataService.GetSeasonAsync(id);
            Season = TvShowDataService.CurrentSeason;
        }
    }
}
