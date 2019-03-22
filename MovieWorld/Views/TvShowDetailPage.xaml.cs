using MovieWorld.Services;
using MovieWorld.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MovieWorld.Views
{
    public sealed partial class TvShowDetailPage : Page
    {
        public TvShowDetailViewModel ViewModel
        {
            get { return ViewModelLocator.Current.TvShowDetailViewModel; }
        }

        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public TvShowDetailPage()
        {
            InitializeComponent();
            
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is int showId)
            {
                await ViewModel.Initialize(showId);
            }
        }
    }
}
