using MovieWorld.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.Services
{
    class ActorDataService
    {
        private static HttpService HttpService { get; set; } = new HttpService();

        public static ObservableCollection<Actor> ActorsList { get; private set; } = new ObservableCollection<Actor>();
        public static Actor CurrentActor { get; private set; }

        //Egy színész adatai
        internal static async Task GetActorDataAsync(int id)
        {
            var actor = await HttpService.GetActorAsync(id);
            var roles = await HttpService.GetMoviesForActorAsync(id);
            if (roles != null)
            {
                actor.Roles = roles.Where(c => c.Poster_path != null).ToList();
            }
            CurrentActor = actor;
        }

        //Népszerű színészek
        internal static async Task GetPopularActorsAsync()
        {
            var list = await HttpService.GetPopularActorsAsync();
            ActorsList.Clear();
            foreach(var actor in list)
            {
                ActorsList.Add(actor);
            }
        }

        internal static async Task Search(string searchText)
        {
            var list = await HttpService.SearchActorsAsync(searchText);
            ActorsList.Clear();
            foreach (var actor in list)
            {
                if(actor.Profile_path != null)
                ActorsList.Add(actor);
            }
        }
    }
}
