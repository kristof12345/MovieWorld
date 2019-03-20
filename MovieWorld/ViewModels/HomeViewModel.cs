using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MovieWorld.Models;
using MovieWorld.Services;

namespace MovieWorld.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public RelayCommand<SearchRequest> SearchCommand { get; set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public string SearchText { get; set; }

        public HomeViewModel()
        {
            SearchCommand = new RelayCommand<SearchRequest>((SearchRequest searchRequest) =>
            {
                Search(searchRequest);
            });
        }

        private void Search(SearchRequest searchParams)
        {

        }
    }
}
