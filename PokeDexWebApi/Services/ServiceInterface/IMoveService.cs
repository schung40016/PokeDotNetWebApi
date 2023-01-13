using Microsoft.AspNetCore.Mvc;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;

namespace PokeDexWebApi.Services.ServiceInterface
{
    public interface IMoveService
    {
        public Task<ActionResult<MoveDTO>> GetMove(int id);

        public Task<ActionResult<MoveDTO>> GetMove(string name);

        public Task<ActionResult<MoveDTO>> GetMoveFromStringOrInt(string input);

        public Task<List<MoveDTO>> FetchConvDTO(List<Move> list);
    }
}
