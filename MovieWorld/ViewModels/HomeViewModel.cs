using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Collections;
using Microsoft.Toolkit.Uwp;
using Microsoft.Toolkit.Uwp.UI.Animations;
using MovieWorld.Models;
using MovieWorld.Models.IncrementalSources;
using MovieWorld.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand<Movie> MovieClickCommand { get; private set; }
        public RelayCommand<TvShow> TvShowClickCommand { get; private set; }
        public RelayCommand<Genre> GenreClickCommand { get; private set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public string SearchText { get; set; } = "";

        public ObservableCollection<Genre> Genres { get { return MovieDataService.Genres; } }
        public IncrementalLoadingCollection<IIncrementalSource<Movie>, Movie> MovieSource;
        public IncrementalLoadingCollection<IIncrementalSource<TvShow>, TvShow> TvShowSource;

        //Megadják, hogy éppen a filmek vagy a sorozatok látszanak:
        public bool MovieGridVisibility { get; set; }
        public bool ShowGridVisibility { get { return !MovieGridVisibility; } }

        public HomeViewModel()
        {
            //Commandok inicializálása
            SearchCommand = new RelayCommand(() => { OnSearch(); });
            MovieClickCommand = new RelayCommand<Movie>((Movie selected) => { OnMovieClick(selected); });
            TvShowClickCommand = new RelayCommand<TvShow>((TvShow selected) => { OnTvShowClick(selected); });
            GenreClickCommand = new RelayCommand<Genre>((Genre selected) => { OnGenreClick(selected); });
        }

        internal async Task LoadDataAsync()
        {
            await MovieDataService.GetGenresAsync();
        }

        //Keresésnél a fimek és sorozatok listáját is letöltjük
        private void OnSearch()
        {
            MovieSource = new IncrementalLoadingCollection<IIncrementalSource<Movie>, Movie>(new MovieSourceBySearch(SearchText));
            RaisePropertyChanged("MovieSource");

            TvShowSource = new IncrementalLoadingCollection<IIncrementalSource<TvShow>, TvShow>(new TvShowSourceBySearch(SearchText));
            RaisePropertyChanged("TvShowSource");
        }

        //Váltás a film és sorozat nézet között
        public void HandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            MovieGridVisibility = (radioButton.Name == "movie");

            RaisePropertyChanged("MovieGridVisibility");
            RaisePropertyChanged("ShowGridVisibility");
            if (SearchText != "") { OnSearch(); }
        }

        //Műfaj kiválasztása
        private void OnGenreClick(Genre clickedItem)
        {
            if (clickedItem != null)
            {
                //Új keresést indít
                SearchText = "";
                RaisePropertyChanged("SearchText");

                MovieSource = new IncrementalLoadingCollection<IIncrementalSource<Movie>, Movie>(new MovieSourceByGenre(clickedItem));
                RaisePropertyChanged("MovieSource");

                TvShowSource = new IncrementalLoadingCollection<IIncrementalSource<TvShow>, TvShow>(new TvShowSourceByGenre(clickedItem));
                RaisePropertyChanged("TvShowSource");
            }
        }

        //Film kiválasztása
        private void OnMovieClick(Movie clickedItem)
        {
            if (clickedItem != null)
            {
                //Navigálás a kiválasztott filmhez
                NavigationService.Frame.SetListDataItemForNextConnectedAnnimation(clickedItem);
                NavigationService.Navigate(typeof(MovieDetailViewModel).FullName, clickedItem.Id);
            }
        }

        //Sorozat kiválasztása
        private void OnTvShowClick(TvShow clickedItem)
        {
            if (clickedItem != null)
            {
                //Navigálás a kiválasztott sorozathoz
                NavigationService.Frame.SetListDataItemForNextConnectedAnnimation(clickedItem);
                NavigationService.Navigate(typeof(TvShowDetailViewModel).FullName, clickedItem.Id);
            }
        }
    }
}
