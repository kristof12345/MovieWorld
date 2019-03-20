using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Collections.Generic;
using MovieWorld.Models;
using System.Linq;

namespace MovieWorld.Services
{
    public static class HttpService
    {
        private static HttpClient client = null;
        private static HttpClientHandler handler = new HttpClientHandler();

        private static readonly string apiKey = "ccb62859a8fb8ace60f8a20b8dc8bd38";
        private static readonly Uri baseAddress = new Uri("https://api.themoviedb.org/3/");

        internal static void Initialize()
        {
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => { return true; };
            client = new HttpClient(handler){ BaseAddress = baseAddress };
        }

        //Top filmek listázása
        internal static async Task<List<Movie>> ListTopMoviesAsync()
        {
            var response = await client.GetAsync($"movie/popular?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<MovieList>();          
            return data.Results;
        }

        //Egy színész lekérése
        internal static async Task<Actor> GetActorAsync(int id)
        {
            var response = await client.GetAsync($"person/{id}?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<Actor>();
            return data;
        }

        //Stáb lekérése egy filmhez
        internal static async Task<List<Actor>> GetCastAsync(int id)
        {
            var response = await client.GetAsync($"movie/{id}/credits?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<ActorList>();
            return data.Cast;
        }

        //Egy film részletes adatainak lekérése
        internal static async Task<Movie> GetMovieAsync(int id)
        {
            var response = await client.GetAsync($"movie/{id}?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<Movie>();
            return data;
        }

        //Egy színész filmjeinek lekérése
        internal static async Task<List<Actor>> GetMoviesForActorAsync(int id)
        {
            var response = await client.GetAsync($"person/{id}/movie_credits?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<ActorList>();
            return data.Cast;
        }
    }
}
