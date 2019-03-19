using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.UI.Controls;
using MovieWorld.Models;
using MovieWorld.Services;

namespace MovieWorld.ViewModels
{
    public class TopMoviesViewModel : ViewModelBase
    {
        private Movie selected;
        public ICommand SelectActorCommand { get; set; }

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
            SelectActorCommand = new RelayCommand(() =>
            {
                System.Diagnostics.Debug.WriteLine("EditCommand");
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
