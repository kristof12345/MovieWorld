using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MovieWorld.Models;
using MovieWorld.Services;

namespace MovieWorld.ViewModels
{
    public class TvShowDetailViewModel : ViewModelBase
    {
        private TvShow show;

        public RelayCommand<int> SelectSeasonCommand { get; private set; }
        public RelayCommand<int> SelectShowCommand { get; private set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public TvShow TvShow{get { return show; }set { Set(ref show, value); }}

        public TvShowDetailViewModel()
        {
            SelectSeasonCommand = new RelayCommand<int>((int id) => { NavigateToSeason(id); });
            SelectShowCommand = new RelayCommand<int>((int id) => { NavigateToShow(id); });
        }

        public async Task Initialize(int id)
        {
            await TvShowDataService.GetShowDataAsync(id);
            TvShow = TvShowDataService.CurrentShow;
        }

        private void NavigateToSeason(int id)
        {
            var param = new SeasonId { ShowId = show.Id, SeasonNumber = id };
            NavigationService.Navigate(typeof(SeasonDetailViewModel).FullName, param);
        }

        private void NavigateToShow(int id)
        {
            NavigationService.Navigate(typeof(TvShowDetailViewModel).FullName, id);
        }
    }
}
