using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.Models
{
    public enum MediaType
    {
        Movie,
        TvShow,
        Actor
    }
    public class SearchRequest
    {
        public string SearchText { get; set; }
        public MediaType Type { get; set; }
        public int Year { get; set; }
    }
}
