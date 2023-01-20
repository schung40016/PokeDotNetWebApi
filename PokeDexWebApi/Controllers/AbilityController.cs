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
using PokeDex.Data.Repositories;

namespace PokeDexWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilityController : ControllerBase
    {
        private readonly IAbilityService _abilityService; 

        public AbilityController(IAbilityService abilityService)
        {
            _abilityService = abilityService;
        }

        // GET: api/Abilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbilityDTO>>> GetAbilities()
        {
            return await _abilityService.FetchAbilityList();
        }

        // GET: api/Abilities/drought
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AbilityDTO>> GetAbility(int id)
        {
            return await _abilityService.GetAbility(id);
        }

        // GET: api/Abilities/70
        [HttpGet("{name}")]
        public async Task<ActionResult<AbilityDTO>> GetAbility(string name)
        {
            return await _abilityService.GetAbility(name);
        }

        /*        
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemonWithAbility(string name)
        {
            ApiAbility deserializedObject = await serviceAgent.GetAbilityByInput(name);

            // We have our move, now lets create each pokemon and return it as a list.
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ability>> GetAbility(int id)
        {
            var ability = await _context.Abilities.FindAsync(id);

            if (ability == null)
            {
                return NotFound();
            }

            return ability;
        }
        */
    }
}
