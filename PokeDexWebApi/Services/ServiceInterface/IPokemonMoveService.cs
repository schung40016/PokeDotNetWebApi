using PokeDex.Common.DTOs;
using PokeDex.Data.Models;

namespace PokeDexWebApi.Services.ServiceInterface
{
    public interface IPokemonMoveService
    {
        public Task<PokemonMoveDTO> GetPokemonMove(int id);

        public Task AddPokemonMove(int pokemonId, int moveId);

        public Task<PokemonMove> FetchPokemonMove(Pokemon pokemon, Move move);

        public Task<List<PokemonMoveDTO>> FetchPokemonMoveList();
    }
}
