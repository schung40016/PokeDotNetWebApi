using Microsoft.AspNetCore.Mvc;
using PokeDexWebApi.Controllers;
using PokeDex.Common.DTOs;
using PokeDex.Common.PokeApiModels;
using PokeDexWebApi.Services.ServiceInterface;

namespace PokeDexWebApi.Services
{
    public class PokemonTypeService : IPokemonTypeService
    {
        private PokeServiceAgent serviceAgent = new PokeServiceAgent();

        public async Task<ActionResult<PokemonTypeDTO>> GetPokemonType(int id)
        {
            return await this.GetPokemonTypeFromStringOrInt(id.ToString());
        }

        public async Task<ActionResult<PokemonTypeDTO>> GetPokemonType(string name)
        {
            return await this.GetPokemonTypeFromStringOrInt(name);
        }

        public async Task<ActionResult<PokemonTypeDTO>> GetPokemonTypeFromStringOrInt(string input)
        {
            ApiPokemonType deserializedObject = await serviceAgent.GetPokemonTypeByInput(input);

            PokemonTypeDTO tempPokemonType = new PokemonTypeDTO
            {
                Id = deserializedObject.id,
                Name = deserializedObject.name,
                Strengths = StrengthsToString(deserializedObject.damage_relations.half_damage_from),
                Weaknesses = WeaknessesToString(deserializedObject.damage_relations.double_damage_from),
                NoEffects = NoDamageToString(deserializedObject.damage_relations.no_damage_from)
            };

            return tempPokemonType;
        }

        public string StrengthsToString(List<ApiTypesDamageRelationsHalfDamageFrom> param_types)
        {
            string result = "";

            foreach (ApiTypesDamageRelationsHalfDamageFrom i in param_types)
            {
                result += (i.name + " ");
            }

            return result;
        }

        public string WeaknessesToString(List<ApiTypesDamageRelationsDoubleDamageFrom> param_types)
        {
            string result = "";

            foreach (ApiTypesDamageRelationsDoubleDamageFrom i in param_types)
            {
                result += (i.name + " ");
            }

            return result;
        }

        public string NoDamageToString(List<ApiTypesDamageRelationsNoDamageFrom> param_types)
        {
            string result = "";

            foreach (ApiTypesDamageRelationsNoDamageFrom i in param_types)
            {
                result += (i.name + " ");
            }

            return result;
        }
    }
}
