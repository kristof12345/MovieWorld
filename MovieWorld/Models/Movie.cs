using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MovieWorld.Models
{

    class MovieList
    {
        public int Page { get; set; }
        public List<Movie> Results { get; set; }

        //Egyéb adatok
    }

    public class Movie
    {
        public int Id { get; set; }

        public bool Detailed { get; set; }

        //Cím
        public string Title { get; set; }

        //Megjelenési dátum
        public string Release_date { get; set; }

        //Népszerűség
        public float Popularity { get; set; }

        //Műfajok
        public List<Genre> Genres { get; set; }

        //Nyelvek
        public List<Language> Spoken_languages { get; set; }

        //Stáb
        public List<Actor> Cast { get; set; }

        //Rövid leírás
        public string Tagline { get; set; }

        //Hosszú leírás
        public string Overview { get; set; }

        //Kép
        public Uri Image { get { return new Uri("http://image.tmdb.org/t/p/w185/" + Poster_path); } }

        //Egyéb adatok

        public string Backdrop_path { get; set; }
        public int Budget { get; set; }      
        public string Homepage { get; set; }       
        public string Original_language { get; set; }      
        public string Poster_path { get; set; }       
        public int Runtime { get; set; }       
        public string Status { get; set; }      

        public override string ToString()
        {
            return $"{Title} {Release_date} {Popularity}";
        }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
