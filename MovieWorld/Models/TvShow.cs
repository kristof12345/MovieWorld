using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.Models
{
    public class TvShowList
    {
        public int Page { get; set; }
        public List<TvShow> Results { get; set; }
    }

    public class TvShow
    {
        //Kép
        public Uri Image { get { return new Uri("http://image.tmdb.org/t/p/w185/" + Poster_path); } }

        public string backdrop_path { get; set; }
        public List<Creator> Created_by { get; set; }
        public int[] episode_run_time { get; set; }
        public string first_air_date { get; set; }
        public List<Genre> Genres { get; set; }
        public string homepage { get; set; }
        public int Id { get; set; }
        public bool in_production { get; set; }
        public string[] languages { get; set; }
        public string last_air_date { get; set; }
        public string Name { get; set; }
        public List<Network> Networks { get; set; }
        public int Number_of_episodes { get; set; }
        public int Number_of_seasons { get; set; }
        public string Overview { get; set; }
        public float Popularity { get; set; }
        public string Poster_path { get; set; }
        public List<Company> Production_companies { get; set; }
        public List<Season> Seasons { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }

    }

    public class Creator
    {
        public int id { get; set; }
        public string credit_id { get; set; }
        public string name { get; set; }
        public int gender { get; set; }
        public string profile_path { get; set; }
    }

    public class Network
    {
        public string name { get; set; }
        public int id { get; set; }
        public string logo_path { get; set; }
        public string origin_country { get; set; }
    }

    public class Company
    {
        public int id { get; set; }
        public string logo_path { get; set; }
        public string name { get; set; }
        public string origin_country { get; set; }
    }

    public class Season
    {
        public string air_date { get; set; }
        public int episode_count { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public int season_number { get; set; }
    }
}
