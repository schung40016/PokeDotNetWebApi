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
using PokeDex.Data.Repositories;

namespace PokeDexWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        // GET: api/Pokemons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemons()
        {
            return await _pokemonService.FetchPokemonList();
        }

        // GET: api/Pokemons/5
        [HttpGet("{dexNumber:int}")]
        public async Task<ActionResult<PokemonDTO>> GetPokemon(int dexNumber)
        {
            return await _pokemonService.GetPokemon(dexNumber);
        }

        // GET: api/Pokemons/5
        [HttpGet("{name:alpha}")]
        public async Task<ActionResult<PokemonDTO>> GetPokemon(string name)
        {
            // Currently not working.
            return await _pokemonService.GetPokemon(name);
        }
    }
}
