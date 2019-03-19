using System;

using MovieWorld.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MovieWorld.Views
{
    public sealed partial class TopSeriesPage : Page
    {
        private TopSeriesViewModel ViewModel
        {
            get { return ViewModelLocator.Current.TopSeriesViewModel; }
        }

        public TopSeriesPage()
        {
            InitializeComponent();
            Loaded += TopSeriesPage_Loaded;
        }

        private async void TopSeriesPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // Workaround for issue on MasterDetail Control. Find More info at https://github.com/Microsoft/WindowsTemplateStudio/issues/2738
            ViewModel.Selected = null;
        }
    }
}
