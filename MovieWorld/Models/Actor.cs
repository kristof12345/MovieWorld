using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.Models
{
    public class ActorList
    {
        public int Id { get; set; }
        public List<Actor> Cast { get; set; }

        //Egyéb adatok
    }

    public class Actor
    {
        public string Character { get; set; }

        public string Name { get; set; }

        public Uri Image { get { return new Uri("http://image.tmdb.org/t/p/w185/" + Profile_path); } }

        public string Profile_path { get; set; }

        public override string ToString()
        {
            return $"{Character} {Name}";
        }
    }
}
