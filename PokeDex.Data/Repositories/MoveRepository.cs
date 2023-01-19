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
    public class MoveRepository : IMoveRepository
    {
        private readonly PokedexDbContext _context;

        public MoveRepository(PokedexDbContext context)
        {
            _context = context;
        }

        public async Task<Move> FetchMoveById(int id)
        {
            var moveList = await _context.Moves.ToListAsync();

            return moveList.Find(x => x.ApiMoveId == id);
        }

        public async Task<Move> FetchMoveByName(string name)
        {
            var list = await _context.Moves.ToListAsync();

            return list.Find(x => x.Name == name);
        }
    }
}
