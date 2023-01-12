using Microsoft.AspNetCore.Mvc;
using PokeDex.Common.DTOs;
using PokeDex.Common.PokeApiModels;

namespace PokeDexWebApi.Services.ServiceInterface
{
    public interface IPokemonTypeService
    {
        public Task<ActionResult<PokemonTypeDTO>> GetPokemonType(int id);

        public Task<ActionResult<PokemonTypeDTO>> GetPokemonType(string name);

        public Task<ActionResult<PokemonTypeDTO>> GetPokemonTypeFromStringOrInt(string input);

        public string StrengthsToString(List<ApiTypesDamageRelationsHalfDamageFrom> param_types);

        public string WeaknessesToString(List<ApiTypesDamageRelationsDoubleDamageFrom> param_types);

        public string NoDamageToString(List<ApiTypesDamageRelationsNoDamageFrom> param_types);
    }
}
