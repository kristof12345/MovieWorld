using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MovieWorld.Models;
using MovieWorld.Services;

namespace MovieWorld.ViewModels
{
    public class ActorDetailViewModel : ViewModelBase
    {
        public RelayCommand<int> SelectMovieCommand { get; set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        private Actor actor;

        public Actor Actor
        {
            get { return actor; }
            set { Set(ref actor, value); }
        }

        public ActorDetailViewModel()
        {
            SelectMovieCommand = new RelayCommand<int>((int id) =>
            {
                NavigateToMovie(id);
            });
        }

        public async Task Initialize(int id)
        {
            Actor = await ActorDataService.GetActorDataAsync(id);
        }

        public void NavigateToMovie(int id)
        {
            NavigationService.Navigate(typeof(MovieDetailViewModel).FullName, id);
        }
    }
}
