using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Collections.Generic;
using MovieWorld.Models;
using System.Diagnostics;

namespace MovieWorld.Services
{
    public class HttpService
    {
        private HttpClient client = null;
        private HttpClientHandler handler = new HttpClientHandler();

        private static readonly string apiKey = "ccb62859a8fb8ace60f8a20b8dc8bd38";
        private static readonly Uri baseAddress = new Uri("https://api.themoviedb.org/3/");

        public HttpService()
        {
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => { return true; };
            client = new HttpClient(handler) { BaseAddress = baseAddress };
        }

        //Top filmek listázása
        internal async Task<List<Movie>> ListTopMoviesAsync()
        {
            var response = await client.GetAsync($"movie/popular?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<MovieList>();
            return data.Results;
        }

        internal async Task<List<Actor>> GetPopularActorsAsync(int index)
        {
            var response = await client.GetAsync($"person/popular?api_key={apiKey}&page={index}");
            var data = await response.Content.ReadAsAsync<PersonList>();
            return data.Results;
        }

        internal async Task<List<Movie>> SearchMoviesAsync(string searchParams, int index)
        {
            var response = await client.GetAsync($"search/movie?api_key={apiKey}&query={searchParams}&page={index}");
            var data = await response.Content.ReadAsAsync<MovieList>();
            return data.Results;
        }

        internal async Task<List<TvShow>> SearchShowsAsync(string searchParams, int index)
        {
            var response = await client.GetAsync($"search/tv?api_key={apiKey}&query={searchParams}&page={index}");
            var data = await response.Content.ReadAsAsync<TvShowList>();
            return data.Results;
        }

        internal async Task<List<Movie>> ListLatestMoviesAsync(int index)
        {
            var response = await client.GetAsync($"movie/now_playing?api_key={apiKey}&page={index}");
            var data = await response.Content.ReadAsAsync<MovieList>();
            return data.Results;
        }

        internal async Task<List<Genre>> GetGenresAsync()
        {
            var response = await client.GetAsync($"genre/movie/list?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<GenreList>();
            return data.Genres;
        }

        internal async Task<List<TvShow>> GetTvShowsByGenresAsync(int id, int index)
        {
            var response = await client.GetAsync($"discover/tv?api_key={apiKey}&sort_by=popularity.desc&with_genres={id}&page={index}");
            var data = await response.Content.ReadAsAsync<TvShowList>();
            return data.Results;
        }

        internal async Task<List<Movie>> GetMoviesByGenresAsync(int id, int index)
        {
            var response = await client.GetAsync($"genre/{id}/movies?api_key={apiKey}&page={index}&page={index}");
            var data = await response.Content.ReadAsAsync<MovieList>();
            return data.Results;
        }

        internal async Task<List<TvShow>> ListLatestShowsAsync(int index)
        {
            var response = await client.GetAsync($"tv/airing_today?api_key={apiKey}&page={index}");
            var data = await response.Content.ReadAsAsync<TvShowList>();
            return data.Results;
        }

        internal async Task<List<Actor>> SearchActorsAsync(string searchText, int index)
        {
            var response = await client.GetAsync($"search/person?api_key={apiKey}&query={searchText}&page={index}");
            var data = await response.Content.ReadAsAsync<PersonList>();
            return data.Results;
        }

        internal async Task<List<Movie>> GetSimilarMoviesAsync(int id)
        {
            var response = await client.GetAsync($"movie/{id}/similar?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<MovieList>();
            return data.Results;
        }

        internal async Task<List<Actor>> GetSeasonCastAsync(int showId, int seasonNumber)
        {
            var response = await client.GetAsync($"tv/{showId}/season/{seasonNumber}/credits?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<ActorList>();
            return data.Cast;
        }

        internal async Task<List<TvShow>> GetSimilarShowsAsync(int id)
        {
            var response = await client.GetAsync($"tv/{id}/similar?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<TvShowList>();
            return data.Results;
        }

        internal async Task<Season> GetSeasonAsync(int showId, int seasonNumber)
        {
            var response = await client.GetAsync($"tv/{showId}/season/{seasonNumber}?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<Season>();
            return data;
        }

        //Egy színész lekérése
        internal async Task<Actor> GetActorAsync(int id)
        {
            var response = await client.GetAsync($"person/{id}?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<Actor>();
            return data;
        }

        //Stáb lekérése egy filmhez
        internal async Task<List<Actor>> GetCastAsync(int id)
        {
            var response = await client.GetAsync($"movie/{id}/credits?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<ActorList>();
            if (data.Cast.Count == 0)
                Debug.WriteLine("HIBA");
            return data.Cast;
        }

        //Egy film részletes adatainak lekérése
        internal async Task<Movie> GetMovieAsync(int id)
        {
            var response = await client.GetAsync($"movie/{id}?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<Movie>();
            return data;
        }

        //Egy színész filmjeinek lekérése
        internal async Task<List<Role>> GetMoviesForActorAsync(int id)
        {
            var response = await client.GetAsync($"person/{id}/movie_credits?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<RoleList>();
            return data.Cast;
        }

        //Top sorozatok listázása
        internal async Task<List<TvShow>> ListTopShowsAsync()
        {
            var response = await client.GetAsync($"tv/popular?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<TvShowList>();
            return data.Results;
        }

        //Egy sorozat részleteinek lekérése
        internal async Task<TvShow> GetShowAsync(int id)
        {
            var response = await client.GetAsync($"tv/{id}?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<TvShow>();
            return data;
        }
    }
}
