using Microsoft.AspNetCore.Mvc;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;

namespace PokeDexWebApi.Services.ServiceInterface
{
    public interface IPokemonService
    {
        public Task<ActionResult<PokemonDTO>> GetPokemon(int id);

        public Task<ActionResult<PokemonDTO>> GetPokemon(string name);

        public Task<ActionResult<PokemonDTO>> GetPokemonFromStringOrInt(string input, Pokemon model);

        public Task<List<PokemonDTO>> FetchConvDTO(List<Pokemon> list);

    }
}
