using System;
using System.Collections.Generic;

namespace MovieWorld.Models
{
    public class Season
    {
        public int Id { get; set; }

        //Cím
        public string Name { get; set; }

        //Évad sorszáma
        public int Season_number { get; set; }

        //Kép
        public Uri Image { get { return new Uri("http://image.tmdb.org/t/p/w185/" + Poster_path); } }

        //Stáb
        public List<Actor> Cast { get; set; } = new List<Actor>();

        //Megjelenés
        public string Air_date { get; set; }

        //Epizódok száma
        public int Episode_count { get; set; }

        //Hosszú leírás
        public string Overview { get; set; }

        //Epizódok
        public List<Episode> Episodes { get; set; } = new List<Episode>();

        //Más évadok
        public List<Season> OtherSeasons { get; set; }

        //Egyéb adatok
        public string Poster_path { get; set; }
    }

    public class SeasonId
    {
        public int ShowId { get; set; }
        public int SeasonNumber { get; set; }
    }
}
