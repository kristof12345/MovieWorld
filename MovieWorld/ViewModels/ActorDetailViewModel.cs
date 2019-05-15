using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MovieWorld.Models;
using MovieWorld.Services;

namespace MovieWorld.ViewModels
{
    public class ActorDetailViewModel : ViewModelBase
    {
        private Actor actor;

        public RelayCommand<int> SelectMovieCommand { get; set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public Actor Actor
        {
            get { return actor; }
            set { Set(ref actor, value); }
        }

        public ActorDetailViewModel()
        {
            //Command beállítása a navigáló függvényhez
            SelectMovieCommand = new RelayCommand<int>((int id) =>
            {
                NavigateToMovie(id);
            });
        }

        public async Task Initialize(int id)
        {
            await ActorDataService.GetActorDataAsync(id);
            Actor = ActorDataService.CurrentActor;
        }

        //Navigálás a kiválasztott filmhez
        public void NavigateToMovie(int id)
        {
            NavigationService.Navigate(typeof(MovieDetailViewModel).FullName, id);
        }
    }
}
