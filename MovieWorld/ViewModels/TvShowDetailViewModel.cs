using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MovieWorld.Models;
using MovieWorld.Services;

namespace MovieWorld.ViewModels
{
    public class TvShowDetailViewModel : ViewModelBase
    {
        private TvShow show;

        public TvShow TvShow
        {
            get { return show; }
            set { Set(ref show, value); }
        }

        public TvShowDetailViewModel()
        {
        }

        public async Task Initialize(int id)
        {
            await TvShowDataService.GetShowAsync(id);
            TvShow = TvShowDataService.CurrentShow;
        }
    }
}
