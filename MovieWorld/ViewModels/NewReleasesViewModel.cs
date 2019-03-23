using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Collections;
using Microsoft.Toolkit.Uwp;
using Microsoft.Toolkit.Uwp.UI.Animations;
using MovieWorld.Models;
using MovieWorld.Models.IncrementalSources;
using MovieWorld.Services;
using System.Threading.Tasks;

namespace MovieWorld.ViewModels
{
    public class NewReleasesViewModel : ViewModelBase
    {
        public RelayCommand<Movie> MovieClickCommand { get; private set; }
        public RelayCommand<TvShow> TvShowClickCommand { get; private set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public IncrementalLoadingCollection<IIncrementalSource<Movie>, Movie> LatestMovieSource;
        public IncrementalLoadingCollection<IIncrementalSource<TvShow>, TvShow> LatestShowsSource;


        public NewReleasesViewModel()
        {
            MovieClickCommand = new RelayCommand<Movie>((Movie selected) => { OnMovieClick(selected); });
            TvShowClickCommand = new RelayCommand<TvShow>((TvShow selected) => { OnTvShowClick(selected); });
        }

        internal void LoadData()
        {
            LatestMovieSource = new IncrementalLoadingCollection<IIncrementalSource<Movie>, Movie>(new MovieSourceByLatest());
            RaisePropertyChanged("MovieSource");

            LatestShowsSource = new IncrementalLoadingCollection<IIncrementalSource<TvShow>, TvShow>(new TvShowSourceByLatest());
            RaisePropertyChanged("TvShowSource");
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
