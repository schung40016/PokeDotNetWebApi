using Newtonsoft.Json;
using PokeDex.Common.PokeApiModels;
using System.Net.Http;

namespace PokeDexWebApi.Controllers.Interfaces
{
    public interface IPokeServiceAgent
    {
        public Task<ApiPokemonType> GetTypeByUrl(string url);

        public Task<ApiAbility> GetAbilityByUrl(string url);

        public Task<ApiPokemon> GetPokemonByInput(string input);

        public Task<ApiMove> GetMoveByInput(string input);

        public Task<ApiAbility> GetAbilityByInput(string input);

        public Task<ApiPokemonType> GetPokemonTypeByInput(string input);

        public Task<string> FetchJsonFromUrl(string url);
    }
}
