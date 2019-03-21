using System;
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

        public RelayCommand<int> SelectActorCommand { get; set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public Movie Selected{
            get { return selected; }
            set { Set(ref selected, value); } }
        public ObservableCollection<Movie> Movies { get { return MovieDataService.TopMoviesList; } }

        public TopMoviesViewModel()
        {
            MovieSelected += this.MovieChanged;
            SelectActorCommand = new RelayCommand<int>((int id) =>
            {
                NavigateToActor(id);
            });
        }

        public async void MovieChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (Movie)e.AddedItems.First();
            if (selected != null && selected.Cast.Count == 0)
            {
                await MovieDataService.GetMovieDataAsync(selected.Id);
                Selected = MovieDataService.CurrentMovie;
            }
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            await MovieDataService.GetTopMoviesAsync();

            if (viewState == MasterDetailsViewState.Both && Movies.Count > 0)
            {
                await MovieDataService.GetMovieDataAsync(Movies.First().Id);
                Selected = MovieDataService.CurrentMovie;
            }
        }
        public SelectionChangedEventHandler MovieSelected;

        public void NavigateToActor(int id)
        {
            NavigationService.Navigate(typeof(ActorDetailViewModel).FullName, id);
        }
    }
}
