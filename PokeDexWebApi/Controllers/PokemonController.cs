using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;
using PokeDex.Common.PokeApiModels;
using PokeDexWebApi.Services;
using PokeDexWebApi.Services.ServiceInterface;

namespace PokeDexWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokedexDbContext _context;
        private PokeServiceAgent serviceAgent = new PokeServiceAgent();
        PokemonService pokemonService = new PokemonService();

        public PokemonController(PokedexDbContext context)
        {
            _context = context;
        }

        // GET: api/Pokemons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemons()
        {
            var list = await _context.Pokemons.ToListAsync();

            return await pokemonService.FetchConvDTO(list);
        }

        // GET: api/Pokemons/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PokemonDTO>> GetPokemon(int id)
        {
            return await pokemonService.GetPokemon(id);
        }

        // GET: api/Pokemons/5
        [HttpGet("{name:alpha}")]
        public async Task<ActionResult<PokemonDTO>> GetPokemon(string name)
        {
            return await pokemonService.GetPokemon(name);
        }
    }
}
