using MovieWorld.Services;
using MovieWorld.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MovieWorld.Views
{
    public sealed partial class MovieDetailPage : Page
    {
        public MovieDetailViewModel ViewModel
        {
            get { return ViewModelLocator.Current.MovieDetailViewModel; }
        }

        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public MovieDetailPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is int movieId)
            {
                await ViewModel.Initialize(movieId);
            }
        }
    }
}
