using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeDex.Common.DTOs;
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
        // All regular get methods fetch the entire entry from the back-end database.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonMoveDTO>>> GetPokemonMoves()
        {
            var list = await _context.PokemonMoves.ToListAsync();

            return await pokemonMoveService.FetchConvDTO(list);
        }

        // GET: api/PokemonMoves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonMoveDTO>> GetPokemonMove(int id)
        {
            var list = await _context.PokemonMoves.ToListAsync();

            return await pokemonMoveService.GetPokemonMove(list, id);
        }

        [HttpPost]
        public async Task<ActionResult<PokemonMoveDTO>> PostPokemonMove(int pokemonId, int moveId)
        {
            await pokemonMoveService.AddPokemonMove(pokemonId, moveId);
            return null;
        }
    }
}
