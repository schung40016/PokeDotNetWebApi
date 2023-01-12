using Microsoft.AspNetCore.Mvc;
using PokeDex.Common.DTOs;

namespace PokeDexWebApi.Services.ServiceInterface
{
    public interface IAbilityService
    {
        public Task<ActionResult<AbilityDTO>> GetAbilityDTO(int id);

        public Task<ActionResult<AbilityDTO>> GetAbilityDTO(string name);

        public Task<ActionResult<AbilityDTO>> GetAbilityFromStringOrInt(string input);
    }
}
