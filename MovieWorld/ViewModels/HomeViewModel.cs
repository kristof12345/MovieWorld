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
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public string SearchText { get; set; }
        public string SearchCategory { get; set; } = "movie";
        public ObservableCollection<Movie> SearchedMoviesSource { get; } = new ObservableCollection<Movie>();
        public ObservableCollection<TvShow> SearchedShowsSource { get; } = new ObservableCollection<TvShow>();

        public ObservableCollection<Movie> LatestMovieSource { get { return MovieDataService.LatestMoviesList; } }
        public ObservableCollection<TvShow> LatestShowsSource { get { return TvShowDataService.LatestTvShowsList; } }

        public bool MovieGridVisibility { get{return SearchCategory=="movie";}}
        public bool ShowGridVisibility { get { return SearchCategory == "tv"; } }

        public HomeViewModel()
        {
            SearchCommand = new RelayCommand(() =>{SearchAsync();});
            MovieClickCommand = new RelayCommand<Movie>((Movie selected) => { OnMovieClick(selected); });
            TvShowClickCommand = new RelayCommand<TvShow>((TvShow selected) => { OnTvShowClick(selected); });
        }

        private async void SearchAsync()
        {
            if (SearchCategory == "movie")
            {
                var result = await MovieDataService.SearchMoviesAsync(SearchText);
                foreach(var movie in result) { SearchedMoviesSource.Add(movie); }
            }
            else
            {
                var result = await TvShowDataService.SearchShowsAsync(SearchText);
                foreach (var show in result) { SearchedShowsSource.Add(show); }
            }
        }

        public void HandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            SearchCategory = radioButton.Name;
            RaisePropertyChanged("MovieGridVisibility");
            RaisePropertyChanged("ShowGridVisibility");
        }

        internal async Task LoadDataAsync()
        {
            await MovieDataService.GetLatestMoviesAsync();
            await TvShowDataService.GetLatestShowsAsync();
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
