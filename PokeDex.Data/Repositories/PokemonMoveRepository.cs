using Microsoft.EntityFrameworkCore;
using PokeDex.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Data.Repositories
{
    public class PokemonMoveRepository : IPokemonMoveRepository
    {
        private readonly PokedexDbContext _context;

        public PokemonMoveRepository (PokedexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PokemonMove>> GetPokemonMoves()
        {
            return await _context.PokemonMoves.ToListAsync();
        }

        public async Task Add(PokemonMove itemToAdd)
        {
            await _context.PokemonMoves.AddAsync(itemToAdd);
            await _context.SaveChangesAsync();
        }
    }
}
