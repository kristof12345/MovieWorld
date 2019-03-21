﻿using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Collections.Generic;
using MovieWorld.Models;
using System.Linq;
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
            client = new HttpClient(handler){ BaseAddress = baseAddress };
        }

        //Top filmek listázása
        internal async Task<List<Movie>> ListTopMoviesAsync()
        {
            var response = await client.GetAsync($"movie/popular?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<MovieList>();          
            return data.Results;
        }

        internal async Task<List<Movie>> GetSimilarMoviesAsync(int id)
        {
            var response = await client.GetAsync($"movie/{id}/similar?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<MovieList>();
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
