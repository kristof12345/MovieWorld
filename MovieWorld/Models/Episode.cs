﻿using System;

namespace MovieWorld.Models
{
    public class Episode
    {
        public string Name { get; set; }
        public int Episode_number { get; set; }
        public string Overview { get; set; }
        public Uri Image { get { return new Uri("http://image.tmdb.org/t/p/w500/" + Still_path); } }
        public string Still_path{get;set;}
    }
}
