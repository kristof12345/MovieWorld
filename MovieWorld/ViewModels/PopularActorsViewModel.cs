using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Collections;
using Microsoft.Toolkit.Uwp;
using Microsoft.Toolkit.Uwp.UI.Animations;
using MovieWorld.Models;
using MovieWorld.Models.IncrementalSources;
using MovieWorld.Services;

namespace MovieWorld.ViewModels
{
    public class PopularActorsViewModel : ViewModelBase
    {
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;
        public RelayCommand SearchCommand { get; private set; }
        private ICommand _itemClickCommand;
        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new RelayCommand<Actor>(OnItemClick));

        public string SearchText { get; set; } = "";
        public IncrementalLoadingCollection<IIncrementalSource<Actor>, Actor> ActorSource;

        public PopularActorsViewModel()
        {
            SearchCommand = new RelayCommand(() => { OnSearch(); });
        }

        private void OnSearch()
        {
            ActorSource = new IncrementalLoadingCollection<IIncrementalSource<Actor>, Actor>(new ActorSourceBySearch(SearchText));
            RaisePropertyChanged("ActorSource");
        }

        private void OnItemClick(Actor clickedItem)
        {
            if (clickedItem != null)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnnimation(clickedItem);
                NavigationService.Navigate(typeof(ActorDetailViewModel).FullName, clickedItem.Id);
            }
        }

        internal async Task LoadDataAsync()
        {
            if (SearchText == "")
            {
                ActorSource = new IncrementalLoadingCollection<IIncrementalSource<Actor>, Actor>(new ActorSourceBypopular());
                RaisePropertyChanged("MovieSource");
            }
            else
            {
                await ActorDataService.SearchAsync(SearchText, 1);
            }
        }
    }
}
