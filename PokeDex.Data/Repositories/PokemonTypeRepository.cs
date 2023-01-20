using Microsoft.EntityFrameworkCore;
using PokeDex.Data.Models;
using PokeDex.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Data.Repositories
{
    public class PokemonTypeRepository : IPokemonTypeRepository
    {
        private readonly PokedexDbContext _context;

        public PokemonTypeRepository(PokedexDbContext context)
        {
            _context = context;
        }

        public async Task<List<PokemonType>> FetchPokemonTypeList()
        {
            var list = await _context.PokemonTypes.ToListAsync();

            return list;
        }
    }
}
