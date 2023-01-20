using PokeDex.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Data.Repositories
{
    public interface IPokemonRepository
    {
        public Task<List<Pokemon>> FetchPokemonList();

        public Task<Pokemon> FetchPokemonById(int id);

        public Task<Pokemon> FetchPokemonByName(string name);
    }
}
