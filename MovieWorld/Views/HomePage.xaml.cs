using Microsoft.Toolkit.Uwp;
using MovieWorld.Models;
using MovieWorld.Models.IncrementalSources;
using MovieWorld.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MovieWorld.Views
{
    public sealed partial class HomePage : Page
    {
        private HomeViewModel ViewModel
        {
            get { return ViewModelLocator.Current.HomeViewModel; }
        }

        public HomePage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.LoadDataAsync();
            var collection = new IncrementalLoadingCollection<MovieSourceByGenre, Movie>(new MovieSourceByGenre(new Genre { Id = 12 }));
            //MovieGrid.ItemsSource = collection;
        }
    }
}
