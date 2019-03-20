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
            //TODO
            //Season = await MovieDataService.GetMovieDataAsync(id);
        }
    }
}
