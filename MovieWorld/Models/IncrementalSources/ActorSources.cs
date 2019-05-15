using Microsoft.Toolkit.Collections;
using MovieWorld.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieWorld.Models.IncrementalSources
{
    public class ActorSourceBySearch : IIncrementalSource<Actor>
    {
        private readonly string searchParams;

        public ActorSourceBySearch(string param) { searchParams = param; }

        //Színészek betöltése oldalanként, aszinkron módon
        public async Task<IEnumerable<Actor>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken t)
        {
            return await ActorDataService.SearchAsync(searchParams, pageIndex + 1);
        }
    }

    public class ActorSourceBypopular : IIncrementalSource<Actor>
    {
        //A népszerű színészek betöltése oldalanként, aszinkron módon
        public async Task<IEnumerable<Actor>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken t)
        {
            return await ActorDataService.GetPopularActorsAsync(pageIndex);
        }
    }
}
