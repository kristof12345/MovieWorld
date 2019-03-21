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

        public RelayCommand<int> SelectSeasonCommand { get; set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;
        public SelectionChangedEventHandler SelectionChanged;

        public TvShow Selected { get { return selected; } set { Set(ref selected, value); } }
        public ObservableCollection<TvShow> Shows { get { return TvShowDataService.TopTvShowsList; } }

        public TopSeriesViewModel()
        {
            SelectionChanged += this.SelectedShowChanged;
            SelectSeasonCommand = new RelayCommand<int>((int id) =>
            {
                NavigateToSeason(id);
            });
        }

        public async void SelectedShowChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (TvShow)e.AddedItems.First();
            if (selected != null && selected.Seasons.Count == 0)
            {
                await TvShowDataService.GetShowDataAsync(selected.Id);
                Selected = TvShowDataService.CurrentShow;
            }
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
            var param = new SeasonId { ShowId = selected.Id, SeasonNumber = id };
            NavigationService.Navigate(typeof(SeasonDetailViewModel).FullName, param);
        }
    }
}
