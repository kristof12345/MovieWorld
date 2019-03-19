using System;
using System.Linq;

using GalaSoft.MvvmLight;

using MovieWorld.Models;
using MovieWorld.Services;

namespace MovieWorld.ViewModels
{
    public class PopularActorsDetailViewModel : ViewModelBase
    {
        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public PopularActorsDetailViewModel()
        {
        }

        public void Initialize(long orderId)
        {
            var data = SampleDataService.GetContentGridData();
            Item = data.First(i => i.OrderId == orderId);
        }
    }
}
