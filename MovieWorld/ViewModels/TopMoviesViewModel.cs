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
    public class TopMoviesViewModel : ViewModelBase
    {
        private Movie selected;

        public RelayCommand<int> SelectActorCommand { get; private set; }
        public RelayCommand<int> SelectMovieCommand { get; private set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;
        public SelectionChangedEventHandler SelectionChanged;

        public Movie Selected { get { return selected; } set { Set(ref selected, value); } }
        public ObservableCollection<Movie> Movies { get { return MovieDataService.TopMoviesList; } }

        public TopMoviesViewModel()
        {
            //Eseménykezelő a kiválasztásról való értesüléshez
            SelectionChanged += SelectedMovieChanged;
            SelectActorCommand = new RelayCommand<int>((int id) => {NavigateToActor(id);});
            SelectMovieCommand = new RelayCommand<int>((int id) =>{NavigateToMovie(id);});
        }

        //Ha változott a kijelölt film, akkor letölti a részleteit
        private async void SelectedMovieChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (Movie)e.AddedItems.First();
            if (selected != null && selected.Cast.Count == 0)
            {
                await MovieDataService.GetMovieDataAsync(selected.Id);
                Selected = MovieDataService.CurrentMovie;
            }
        }

        //Kezdetben az első film van kiválasztva
        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            //Betölti a TOP filmeket
            await MovieDataService.GetTopMoviesAsync();

            //Kiválasztja az elsőt
            if (viewState == MasterDetailsViewState.Both && Movies.Count > 0)
            {
                await MovieDataService.GetMovieDataAsync(Movies.First().Id);
                Selected = MovieDataService.CurrentMovie;
            }
        }

        //Navigálás a kiválasztott színészhez
        private void NavigateToActor(int id)
        {
            NavigationService.Navigate(typeof(ActorDetailViewModel).FullName, id);
        }

        //NAvigálás a kiválasztott filmhez
        private void NavigateToMovie(int id)
        {
            NavigationService.Navigate(typeof(MovieDetailViewModel).FullName, id);
        }
    }
}
