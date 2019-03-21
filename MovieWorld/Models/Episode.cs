using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.Models
{
    public class Episode
    {
        public string Name { get; set; }
        public int Episode_number { get; set; }
        public string Overview { get; set; }
        public Uri Image { get { return new Uri("http://image.tmdb.org/t/p/original/" + Still_path); } }
        public string Still_path{get;set;}
    }
}
