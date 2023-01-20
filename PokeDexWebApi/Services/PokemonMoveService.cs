using Microsoft.AspNetCore.Mvc;
using PokeDexWebApi.Controllers;
using PokeDex.Common.DTOs;
using PokeDex.Common.PokeApiModels;
using PokeDex.Data.Repositories;
using PokeDex.Data.Models;
using PokeDexWebApi.Services.ServiceInterface;
using System.Collections.Generic;

namespace PokeDexWebApi.Services
{
    public class PokemonMoveService : IPokemonMoveService
    {
        private readonly IPokemonMoveRepository _pokemonMoveRepository;

        public PokemonMoveService(IPokemonMoveRepository pokemonMoveRepository)
        {
            _pokemonMoveRepository = pokemonMoveRepository;
        }

        public async Task<PokemonMoveDTO> GetPokemonMove(int id)
        {
            List<PokemonMoveDTO> pokeMoveDTOList = await FetchPokemonMoveList();

            return pokeMoveDTOList.Find(x => x.Id == id);
        }

        public async Task AddPokemonMove(int pokemonId, int moveId)
        {
            PokemonMove tempPokemonMove = new PokemonMove
            {
                PokemonId = pokemonId,
                MoveId = moveId
            };
            await _pokemonMoveRepository.Add(tempPokemonMove);
        }

        public Task<PokemonMove> FetchPokemonMove(Pokemon pokemon, Move move)
        {
            PokemonMove tempPokemonMove = new PokemonMove
            {
                PokemonId = pokemon.DexNumber,
                MoveId = move.Id
            };

            return tempPokemonMove;
        }

        public async Task<List<PokemonMoveDTO>> FetchPokemonMoveList()
        {
            var list = await _pokemonMoveRepository.GetPokemonMoves();

            List<PokemonMoveDTO> tempList = list.Select(x => new PokemonMoveDTO
            {
                Id = x.Id,
                PokemonId = x.PokemonId,
                MoveId = x.MoveId
            }).ToList();

            return tempList;
        }
    }
}
