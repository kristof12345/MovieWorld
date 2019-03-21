using System;
using System.Collections.Generic;

namespace MovieWorld.Models
{
    public class TvShowList
    {
        public int Page { get; set; }
        public List<TvShow> Results { get; set; }
    }

    public class TvShow
    {
        public int Id { get; set; }

        //Cím
        public string Name { get; set; }

        //Megjelenés
        public string First_air_date { get; set; }

        //Utolsú vetítés
        public string Last_air_date { get; set; }

        //Műfajok
        public List<Genre> Genres { get; set; }

        //Évadok
        public List<Season> Seasons { get; set; } = new List<Season>();

        //Csatornák
        public List<Network> Networks { get; set; }

        //Gyártó cégk
        public List<Company> Production_companies { get; set; }

        //Évadok száma
        public int Number_of_episodes { get; set; }

        //Részek száma
        public int Number_of_seasons { get; set; }

        //Hosszú leírás
        public string Overview { get; set; }

        //Népszerűség
        public float Popularity { get; set; }

        //Kép
        public Uri Image { get { return new Uri("http://image.tmdb.org/t/p/w185/" + Poster_path); } }

        //Egyéb adatok
        public string Backdrop_path { get; set; }
        public string Poster_path { get; set; }
    }

    public class Network
    {
        public int Id { get; set; }
        public string Name { get; set; }      
        public string Logo_path { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo_path { get; set; }
    }

    public class Season
    {
        public int Id { get; set; }

        //Cím
        public string Name { get; set; }

        //Évad sorszáma
        public int Season_number { get; set; }

        //Kép
        public Uri Image { get { return new Uri("http://image.tmdb.org/t/p/w185/" + Poster_path); } }

        //Megjelenés
        public string Air_date { get; set; }

        //Epizódok száma
        public int Episode_count { get; set; }

        //Hosszú leírás
        public string Overview { get; set; }

        //Egyéb adatok
        public string Poster_path { get; set; }
    }

    public class SeasonId
    {
        public int ShowId { get; set; }
        public int SeasonNumber { get; set; }
    }
}
