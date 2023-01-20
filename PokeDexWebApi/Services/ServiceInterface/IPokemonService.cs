using Microsoft.AspNetCore.Mvc;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;

namespace PokeDexWebApi.Services.ServiceInterface
{
    public interface IPokemonService
    {
        public Task<PokemonDTO> GetPokemon(int id);

        public Task<PokemonDTO> GetPokemon(string name);

        public Task<PokemonDTO> GetPokemonFromStringOrInt(string input, Pokemon model);

        public Task<List<PokemonDTO>> FetchPokemonList();

    }
}
