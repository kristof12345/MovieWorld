using System;

using MovieWorld.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.Views
{
    public sealed partial class TopSeriesDetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(TopSeriesDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public TopSeriesDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as TopSeriesDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
