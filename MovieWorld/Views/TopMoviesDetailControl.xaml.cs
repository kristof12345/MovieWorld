using System;

using MovieWorld.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.Views
{
    public sealed partial class TopMoviesDetailControl : UserControl
    {
        public Movie MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as Movie; }
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
