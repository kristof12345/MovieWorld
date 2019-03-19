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

        public Movie Selected
        {
            get { return selected; }
            //Módosul, ha null, ha a két ID nem egyezik vagy ha a részletek még nincsenek betöltve
            set { if (selected == null || selected.Id != value.Id || !selected.Detailed) { Set(ref selected, value); SelectedMovieChanged(); } }
        }

        public ObservableCollection<Movie> Movies { get; private set; }

        public TopMoviesViewModel()
        {
            Movies = DataService.MovieList;
            SelectActorCommand = new RelayCommand<int>((int id) =>
            {
                NavigateToActor(id);
            });
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            Movies.Clear();

            var data = await DataService.GetMovieListAsync();

            foreach (var item in data)
            {
                Movies.Add(item);
            }

            if (viewState == MasterDetailsViewState.Both && Movies.Count > 0)
            {
                Selected = Movies.First();
            }
        }

        public void NavigateToActor(int id)
        {
            var t = typeof(HomePage);
            var n = t.FullName;
            //NavigationService.Navigate(typeof(PopularActorsDetailViewModel).FullName, 3);
        }

        private async Task SelectedMovieChanged()
        {
            var movieDetails = await DataService.GetMovieAsync(Selected);
            movieDetails.Detailed = true;
            movieDetails.Cast = await DataService.GetCastAsync(Selected);
            Selected = movieDetails;
            //TODO
        }
    }
}
