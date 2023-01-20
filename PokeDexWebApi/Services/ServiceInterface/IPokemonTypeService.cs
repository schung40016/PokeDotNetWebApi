using Microsoft.AspNetCore.Mvc;
using PokeDex.Common.DTOs;
using PokeDex.Common.PokeApiModels;
using PokeDex.Data.Models;

namespace PokeDexWebApi.Services.ServiceInterface
{
    public interface IPokemonTypeService
    {
        public Task<PokemonTypeDTO> GetPokemonType(int id);

        public Task<PokemonTypeDTO> GetPokemonType(string name);

        public Task<PokemonTypeDTO> GetPokemonTypeFromStringOrInt(string input);

        public Task<List<PokemonTypeDTO>> FetchPokemonTypeList();

        public string StrengthsToString(List<ApiTypesDamageRelationsHalfDamageFrom> param_types);

        public string WeaknessesToString(List<ApiTypesDamageRelationsDoubleDamageFrom> param_types);

        public string NoDamageToString(List<ApiTypesDamageRelationsNoDamageFrom> param_types);
    }
}
