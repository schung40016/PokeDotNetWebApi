using Microsoft.AspNetCore.Mvc;
using PokeDexWebApi.Controllers;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;
using PokeDex.Common.PokeApiModels;
using PokeDexWebApi.Services.ServiceInterface;
using PokeDex.Data.Repositories;

namespace PokeDexWebApi.Services
{
    // Notes:
    // TO-DO: 
    // Rename, take out fromdblist.
    // Clean the "null" green squiggly lines problems.
    // Containerize (future feature).

    // Plans:
    // Caching.
    // Build a simulater @.@.
    // AI Randomizer. 
    // Data pipeline.

    public class AbilityService : IAbilityService
    {
        private PokeServiceAgent serviceAgent = new PokeServiceAgent();
        private AbilityRepository abilityRepository;

        public AbilityService(PokedexDbContext context)
        {
            abilityRepository = new AbilityRepository(context);
        }

        public async Task<ActionResult<AbilityDTO>> GetAbility(int id)
        {
            var ability = await abilityRepository.FetchAbilityById(id);

            return await this.GetAbilityFromStringOrInt(id.ToString(), ability);
        }

        public async Task<ActionResult<AbilityDTO>> GetAbility(string name)
        {
            var ability = await abilityRepository.FetchAbilityByName(name);

            return await this.GetAbilityFromStringOrInt(name, ability);
        }

        public async Task<ActionResult<AbilityDTO>> GetAbilityFromStringOrInt(string input, Ability model)
        {
            ApiAbility deserializedObject = await serviceAgent.GetAbilityByInput(input);

            bool isNull = model == null ? true : false;

            AbilityDTO tempAbility = new AbilityDTO
            {
                Id = !isNull ? model.Id : -1,
                Name = deserializedObject.name,
                Description = deserializedObject.effect_entries[1].short_effect,
                MoveCycle = !isNull ? model.MoveCycle : 1,
                ApiAbilityId = deserializedObject.id
            };

            return tempAbility;
        }

        public async Task<List<AbilityDTO>> FetchConvDTO(List<Ability> list)
        {
            List<AbilityDTO> tempList = list.Select(x => new AbilityDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                MoveCycle = x.MoveCycle,
                ApiAbilityId = x.ApiAbilityId,
            }).ToList();

            return tempList;
        }
    }
}
