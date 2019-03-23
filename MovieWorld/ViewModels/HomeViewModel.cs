using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.UI.Animations;
using MovieWorld.Models;
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

        public ObservableCollection<Movie> SearchedMoviesSource { get; } = new ObservableCollection<Movie>();
        public ObservableCollection<TvShow> SearchedShowsSource { get; } = new ObservableCollection<TvShow>();
        public ObservableCollection<Genre> Genres { get { return MovieDataService.Genres; } }

        public bool MovieGridVisibility { get { return SearchCategory == "movie"; } }
        public bool ShowGridVisibility { get { return SearchCategory == "tv"; } }

        public HomeViewModel()
        {
            SearchCommand = new RelayCommand(() => { SearchAsync(); });
            MovieClickCommand = new RelayCommand<Movie>((Movie selected) => { OnMovieClick(selected); });
            TvShowClickCommand = new RelayCommand<TvShow>((TvShow selected) => { OnTvShowClick(selected); });
            GenreClickCommand = new RelayCommand<Genre>((Genre selected) => { OnGenreClickAsync(selected); });
        }

        internal async Task LoadDataAsync()
        {
            await MovieDataService.GetGenresAsync();
        }

        private async Task SearchAsync()
        {
            SearchedMoviesSource.Clear();
            SearchedShowsSource.Clear();

            if (SearchCategory == "movie")
            {
                var result = await MovieDataService.SearchMoviesAsync(SearchText);
                foreach (var movie in result) { SearchedMoviesSource.Add(movie); }
            }
            else
            {
                var result = await TvShowDataService.SearchShowsAsync(SearchText);
                foreach (var show in result) { SearchedShowsSource.Add(show); }
            }
        }

        public async void HandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            SearchCategory = radioButton.Name;
            RaisePropertyChanged("MovieGridVisibility");
            RaisePropertyChanged("ShowGridVisibility");
            if (SearchText != "") { await SearchAsync(); }
        }

        private async Task OnGenreClickAsync(Genre clickedItem)
        {
            if (clickedItem != null)
            {
                SearchText = "";
                RaisePropertyChanged("SearchText");
                SearchedMoviesSource.Clear();
                SearchedShowsSource.Clear();

                var result1 = await MovieDataService.GetMoviesByGenreAsync(clickedItem);
                foreach (var movie in result1) { SearchedMoviesSource.Add(movie); }

                var result2 = await TvShowDataService.GetShowsByGenreAsync(clickedItem);
                foreach (var show in result2) { SearchedShowsSource.Add(show); }
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
