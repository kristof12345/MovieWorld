using MovieWorld.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWorld.Services
{
    class ActorDataService
    {
        private static HttpService HttpService { get; set; } = new HttpService();
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
        internal static async Task<List<Actor>> GetPopularActorsAsync(int pageIndex)
        {
            var list = await HttpService.GetPopularActorsAsync(pageIndex);
            var actors = list.Where(a => a.Profile_path != null).ToList();
            return actors;
        }

        //Színészek keresése
        internal static async Task<List<Actor>> SearchAsync(string searchText, int pageIndex)
        {
            return await HttpService.SearchActorsAsync(searchText, pageIndex);
        }
    }
}
