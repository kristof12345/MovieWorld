using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.UI.Animations;
using MovieWorld.Models;
using MovieWorld.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.ViewModels
{
    public class NewReleasesViewModel : ViewModelBase
    {
        public RelayCommand<Movie> MovieClickCommand { get; private set; }
        public RelayCommand<TvShow> TvShowClickCommand { get; private set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public ObservableCollection<Movie> LatestMovieSource { get { return MovieDataService.LatestMoviesList; } }
        public ObservableCollection<TvShow> LatestShowsSource { get { return TvShowDataService.LatestTvShowsList; } }


        public NewReleasesViewModel()
        {
            MovieClickCommand = new RelayCommand<Movie>((Movie selected) => { OnMovieClick(selected); });
            TvShowClickCommand = new RelayCommand<TvShow>((TvShow selected) => { OnTvShowClick(selected); });
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
