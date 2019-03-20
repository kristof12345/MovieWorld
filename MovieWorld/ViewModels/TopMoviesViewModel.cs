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
    public class TopMoviesViewModel : ViewModelBase
    {
        private Movie selected;

        public RelayCommand<int> SelectActorCommand { get; set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public Movie Selected{get { return selected; }set { Set(ref selected, value); } }
        public ObservableCollection<Movie> Movies { get { return MovieDataService.TopMoviesList; } }

        public TopMoviesViewModel()
        {
            SelectActorCommand = new RelayCommand<int>((int id) =>
            {
                NavigateToActor(id);
            });
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            await MovieDataService.GetTopMoviesAsync();

            if (viewState == MasterDetailsViewState.Both && Movies.Count > 0)
            {
                Selected = Movies.First();
            }
        }

        public void NavigateToActor(int id)
        {
            var t = typeof(HomePage);
            var n = t.FullName;
            NavigationService.Navigate(typeof(PopularActorsDetailViewModel).FullName, id);
        }
    }
}
