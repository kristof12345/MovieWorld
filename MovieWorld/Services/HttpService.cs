using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Collections.Generic;
using MovieWorld.Models;

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
            var response = await client.GetAsync($"movie/top_rated?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<MovieList>();          
            return data.Results;
        }

        //Egy film részletes adatainak lekérése
        internal static async Task<Movie> GetMovieAsync(int id)
        {
            var response = await client.GetAsync($"movie/{id}?api_key={apiKey}");
            var data = await response.Content.ReadAsAsync<Movie>();
            return data;
        }
    }
}
