using Microsoft.Toolkit.Uwp.UI.Animations;
using MovieWorld.Services;
using MovieWorld.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MovieWorld.Views
{
    public sealed partial class ActorDetailPage : Page
    {
        public ActorDetailViewModel ViewModel{get { return ViewModelLocator.Current.ActorDetailViewModel; }}

        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public ActorDetailPage()
        {
            InitializeComponent();
            
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is int orderId)
            {
                await ViewModel.Initialize(orderId);
                MovieList.ItemsSource = ViewModel.Actor.Roles;
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnnimation(ViewModel.Actor);
            }
        }
    }
}
