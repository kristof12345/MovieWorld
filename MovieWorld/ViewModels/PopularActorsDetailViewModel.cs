using System;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

using MovieWorld.Models;
using MovieWorld.Services;

namespace MovieWorld.ViewModels
{
    public class PopularActorsDetailViewModel : ViewModelBase
    {
        private Actor actor;

        public Actor Actor
        {
            get { return actor; }
            set { Set(ref actor, value); }
        }

        public PopularActorsDetailViewModel()
        {
        }

        public async Task Initialize(int id)
        {
            Actor = await ActorDataService.GetActorDataAsync(id);
        }
    }
}
