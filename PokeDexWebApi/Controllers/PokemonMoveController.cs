using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeDex.Data.Models;
using PokeDex.Data.Repositories;
using PokeDexWebApi.Services;

namespace PokeDexWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonMoveController : ControllerBase
    {
        private readonly PokedexDbContext _context;
        private PokemonMoveService pokemonMoveService;

        public PokemonMoveController(PokedexDbContext context)
        {
            _context = context;
            pokemonMoveService = new PokemonMoveService(context);
        }

        // GET: api/PokemonMoves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonMove>>> GetPokemonMoves()
        {
            return await _context.PokemonMoves.ToListAsync();
        }

        // GET: api/PokemonMoves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonMove>> GetPokemonMove(int id)
        {
            var pokemonMove = await _context.PokemonMoves.FindAsync(id);

            if (pokemonMove == null)
            {
                return NotFound();
            }

            return pokemonMove;
        }

        [HttpPost]
        public async Task<ActionResult<PokemonMove>> PostPokemonMove(int pokemonId, int moveId)
        {
            await pokemonMoveService.AddPokemonMove(pokemonId, moveId);
            return null;
        }
    }
}
