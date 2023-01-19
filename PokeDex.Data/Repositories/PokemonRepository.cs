using Microsoft.EntityFrameworkCore;
using PokeDex.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Data.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokedexDbContext _context;

        public PokemonRepository(PokedexDbContext context)
        {
            _context = context;
        }

        public async Task<Pokemon> FetchPokemonById(int id)
        {
            var pokemonList = await _context.Pokemons.ToListAsync();

            return pokemonList.FirstOrDefault(x => x.DexNumber == id);
        }

        public async Task<Pokemon> FetchPokemonByName(string name)
        {
            var list = await _context.Pokemons.ToListAsync();

            return list.Find(x => x.Name == name);
        }
    }
}
