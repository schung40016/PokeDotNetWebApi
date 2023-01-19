using Microsoft.AspNetCore.Mvc;
using PokeDexWebApi.Controllers;
using PokeDex.Common.DTOs;
using PokeDex.Data.Models;
using PokeDex.Common.PokeApiModels;
using PokeDexWebApi.Services.ServiceInterface;
using PokeDex.Data.Repositories;

namespace PokeDexWebApi.Services
{
    public class MoveService : IMoveService
    {
        private PokeServiceAgent serviceAgent = new PokeServiceAgent();
        private MoveRepository moveRepository;

        public MoveService(PokedexDbContext context)
        {
            moveRepository = new MoveRepository(context);
        }

        public async Task<MoveDTO> GetMove(int id)
        {
            var move = await moveRepository.FetchMoveById(id);

            return await this.GetMoveFromStringOrInt(id.ToString(), move);
        }

        public async Task<MoveDTO> GetMove(string name)
        {
            var move = await moveRepository.FetchMoveByName(name);

            return await this.GetMoveFromStringOrInt(name, move);
        }

        public async Task<MoveDTO> GetMoveFromStringOrInt(string input, Move model)
        {
            ApiMove apiMove = await serviceAgent.GetMoveByInput(input);
            ApiPokemonType apiType = await serviceAgent.GetTypeByUrl(apiMove.type.url);

            bool isNull = model == null ? true : false;

            MoveDTO tempMove = new MoveDTO
            {
                Id = !isNull ? model.Id : -1,   // ?. null propagation.
                ApiMoveId = apiMove.id,
                Name = apiMove.name,
                TypeId = apiType.id,
                Description = apiMove.flavor_text_entries.Count != 0 ? apiMove.flavor_text_entries[0].flavor_text : "",   // Produces a OutOfRangeException for name inputs.
                Damage = apiMove.power != null ? apiMove.power : 0,
                Pp = apiMove.pp,
                InflictsStatus = !isNull ? model.InflictsStatus : false
            };

            return tempMove;
        }

        public async Task<List<MoveDTO>> FetchConvDTO(List<Move> list)
        {
            List<MoveDTO> tempList = list.Select(x => new MoveDTO
            {
                Id = x.Id,
                ApiMoveId = x.ApiMoveId,
                Name = x.Name,
                TypeId = x.TypeId,
                Description = x.Description,
                Damage= x.Damage,
                Pp = x.Pp,
                InflictsStatus = x.InflictsStatus
            }).ToList();

            return tempList;
        }
    }
}
