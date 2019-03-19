using System;

using MovieWorld.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.Views
{
    public sealed partial class TopMoviesDetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(TopMoviesDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

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
