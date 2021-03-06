﻿using System;
using System.Collections.Generic;

namespace MovieWorld.Models
{
    public class ActorList
    {
        public int Id { get; set; }
        public List<Actor> Cast { get; set; } = new List<Actor>();
        //Egyéb adatok
    }

    public class PersonList
    {
        public int Page { get; set; }
        public List<Actor> Results { get; set; } = new List<Actor>();
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

        public string Name { get; set; }

        public Uri Image { get { return new Uri("http://image.tmdb.org/t/p/w500/" + Profile_path); } }

        public string Place_of_birth{get;set;}

        public string Birthday { get; set; }

        public string Biography { get; set; }

        public double Popularity { get; set; }

        public Gender Gender { get; set; }

        public List<Role> Roles { get; set; }

        public string Profile_path { get; set; }

        public override string ToString()
        {
            return $"{Name} {Birthday}";
        }
    }
}
