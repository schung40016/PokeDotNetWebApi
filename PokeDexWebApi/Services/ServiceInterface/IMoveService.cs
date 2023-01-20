using Microsoft.AspNetCore.Mvc;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;

namespace PokeDexWebApi.Services.ServiceInterface
{
    public interface IMoveService
    {
        public Task<MoveDTO> GetMove(int id);

        public Task<MoveDTO> GetMove(string name);

        public Task<MoveDTO> GetMoveFromStringOrInt(string input, Move model);

        public Task<List<MoveDTO>> FetchMoveList();
    }
}
