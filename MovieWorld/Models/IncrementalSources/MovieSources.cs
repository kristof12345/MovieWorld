using Microsoft.Toolkit.Collections;
using MovieWorld.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieWorld.Models.IncrementalSources
{
    public class MovieSourceByGenre : IIncrementalSource<Movie>
    {
        private readonly Genre genre;

        public MovieSourceByGenre(Genre g) { genre = g; }

        public async Task<IEnumerable<Movie>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken t)
        {
            return await MovieDataService.GetMoviesByGenreAsync(genre, pageIndex + 1);
        }
    }
}
