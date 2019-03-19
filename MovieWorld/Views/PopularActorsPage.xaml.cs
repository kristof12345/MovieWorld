using System;

using MovieWorld.ViewModels;

using Windows.UI.Xaml.Controls;

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
    }
}
