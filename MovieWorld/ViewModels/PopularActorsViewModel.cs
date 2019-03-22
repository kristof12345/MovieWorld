using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.UI.Animations;
using MovieWorld.Models;
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
        public ObservableCollection<Actor> Source{get {  return ActorDataService.ActorsList;} }

        public PopularActorsViewModel()
        {
            SearchCommand = new RelayCommand(() => { SearchActors(); });
        }

        private async void SearchActors()
        {
            await ActorDataService.Search(SearchText);
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
                await ActorDataService.GetPopularActorsAsync();
            }
            else
            {
                await ActorDataService.Search(SearchText);
            }
        }
    }
}
