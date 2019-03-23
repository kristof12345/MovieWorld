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

        public MovieSourceByGenre(Genre param) { genre = param; }

        public async Task<IEnumerable<Movie>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken t)
        {
            return await MovieDataService.GetMoviesByGenreAsync(genre, pageIndex + 1);
        }
    }

    public class MovieSourceBySearch : IIncrementalSource<Movie>
    {
        private readonly string searchParams;

        public MovieSourceBySearch(string param) { searchParams = param; }

        public async Task<IEnumerable<Movie>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken t)
        {
            return await MovieDataService.SearchMoviesAsync(searchParams, pageIndex + 1);
        }
    }

    public class MovieSourceByLatest : IIncrementalSource<Movie>
    {
        public async Task<IEnumerable<Movie>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken t)
        {
            return await MovieDataService.GetLatestMoviesAsync(pageIndex + 1);
        }
    }
}
