using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.UI.Controls;
using MovieWorld.Models;
using MovieWorld.Services;
using MovieWorld.Views;

namespace MovieWorld.ViewModels
{
    public class TopSeriesViewModel : ViewModelBase
    {
        private TvShow selected;

        public RelayCommand<int> SelectSeasonCommand { get; set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public TvShow Selected{ get { return selected; }set { Set(ref selected, value); } }
        public ObservableCollection<TvShow> Shows { get { return TvShowDataService.TopTvShowsList; } }

        public TopSeriesViewModel()
        {
            SelectSeasonCommand = new RelayCommand<int>((int id) =>
            {
                NavigateToSeason(id);
            });
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            await TvShowDataService.GetTopShowsAsync();

            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = Shows.First();
            }
        }

        public void NavigateToSeason(int id)
        {
            NavigationService.Navigate(typeof(ActorDetailViewModel).FullName, id);
        }
    }
}
