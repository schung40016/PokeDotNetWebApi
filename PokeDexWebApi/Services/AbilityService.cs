using Microsoft.AspNetCore.Mvc;
using PokeDexWebApi.Controllers;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;
using PokeDex.Common.PokeApiModels;
using PokeDexWebApi.Services.ServiceInterface;

namespace PokeDexWebApi.Services
{
    public class AbilityService : IAbilityService
    {
        private PokeServiceAgent serviceAgent = new PokeServiceAgent();
    
        public async Task<ActionResult<AbilityDTO>> GetAbilityDTO(int id)
        {
            return await this.GetAbilityFromStringOrInt(id.ToString());
        }

        public async Task<ActionResult<AbilityDTO>> GetAbilityDTO(string name)
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
            };

            return tempAbility;
        }
    }
}
