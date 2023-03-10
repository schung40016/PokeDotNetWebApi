using PokeDex.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Data.Repositories
{
    public interface IPokemonMoveRepository
    {
        public Task<List<PokemonMove>> FetchPokemonMoveList();

        Task Add(PokemonMove itemToAdd);

        Task<IEnumerable<PokemonMove>> GetPokemonMoves();
    }
}
