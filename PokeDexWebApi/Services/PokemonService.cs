using Microsoft.AspNetCore.Mvc;
using PokeDexWebApi.Controllers;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;
using PokeDex.Common.PokeApiModels;
using PokeDexWebApi.Services.ServiceInterface;

namespace PokeDexWebApi.Services
{
    public class PokemonService : IPokemonService
    {
        private PokeServiceAgent serviceAgent = new PokeServiceAgent();

        public async Task<ActionResult<PokemonDTO>> GetPokemon(int id)
        {
            return await this.GetPokemonFromStringOrInt(id.ToString());
        }

        public async Task<ActionResult<PokemonDTO>> GetPokemon(string name)
        {
            return await this.GetPokemonFromStringOrInt(name);
        }

        public async Task<ActionResult<PokemonDTO>> GetPokemonFromStringOrInt(string input)
        {
            ApiPokemon apiPokemon = await serviceAgent.GetPokemonByInput(input);

            ApiPokemonType apiType = await serviceAgent.GetTypeByUrl(apiPokemon.types[0].type.url);
            ApiAbility apiAbility = await serviceAgent.GetAbilityByUrl(apiPokemon.abilities[0].ability.url);

            PokemonDTO tempPokemon = new PokemonDTO
            {
                DexNumber = apiPokemon.id,
                Name = apiPokemon.name,
                PokemonTypeId = apiType.id,
                Description = apiPokemon.name,
                AbilityId = apiAbility.id
            };

            return tempPokemon;
        }

        public async Task<Pokemon> FetchPokemonObjWithID(string input)
        {
            ApiPokemon apiPokemon = await serviceAgent.GetPokemonByInput(input);

            Pokemon tempPokemon = new Pokemon
            {
                DexNumber = apiPokemon.id,
                Name = apiPokemon.name,
                PokemonTypeId = apiPokemon.id,
                AbilityId = apiPokemon.id
            };

            return tempPokemon;
        }
    }
}
