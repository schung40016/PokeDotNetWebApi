using Microsoft.AspNetCore.Mvc;
using PokeDexWebApi.Controllers;
using PokeDex.Common.DTOs;
using PokeDex.Common.PokeApiModels;
using PokeDex.Data.Repositories;
using PokeDex.Data.Models;
using PokeDexWebApi.Services.ServiceInterface;

namespace PokeDexWebApi.Services
{
    public class PokemonMoveService : IPokemonMoveService
    {
        private PokemonService pokemonService = new PokemonService();
        private MoveService moveService = new MoveService();
        private PokemonMoveRepository pokemonMoveRepository;

        public PokemonMoveService(PokedexDbContext context)
        {
            pokemonMoveRepository = new PokemonMoveRepository(context);
        }

        public async Task AddPokemonMove(int pokemonId, int moveId)
        {
            Console.WriteLine("Debug: " + pokemonId + " " + moveId);

            PokemonMove tempPokemonMove = new PokemonMove
            {
                PokemonId = pokemonId,
                MoveId = moveId
            };
            await pokemonMoveRepository.Add(tempPokemonMove);
        }

        public async Task<PokemonMove> FetchPokemonMove(Pokemon pokemon, Move move)
        {
            PokemonMove tempPokemonMove = new PokemonMove
            {
                PokemonId = pokemon.DexNumber,
                MoveId = move.Id
            };

            return tempPokemonMove;
        }
    }
}
