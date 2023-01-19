using Microsoft.EntityFrameworkCore;
using PokeDex.Data.Models;
using System;
using System.Collections.Generic;
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

        public async Task<Ability> FetchAbilityById(int id)
        {
            var abilityList = await _context.Abilities.ToListAsync();

            return abilityList.FirstOrDefault(x => x.ApiAbilityId == id);
        }

        public async Task<Ability> FetchAbilityByName(string name)
        {
            var list = await _context.Abilities.ToListAsync();

            return list.Find(x => x.Name == name);
        }
    }
}
