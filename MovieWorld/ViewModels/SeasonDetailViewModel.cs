using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MovieWorld.Models;
using MovieWorld.Services;

namespace MovieWorld.ViewModels
{
    public class SeasonDetailViewModel : ViewModelBase
    {
        private Season season;

        public RelayCommand<int> SelectActorCommand { get; set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public Season Season{get { return season; }set { Set(ref season, value); }}

        public SeasonDetailViewModel()
        {
            SelectActorCommand = new RelayCommand<int>((int id) =>{NavigateToActor(id); });
        }

        public async Task Initialize(int showId, int seasonNumber)
        {
            await TvShowDataService.GetSeasonAsync(showId, seasonNumber);
            Season = TvShowDataService.CurrentSeason;
        }

        public void NavigateToActor(int id)
        {
            NavigationService.Navigate(typeof(ActorDetailViewModel).FullName, id);
        }
    }
}
