using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.Models
{
    public class RoleList
    {
        public int Id { get; set; }
        public List<Role> Cast { get; set; }

        //Egyéb adatok
    }

    public class Role
    {
        public int Id { get; set; }

        public string Character { get; set; }

        public Uri Image { get { return new Uri("http://image.tmdb.org/t/p/w185/" + Poster_path); } }

        public string Overview { get; set; }

        public string Credit_id { get; set; }
        public string Release_date { get; set; }
        public int Vote_count { get; set; }
        public float Vote_average { get; set; }
        public string Title { get; set; }
        public int[] Genre_ids { get; set; }
        public string Original_language { get; set; }
        public string Original_title { get; set; }
        public float Popularity { get; set; }       
        public string Backdrop_path { get; set; } 
        public string Poster_path { get; set; }
    }
}
