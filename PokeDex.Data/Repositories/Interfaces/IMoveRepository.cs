using PokeDex.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Data.Repositories.Interfaces
{
    internal interface IMoveRepository
    {
        public Task<Move> FetchMoveById(int id);

        public Task<Move> FetchMoveByName(string name);
    }
}
