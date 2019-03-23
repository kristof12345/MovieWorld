using GalaSoft.MvvmLight.Ioc;
using MovieWorld.Services;
using MovieWorld.Views;

namespace MovieWorld.ViewModels
{
    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        private static ViewModelLocator _current;

        public static ViewModelLocator Current => _current ?? (_current = new ViewModelLocator());

        private ViewModelLocator()
        {
            //Register NEW PAGES
            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<HomeViewModel, HomePage>();
            Register<TopMoviesViewModel, TopMoviesPage>();
            Register<TopSeriesViewModel, TopSeriesPage>();
            Register<PopularActorsViewModel, PopularActorsPage>();
            Register<ActorDetailViewModel, ActorDetailPage>();
            Register<MovieDetailViewModel, MovieDetailPage>();
            Register<TvShowDetailViewModel, TvShowDetailPage>();
            Register<SeasonDetailViewModel, SeasonDetailPage>();
            Register<NewReleasesViewModel, NewReleasesPage>();
            Register<SettingsViewModel, SettingsPage>();
        }

        //NEW PAGES
        public SettingsViewModel SettingsViewModel => SimpleIoc.Default.GetInstance<SettingsViewModel>();

        public ActorDetailViewModel ActorDetailViewModel => SimpleIoc.Default.GetInstance<ActorDetailViewModel>();

        public MovieDetailViewModel MovieDetailViewModel => SimpleIoc.Default.GetInstance<MovieDetailViewModel>();

        public TvShowDetailViewModel TvShowDetailViewModel => SimpleIoc.Default.GetInstance<TvShowDetailViewModel>();

        public SeasonDetailViewModel SeasonDetailViewModel => SimpleIoc.Default.GetInstance<SeasonDetailViewModel>();

        public PopularActorsViewModel PopularActorsViewModel => SimpleIoc.Default.GetInstance<PopularActorsViewModel>();

        public TopSeriesViewModel TopSeriesViewModel => SimpleIoc.Default.GetInstance<TopSeriesViewModel>();

        public TopMoviesViewModel TopMoviesViewModel => SimpleIoc.Default.GetInstance<TopMoviesViewModel>();

        public HomeViewModel HomeViewModel => SimpleIoc.Default.GetInstance<HomeViewModel>();

        public NewReleasesViewModel WhatsNewViewModel => SimpleIoc.Default.GetInstance<NewReleasesViewModel>();

        public ShellViewModel ShellViewModel => SimpleIoc.Default.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => SimpleIoc.Default.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
