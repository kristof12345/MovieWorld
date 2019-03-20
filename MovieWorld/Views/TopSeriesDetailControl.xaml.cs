using System;
using System.Collections.Generic;
using MovieWorld.Models;
using MovieWorld.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.Views
{
    public sealed partial class TopSeriesDetailControl : UserControl
    {
        public TopSeriesViewModel ViewModel { get { return ViewModelLocator.Current.TopSeriesViewModel; } }

        public TvShow MasterMenuItem
        {
            get { var show = GetValue(MasterMenuItemProperty) as TvShow; if (show != null) SeasonList.ItemsSource = show.Seasons; return show; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(TvShow), typeof(TopSeriesDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public TopSeriesDetailControl()
        {
            InitializeComponent();
            SeasonList.ItemsSource = new List<Season>();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as TopSeriesDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
