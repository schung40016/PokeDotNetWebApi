using PokeDex.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Data.Repositories.Interfaces
{
    public interface IPokemonTypeRepository
    {
        public Task<List<PokemonType>> FetchPokemonTypeList();
    }
}
