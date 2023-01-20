using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NuGet.Protocol.Plugins;
using PokeDex.Data.Models;
using PokeDex.Common.PokeApiModels;
using System.Net.Http;
using PokeDexWebApi.Controllers.Interfaces;

namespace PokeDexWebApi.Controllers
{
    public class PokeServiceAgent : IPokeServiceAgent
    {
        private static readonly HttpClient httpClient = new HttpClient();

        // Fetch Task by url.
        public async Task<ApiPokemonType> GetTypeByUrl(string url)
        {
            string jsonString = await FetchJsonFromUrl(url);

            return JsonConvert.DeserializeObject<ApiPokemonType>(jsonString);
        }

        public async Task<ApiAbility> GetAbilityByUrl(string url)
        {
            string jsonString = await FetchJsonFromUrl(url);

            return JsonConvert.DeserializeObject<ApiAbility>(jsonString);
        }

        public async Task<ApiPokemon> GetPokemonByInput(string input)
        {
            var url = "https://pokeapi.co/api/v2/pokemon/" + input;

            string jsonString = await FetchJsonFromUrl(url);

            return JsonConvert.DeserializeObject<ApiPokemon>(jsonString);
        }

        // Fetch Tasks by input parameter.
        public async Task<ApiMove> GetMoveByInput(string input) 
        {
            var url = "https://pokeapi.co/api/v2/move/" + input;

            string jsonString = await FetchJsonFromUrl(url);

            return JsonConvert.DeserializeObject<ApiMove>(jsonString);
        }

        public async Task<ApiAbility> GetAbilityByInput(string input)
        {
            var url = "https://pokeapi.co/api/v2/ability/" + input;

            string jsonString = await FetchJsonFromUrl(url);

            return JsonConvert.DeserializeObject<ApiAbility>(jsonString);
        }

        public async Task<ApiPokemonType> GetPokemonTypeByInput(string input)
        {
            var url = "https://pokeapi.co/api/v2/type/" + input;

            string jsonString = await FetchJsonFromUrl(url);

            return JsonConvert.DeserializeObject<ApiPokemonType>(jsonString);
        }

        public async Task<string> FetchJsonFromUrl(string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            HttpResponseMessage response = await httpClient.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
