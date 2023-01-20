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
using PokeDexWebApi.Services.ServiceInterface;

namespace PokeDexWebApi.Controllers
{
    [Route("api/PokemonTypes")]
    [ApiController]
    public class PokemonTypeController : ControllerBase
    {
        private IPokemonTypeService _pokemonTypeService;

        public PokemonTypeController(IPokemonTypeService pokemonTypeService)
        {
            _pokemonTypeService = pokemonTypeService;
        }

        // GET: api/PokemonTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonTypeDTO>>> GetPokemonTypes()
        {
            return await _pokemonTypeService.FetchPokemonTypeList();
        }

        // GET: api/PokemonTypes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PokemonTypeDTO>> GetPokemonType(int id)
        {
            return await _pokemonTypeService.GetPokemonType(id);
        }

        // GET: api/PokemonTypes/normal
        [HttpGet("{name}")]
        public async Task<ActionResult<PokemonTypeDTO>> GetPokemonType(string name)
        {
            return await _pokemonTypeService.GetPokemonType(name);
        }
    }
}
