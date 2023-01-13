using PokeDex.Common.DTOs;
using PokeDex.Data.Models;

namespace PokeDexWebApi.Services.ServiceInterface
{
    public interface IPokemonMoveService
    {
        public Task AddPokemonMove(int pokemonId, int moveId);

        public Task<PokemonMove> FetchPokemonMove(Pokemon pokemon, Move move);

        public Task<List<PokemonMoveDTO>> FetchConvDTO(List<PokemonMove> list);
    }
}
