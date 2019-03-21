using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MovieWorld.Models;
using MovieWorld.Services;

namespace MovieWorld.ViewModels
{
    public class MovieDetailViewModel : ViewModelBase
    {
        private Movie movie;

        public RelayCommand<int> SelectActorCommand { get; private set; }
        public RelayCommand<int> SelectMovieCommand { get; private set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public Movie Movie{get { return movie; }set { Set(ref movie, value); }}

        public MovieDetailViewModel()
        {
            SelectActorCommand = new RelayCommand<int>((int id) => { NavigateToActor(id); });
            SelectMovieCommand = new RelayCommand<int>((int id) => { NavigateToMovie(id); });
        }

        public async Task Initialize(int id)
        {
            await MovieDataService.GetMovieDataAsync(id);
            Movie = MovieDataService.CurrentMovie;
        }

        private void NavigateToActor(int id)
        {
            NavigationService.Navigate(typeof(ActorDetailViewModel).FullName, id);
        }

        private void NavigateToMovie(int id)
        {
            NavigationService.Navigate(typeof(MovieDetailViewModel).FullName, id);
        }
    }
}
