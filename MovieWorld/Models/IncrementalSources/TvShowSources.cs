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

        public TvShowSourceByGenre(Genre g) { genre = g; }

        public async Task<IEnumerable<TvShow>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken t)
        {
            return await TvShowDataService.GetShowsByGenreAsync(genre, pageIndex + 1);
        }
    }
}
