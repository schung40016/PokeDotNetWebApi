using PokeDex.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Data.Repositories
{
    public interface IMoveRepository
    {
        public Task<List<Move>> FetchMoveList();

        public Task<Move> FetchMoveById(int id);

        public Task<Move> FetchMoveByName(string name);
    }
}
