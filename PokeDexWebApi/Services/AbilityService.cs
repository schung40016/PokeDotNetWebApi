using Microsoft.AspNetCore.Mvc;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;
using PokeDex.Common.PokeApiModels;
using PokeDexWebApi.Services.ServiceInterface;
using PokeDex.Data.Repositories;
using PokeDexWebApi.Controllers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PokeDexWebApi.Services
{
    // Notes:
    // TO-DO: 
    // Containerize (future feature).

    // Plans:
    // Caching.
    // Build a simulater @.@.
    // AI Randomizer. 
    // Data pipeline.

    /*
     * Repository is like the ambassador for the program, responsible for interacting with the database.
     * Services processes all background functions for the controller.
     * Controller shouly simply call functions from the services.
     */

    public class AbilityService : IAbilityService
    {
        private readonly IPokeServiceAgent _serviceAgent;
        private readonly IAbilityRepository _abilityRepository;

        public AbilityService(IPokeServiceAgent agent, IAbilityRepository abilityRepository)
        {
            _serviceAgent = agent;
            _abilityRepository = abilityRepository;
        }

        public async Task<AbilityDTO> GetAbility(int id)
        {
            var ability = await _abilityRepository.FetchAbilityById(id);

            return await this.GetAbilityFromStringOrInt(id.ToString(), ability);
        }

        public async Task<AbilityDTO> GetAbility(string name)
        {
            var ability = await _abilityRepository.FetchAbilityByName(name);

            return await this.GetAbilityFromStringOrInt(name, ability);
        }

        public async Task<AbilityDTO> GetAbilityFromStringOrInt(string input, Ability model)
        {
            ApiAbility deserializedObject = await _serviceAgent.GetAbilityByInput(input);

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

        public async Task<List<AbilityDTO>> FetchAbilityList()
        {
            var list = await _abilityRepository.FetchAbilityList();

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
