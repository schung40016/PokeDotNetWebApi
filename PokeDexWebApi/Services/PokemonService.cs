using Microsoft.AspNetCore.Mvc;
using PokeDexWebApi.Controllers;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;
using PokeDex.Common.PokeApiModels;
using PokeDexWebApi.Services.ServiceInterface;
using PokeDex.Data.Repositories;

namespace PokeDexWebApi.Services
{
    public class PokemonService : IPokemonService
    {
        private PokeServiceAgent serviceAgent = new PokeServiceAgent();
        private PokemonRepository pokemonRepository;

        public PokemonService(PokedexDbContext context)
        {
            pokemonRepository = new PokemonRepository(context);
        }

        public async Task<ActionResult<PokemonDTO>> GetPokemon(int id)
        {
            Pokemon pokemon = await pokemonRepository.FetchPokemonById(id);

            return await this.GetPokemonFromStringOrInt(id.ToString(), pokemon);
        }

        public async Task<ActionResult<PokemonDTO>> GetPokemon(string name)
        {
            var pokemon = await pokemonRepository.FetchPokemonByName(name);

            return await this.GetPokemonFromStringOrInt(name, pokemon);
        }

        public async Task<ActionResult<PokemonDTO>> GetPokemonFromStringOrInt(string input, Pokemon model)
        {
            ApiPokemon apiPokemon = await serviceAgent.GetPokemonByInput(input);

            ApiPokemonType apiType = await serviceAgent.GetTypeByUrl(apiPokemon.types[0].type.url);
            ApiAbility apiAbility = await serviceAgent.GetAbilityByUrl(apiPokemon.abilities[0].ability.url);

            bool isNull = model == null ? true : false;

            PokemonDTO tempPokemon = new PokemonDTO
            {
                Id = !isNull ? model.Id : -1,
                DexNumber = apiPokemon.id,
                Name = apiPokemon.name,
                PokemonTypeId = apiType.id,
                Description = apiPokemon.name,
                AbilityId = apiAbility.id,
                Region = !isNull ? model.Region : "unknown"
            };

            return tempPokemon;
        }

        public async Task<List<PokemonDTO>> FetchConvDTO(List<Pokemon> list)
        {
            List<PokemonDTO> tempList = list.Select(x => new PokemonDTO
            {
                Id = x.Id,
                DexNumber = x.DexNumber,
                Name = x.Name,
                PokemonTypeId = x.PokemonTypeId,
                Description = x.Description,
                AbilityId = x.AbilityId,
                Region = x.Region
            }).ToList();

            return tempList;
        }
    }
}
