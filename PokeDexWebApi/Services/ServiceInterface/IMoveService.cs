using Microsoft.AspNetCore.Mvc;
using PokeDex.Common.DTOs;

namespace PokeDexWebApi.Services.ServiceInterface
{
    public interface IMoveService
    {
        public Task<ActionResult<MoveDTO>> GetMove(int id);

        public Task<ActionResult<MoveDTO>> GetMove(string name);

        public Task<ActionResult<MoveDTO>> GetMoveFromStringOrInt(string input);
    }
}
