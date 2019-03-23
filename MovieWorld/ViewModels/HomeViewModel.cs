using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        public string SearchCategory { get; set; } = "movie";

        public ObservableCollection<Genre> Genres { get { return MovieDataService.Genres; } }
        public IncrementalLoadingCollection<MovieSourceByGenre, Movie> MovieSource;
        public IncrementalLoadingCollection<TvShowSourceByGenre, TvShow> TvShowSource;

        public bool MovieGridVisibility { get { return SearchCategory == "movie"; } }
        public bool ShowGridVisibility { get { return SearchCategory == "tv"; } }

        public HomeViewModel()
        {
            SearchCommand = new RelayCommand(() => { OnSearch(); });
            MovieClickCommand = new RelayCommand<Movie>((Movie selected) => { OnMovieClick(selected); });
            TvShowClickCommand = new RelayCommand<TvShow>((TvShow selected) => { OnTvShowClick(selected); });
            GenreClickCommand = new RelayCommand<Genre>((Genre selected) => { OnGenreClick(selected); });
        }

        internal async Task LoadDataAsync()
        {
            await MovieDataService.GetGenresAsync();
        }

        private void OnSearch()
        {
            /*
            if (SearchCategory == "movie")
            {
                var result = await MovieDataService.SearchMoviesAsync(SearchText);
                foreach (var movie in result) { SearchedMoviesSource.Add(movie); }
            }
            else
            {
                var result = await TvShowDataService.SearchShowsAsync(SearchText);
                foreach (var show in result) { SearchedShowsSource.Add(show); }
            }*/
        }

        public void HandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            SearchCategory = radioButton.Name;
            RaisePropertyChanged("MovieGridVisibility");
            RaisePropertyChanged("ShowGridVisibility");
            if (SearchText != "") { OnSearch(); }
        }

        private void OnGenreClick(Genre clickedItem)
        {
            if (clickedItem != null)
            {
                SearchText = "";
                RaisePropertyChanged("SearchText");

                MovieSource = new IncrementalLoadingCollection<MovieSourceByGenre, Movie>(new MovieSourceByGenre(clickedItem));
                RaisePropertyChanged("MovieSource");

                TvShowSource = new IncrementalLoadingCollection<TvShowSourceByGenre, TvShow>(new TvShowSourceByGenre(clickedItem));
                RaisePropertyChanged("TvShowSource");
            }
        }

        private void OnMovieClick(Movie clickedItem)
        {
            if (clickedItem != null)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnnimation(clickedItem);
                NavigationService.Navigate(typeof(MovieDetailViewModel).FullName, clickedItem.Id);
            }
        }

        private void OnTvShowClick(TvShow clickedItem)
        {
            if (clickedItem != null)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnnimation(clickedItem);
                NavigationService.Navigate(typeof(TvShowDetailViewModel).FullName, clickedItem.Id);
            }
        }
    }
}
