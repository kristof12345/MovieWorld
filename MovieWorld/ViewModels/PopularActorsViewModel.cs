﻿using System;
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
            SearchCommand = new RelayCommand(() => { SearchActors(1); });
        }

        private async void SearchActors(int pageIndex)
        {
            await ActorDataService.Search(SearchText, pageIndex);
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
                await ActorDataService.GetPopularActorsAsync(1);
            }
            else
            {
                await ActorDataService.Search(SearchText, 1);
            }
        }
    }
}
