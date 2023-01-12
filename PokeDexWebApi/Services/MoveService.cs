using Microsoft.AspNetCore.Mvc;
using PokeDexWebApi.Controllers;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;
using PokeDex.Common.PokeApiModels;
using PokeDexWebApi.Services.ServiceInterface;

namespace PokeDexWebApi.Services
{
    public class MoveService : IMoveService
    {
        private PokeServiceAgent serviceAgent = new PokeServiceAgent();

        public async Task<ActionResult<MoveDTO>> GetMove(int id)
        {
            return await this.GetMoveFromStringOrInt(id.ToString());
        }

        public async Task<ActionResult<MoveDTO>> GetMove(string name)
        {
            return await this.GetMoveFromStringOrInt(name);
        }

        public async Task<ActionResult<MoveDTO>> GetMoveFromStringOrInt(string input)
        {
            ApiMove apiMove = await serviceAgent.GetMoveByInput(input);
            ApiPokemonType apiType = await serviceAgent.GetTypeByUrl(apiMove.type.url);

            MoveDTO tempMove = new MoveDTO
            {
                Id = apiMove.id,
                Name = apiMove.name,
                TypeId = apiType.id,
                Description = apiMove.flavor_text_entries[0].flavor_text,
                Damage = apiMove.power,
                Pp = apiMove.pp
            };

            return tempMove;
        }

        public async Task<Move> FetchMoveObjWithID(string input)
        {
            ApiMove apiMove = await serviceAgent.GetMoveByInput(input);

            Move tempMove = new Move
            {
                Id = apiMove.id,
                Name = apiMove.name,
                Description = apiMove.flavor_text_entries[1].flavor_text,
                Damage = apiMove.power,
                Pp = apiMove.pp,
            };

            return tempMove;
        }
    }
}
