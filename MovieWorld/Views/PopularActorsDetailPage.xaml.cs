using System;

using Microsoft.Toolkit.Uwp.UI.Animations;

using MovieWorld.Services;
using MovieWorld.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MovieWorld.Views
{
    public sealed partial class PopularActorsDetailPage : Page
    {
        private PopularActorsDetailViewModel ViewModel
        {
            get { return ViewModelLocator.Current.PopularActorsDetailViewModel; }
        }

        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public PopularActorsDetailPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is int orderId)
            {
                await ViewModel.Initialize(orderId);
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
