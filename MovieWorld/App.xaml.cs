using System;
using System.Threading.Tasks;
using MovieWorld.Services;

using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace MovieWorld
{
    public sealed partial class App : Application
    {
        private Lazy<ActivationService> _activationService;

        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }

        public App()
        {
            InitializeComponent();
            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            //await PreloadData();

            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, typeof(ViewModels.HomeViewModel), new Lazy<UIElement>(CreateShell));
        }

        private UIElement CreateShell()
        {
            return new Views.ShellPage();
        }

        private async Task PreloadData()
        {
            var t1 = MovieDataService.GetTopMoviesAsync();
            var t2 = TvShowDataService.GetTopShowsAsync();

            await t1;
            await t2;
        }
    }
}
