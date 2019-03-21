using MovieWorld.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MovieWorld.Views
{
    public sealed partial class PopularActorsPage : Page
    {
        private PopularActorsViewModel ViewModel
        {
            get { return ViewModelLocator.Current.PopularActorsViewModel; }
        }

        public PopularActorsPage()
        {
            InitializeComponent();         
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.LoadDataAsync();
        }
    }
}
