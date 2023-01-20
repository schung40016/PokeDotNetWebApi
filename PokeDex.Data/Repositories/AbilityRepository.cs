using Microsoft.EntityFrameworkCore;
using PokeDex.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Data.Repositories
{
    public class AbilityRepository : IAbilityRepository
    {
        private readonly PokedexDbContext _context;

        public AbilityRepository(PokedexDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ability>> FetchAbilityList()
        {
            var list = await _context.Abilities.ToListAsync();

            return list;
        }

        public async Task<Ability> FetchAbilityById(int id)
        {
            var ability = _context.Abilities.FirstOrDefault(x => x.ApiAbilityId == id);

            return ability!;
        }

        public async Task<Ability> FetchAbilityByName(string name)
        {
            var ability = _context.Abilities.FirstOrDefault(x => x.Name == name);

            return ability!;
        }
    }
}
