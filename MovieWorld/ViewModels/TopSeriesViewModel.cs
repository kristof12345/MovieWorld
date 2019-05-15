using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.UI.Controls;
using MovieWorld.Models;
using MovieWorld.Services;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.ViewModels
{
    public class TopSeriesViewModel : ViewModelBase
    {
        private TvShow selected;

        public RelayCommand<int> SelectSeasonCommand { get; private set; }
        public RelayCommand<int> SelectShowCommand { get; private set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;
        public SelectionChangedEventHandler SelectionChanged;

        public TvShow Selected { get { return selected; } set { Set(ref selected, value); } }
        public ObservableCollection<TvShow> Shows { get { return TvShowDataService.TopTvShowsList; } }

        public TopSeriesViewModel()
        {
            //Eseménykezelő a kiválasztásról való értesüléshez
            SelectionChanged += this.SelectedShowChanged;
            SelectSeasonCommand = new RelayCommand<int>((int id) =>{NavigateToSeason(id);});
            SelectShowCommand = new RelayCommand<int>((int id) => { NavigateToShow(id); });
        }

        //Ha változott a kijelölt sorozat, akkor letölti a részleteit
        public async void SelectedShowChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (TvShow)e.AddedItems.First();
            if (selected != null && selected.Seasons.Count == 0)
            {
                await TvShowDataService.GetShowDataAsync(selected.Id);
                Selected = TvShowDataService.CurrentShow;
            }
        }

        //Kezdetben az első sorozat van kiválasztva
        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            //Betölti a TOP sorozatokat
            await TvShowDataService.GetTopShowsAsync();

            //Kiválasztja az elsőt
            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = Shows.First();
            }
        }

        //Navigálás a kiválasztott évadhoz
        private void NavigateToSeason(int id)
        {
            var param = new SeasonId { ShowId = selected.Id, SeasonNumber = id };
            NavigationService.Navigate(typeof(SeasonDetailViewModel).FullName, param);
        }

        //Navigálás a kiválasztott sorozathoz
        private void NavigateToShow(int id)
        {
            NavigationService.Navigate(typeof(TvShowDetailViewModel).FullName, id);
        }
    }
}
