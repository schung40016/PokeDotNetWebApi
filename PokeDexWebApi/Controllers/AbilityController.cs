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
    [Route("api/[controller]")]
    [ApiController]
    public class AbilityController : ControllerBase
    {
        private readonly PokedexDbContext _context;
        private PokeServiceAgent serviceAgent = new PokeServiceAgent();
        private AbilityService abilityService = new AbilityService();

        public AbilityController(PokedexDbContext context)
        {
            _context = context;
        }

        // GET: api/Abilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ability>>> GetAbilities()
        {
            return await _context.Abilities.ToListAsync();
        }

        // GET: api/Abilities/drought
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AbilityDTO>> GetAbility(int id)
        {
            return await abilityService.GetAbilityDTO(id);
        }

        // GET: api/Abilities/70
        [HttpGet("{name:alpha}")]
        public async Task<ActionResult<AbilityDTO>> GetAbility(string name)
        {
            return await abilityService.GetAbilityDTO(name);
        }

/*        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemonWithAbility(string name)
        {
            ApiAbility deserializedObject = await serviceAgent.GetAbilityByInput(name);

            // We have our move, now lets create each pokemon and return it as a list.

        }*/
    }
}
