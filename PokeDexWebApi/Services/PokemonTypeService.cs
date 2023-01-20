using Microsoft.AspNetCore.Mvc;
using PokeDexWebApi.Controllers;
using PokeDex.Common.DTOs;
using PokeDex.Common.PokeApiModels;
using PokeDexWebApi.Services.ServiceInterface;
using PokeDex.Data.Models;
using PokeDex.Data.Repositories;
using PokeDexWebApi.Controllers.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PokeDex.Data.Repositories.Interfaces;

namespace PokeDexWebApi.Services
{
    public class PokemonTypeService : IPokemonTypeService
    {
        private readonly IPokeServiceAgent _serviceAgent;
        private readonly IPokemonTypeRepository _pokemonTypeRepository;

        public PokemonTypeService(IPokeServiceAgent agent, IPokemonTypeRepository pokemonTypeRepository)
        {
            _serviceAgent = agent;
            _pokemonTypeRepository = pokemonTypeRepository;
        }

        public async Task<PokemonTypeDTO> GetPokemonType(int id)
        {
            return await this.GetPokemonTypeFromStringOrInt(id.ToString());
        }

        public async Task<PokemonTypeDTO> GetPokemonType(string name)
        {
            return await this.GetPokemonTypeFromStringOrInt(name);
        }

        public async Task<PokemonTypeDTO> GetPokemonTypeFromStringOrInt(string input)
        {
            ApiPokemonType deserializedObject = await _serviceAgent.GetPokemonTypeByInput(input);

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

        public async Task<List<PokemonTypeDTO>> FetchPokemonTypeList()
        {
            var list = await _pokemonTypeRepository.FetchPokemonTypeList();

            List<PokemonTypeDTO> tempList = list.Select(x => new PokemonTypeDTO
            {
                Id = x.Id,
                Name = x.Name,
                Strengths = x.Strengths,
                Weaknesses = x.Weaknesses,
                NoEffects = x.NoEffects
            }).ToList();

            return tempList;
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
