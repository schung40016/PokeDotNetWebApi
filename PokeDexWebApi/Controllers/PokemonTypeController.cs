using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;
using PokeDex.Common.PokeApiModels;
using PokeDexWebApi.Services;
using static System.Net.WebRequestMethods;

namespace PokeDexWebApi.Controllers
{
    [Route("api/PokemonTypes")]
    [ApiController]
    public class PokemonTypeController : ControllerBase
    {
        private readonly PokedexDbContext _context;
        private PokeServiceAgent serviceAgent = new PokeServiceAgent();
        private PokemonTypeService pokemonTypeService = new PokemonTypeService();

        public PokemonTypeController(PokedexDbContext context)
        {
            _context = context;
        }

        // GET: api/PokemonTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonType>>> GetPokemonTypes()
        {
            return await _context.PokemonTypes.ToListAsync();
        }

        // GET: api/PokemonTypes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PokemonTypeDTO>> GetPokemonType(int id)
        {
            return await pokemonTypeService.GetPokemonType(id);
        }

        // GET: api/PokemonTypes/normal
        [HttpGet("{name:alpha}")]
        public async Task<ActionResult<PokemonTypeDTO>> GetPokemonType(string name)
        {
            return await pokemonTypeService.GetPokemonType(name);
        }
    }
}
