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
    [Route("api/[controller]")]
    [ApiController]
    public class AbilityController : ControllerBase
    {
        private readonly PokedexDbContext _context;
        private AbilityService abilityService = new AbilityService();

        public AbilityController(PokedexDbContext context)
        {
            _context = context;
        }

        // GET: api/Abilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbilityDTO>>> GetAbilities()
        {
            var list = await _context.Abilities.ToListAsync();

            return await abilityService.FetchConvDTO(list);
        }

        // GET: api/Abilities/drought
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AbilityDTO>> GetAbility(int id)
        {
            return await abilityService.GetAbility(id);  // rename 
        }

        // GET: api/Abilities/70
        [HttpGet("{name:alpha}")]
        public async Task<ActionResult<AbilityDTO>> GetAbility(string name)
        {
            return await abilityService.GetAbility(name);
        }

/*        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemonWithAbility(string name)
        {
            ApiAbility deserializedObject = await serviceAgent.GetAbilityByInput(name);

            // We have our move, now lets create each pokemon and return it as a list.

        }*/
    }
}
