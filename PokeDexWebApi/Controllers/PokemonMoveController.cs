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
using PokeDexWebApi.Services.ServiceInterface;

namespace PokeDexWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonMoveController : ControllerBase
    {
        private readonly IPokemonMoveService _pokemonMoveService;

        public PokemonMoveController(IPokemonMoveService pokemonMoveService)
        {
            _pokemonMoveService = pokemonMoveService;
        }

        // GET: api/PokemonMoves
        // All regular get methods fetch the entire entry from the back-end database.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonMoveDTO>>> GetPokemonMoves()
        {
            return await _pokemonMoveService.FetchPokemonMoveList();
        }

        // GET: api/PokemonMoves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonMoveDTO>> GetPokemonMove(int id)
        {
            return await _pokemonMoveService.GetPokemonMove(id);
        }

        [HttpPost]
        public async Task<ActionResult<PokemonMoveDTO>> PostPokemonMove(int pokemonId, int moveId)
        {
            await _pokemonMoveService.AddPokemonMove(pokemonId, moveId);

            return null;
        }
    }
}
