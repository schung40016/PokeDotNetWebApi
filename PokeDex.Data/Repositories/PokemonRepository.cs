using Microsoft.EntityFrameworkCore;
using PokeDex.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Data.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokedexDbContext _context;

        public async Task<IEnumerable<Pokemon>> GetPokemons()
        {
            return await _context.Pokemons.ToListAsync();
        }

        public async Task Add(Pokemon itemToAdd)
        {
            await _context.Pokemons.AddAsync(itemToAdd);
            await _context.SaveChangesAsync();
        }
    }
}
