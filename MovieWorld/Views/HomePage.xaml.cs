using System;

using MovieWorld.ViewModels;

using Windows.UI.Xaml.Controls;

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
    }
}
