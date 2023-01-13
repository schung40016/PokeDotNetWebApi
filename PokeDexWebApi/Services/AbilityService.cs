using Microsoft.AspNetCore.Mvc;
using PokeDexWebApi.Controllers;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;
using PokeDex.Common.PokeApiModels;
using PokeDexWebApi.Services.ServiceInterface;

namespace PokeDexWebApi.Services
{
    // Notes:
    // TO-DO: combine data from API and Ability table. Make something up for the ability table SQL server. 
    // Containerize (future feature).

    public class AbilityService : IAbilityService
    {
        private PokeServiceAgent serviceAgent = new PokeServiceAgent();
    
        public async Task<ActionResult<AbilityDTO>> GetAbility(int id)
        {
            return await this.GetAbilityFromStringOrInt(id.ToString());
        }

        public async Task<ActionResult<AbilityDTO>> GetAbility(string name)
        {
            return await this.GetAbilityFromStringOrInt(name);
        }

        public async Task<ActionResult<AbilityDTO>> GetAbilityFromStringOrInt(string input)
        {
            ApiAbility deserializedObject = await serviceAgent.GetAbilityByInput(input);

            AbilityDTO tempAbility = new AbilityDTO
            {
                Id = deserializedObject.id,
                Name = deserializedObject.name,
                Description = deserializedObject.effect_entries[1].short_effect
                // Part of TO-DO: Add move cycle or damage.
            };

            return tempAbility;
        }

        public async Task<List<AbilityDTO>> FetchConvDTO(List<Ability> list)
        {
            List<AbilityDTO> tempList = list.Select(x => new AbilityDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();

            return tempList;
        }
    }
}
