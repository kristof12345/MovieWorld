using MovieWorld.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MovieWorld.Views
{
    public sealed partial class NewReleasesPage : Page
    {
        public NewReleasesPage()
        {
            InitializeComponent();
        }

        private NewReleasesViewModel ViewModel
        {
            get { return ViewModelLocator.Current.WhatsNewViewModel; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.LoadData();
        }
    }
}
