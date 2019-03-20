using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MovieWorld.Models;
using MovieWorld.Services;

namespace MovieWorld.ViewModels
{
    public class MovieDetailViewModel : ViewModelBase
    {
        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set { Set(ref movie, value); }
        }

        public MovieDetailViewModel()
        {
        }

        public async Task Initialize(int id)
        {
            Movie = await MovieDataService.GetMovieDataAsync(id);
        }
    }
}
