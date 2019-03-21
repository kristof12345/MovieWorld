using System.Collections.Generic;
using MovieWorld.Models;
using MovieWorld.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.Views
{
    public sealed partial class TopMoviesDetailControl : UserControl
    {
        public TopMoviesViewModel ViewModel{ get { return ViewModelLocator.Current.TopMoviesViewModel; } }

        public Movie MasterMenuItem
        {
            get { var movie = GetValue(MasterMenuItemProperty) as Movie; if(movie != null) CastList.ItemsSource = movie.Cast; return movie; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(Movie), typeof(TopMoviesDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public TopMoviesDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as TopMoviesDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
