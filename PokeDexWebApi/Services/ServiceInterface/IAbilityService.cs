using Microsoft.AspNetCore.Mvc;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;

namespace PokeDexWebApi.Services.ServiceInterface
{
    public interface IAbilityService
    {
        public Task<AbilityDTO> GetAbility(int id);

        public Task<AbilityDTO> GetAbility(string name);

        public Task<AbilityDTO> GetAbilityFromStringOrInt(string input, Ability model);

        public Task<List<AbilityDTO>> FetchAbilityList();
    }
}
