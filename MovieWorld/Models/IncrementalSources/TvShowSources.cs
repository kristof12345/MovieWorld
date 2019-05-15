using Microsoft.Toolkit.Collections;
using MovieWorld.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieWorld.Models.IncrementalSources
{
    public class TvShowSourceByGenre : IIncrementalSource<TvShow>
    {
        private readonly Genre genre;

        public TvShowSourceByGenre(Genre param) { genre = param; }

        //Adott műfajú sorozatok betöltése oldalanként, aszinkron módon
        public async Task<IEnumerable<TvShow>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken t)
        {
            return await TvShowDataService.GetShowsByGenreAsync(genre, pageIndex + 1);
        }
    }

    public class TvShowSourceBySearch : IIncrementalSource<TvShow>
    {
        private readonly string searchParam;

        public TvShowSourceBySearch(string param) { searchParam = param; }

        //A keresett kifejezésnek megfelelő sorozatok betöltése oldalanként, aszinkron módon
        public async Task<IEnumerable<TvShow>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken t)
        {
            return await TvShowDataService.SearchShowsAsync(searchParam, pageIndex + 1);
        }
    }

    public class TvShowSourceByLatest : IIncrementalSource<TvShow>
    {
        public async Task<IEnumerable<TvShow>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken t)
        {
            return await TvShowDataService.GetLatestShowsAsync(pageIndex + 1);
        }
    }
}
