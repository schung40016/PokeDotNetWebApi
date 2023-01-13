using Microsoft.AspNetCore.Mvc;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;

namespace PokeDexWebApi.Services.ServiceInterface
{
    public interface IAbilityService
    {
        public Task<ActionResult<AbilityDTO>> GetAbility(int id);

        public Task<ActionResult<AbilityDTO>> GetAbility(string name);

        public Task<ActionResult<AbilityDTO>> GetAbilityFromStringOrInt(string input);

        public Task<List<AbilityDTO>> FetchConvDTO(List<Ability> list);
    }
}
