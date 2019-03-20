using MovieWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.Services
{
    class ActorDataService
    {
        private static HttpService HttpService { get; set; } = new HttpService();

        //Egy színész adatai
        internal static async Task<Actor> GetActorDataAsync(int id)
        {
            var actor = await HttpService.GetActorAsync(id);
            var roles = await HttpService.GetMoviesForActorAsync(id);
            if (roles != null)
            {
                actor.Roles = roles.Where(c => c.Poster_path != null).ToList();
            }
            return actor;
        }
    }
}
