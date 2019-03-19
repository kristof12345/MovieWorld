using System;
using System.Collections.Generic;

namespace MovieWorld.Models
{
    public class ActorList
    {
        public int Id { get; set; }
        public List<Actor> Cast { get; set; }
        //Egyéb adatok
    }

    public enum Gender
    {
        Other,
        Women,
        Man
    }

    public class Actor
    {
        public int Id { get; set; }

        public string Character { get; set; }

        public string Name { get; set; }

        public Uri Image { get { return new Uri("http://image.tmdb.org/t/p/w185/" + Profile_path); } }

        public string Place_of_birth{get;set;}

        public double Popularity { get; set; }

        public Gender Gender { get; set; }

        public string Profile_path { get; set; }

        public override string ToString()
        {
            return $"{Character} {Name}";
        }
    }
}
