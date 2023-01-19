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
    public class MoveController : ControllerBase
    {
        private readonly PokedexDbContext _context;
        MoveService moveService;

        public MoveController(PokedexDbContext context)
        {
            _context = context;
            moveService = new MoveService(context);
        }

        // GET: api/Moves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoveDTO>>> GetMoves()   // ALl methods shoulkd return DTO (frontend), service layer also returns DTO
        {
            var list = await _context.Moves.ToListAsync();

            return await moveService.FetchConvDTO(list);
        }

        // GET: api/Moves/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MoveDTO>> GetMove(int id)
        {
            return await moveService.GetMove(id);
        }

        // GET: api/Moves/pound
        [HttpGet("{name}")]
        public async Task<ActionResult<MoveDTO>> GetMove(string name)
        {
            return await moveService.GetMove(name);
        }
    }
}
