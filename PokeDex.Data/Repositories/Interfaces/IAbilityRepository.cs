using PokeDex.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Data.Repositories
{
    public interface IAbilityRepository
    {
        public Task<List<Ability>> FetchAbilityList();

        public Task<Ability> FetchAbilityById(int id);

        public Task<Ability> FetchAbilityByName(string name);
    }
}
