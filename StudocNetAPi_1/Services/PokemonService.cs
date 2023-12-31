﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudocNetAPi_1.Models;
using StudocNetAPi_1.Models.ResponseModels;
using StudocNetAPi_1.Repositories;

namespace StudocNetAPi_1.Services
{
    public interface IPokemonService
    {
        public Task<ICollection<Pokemon>> GetPokemons();
    }
    public class PokemonService : IPokemonService
    {
        private readonly IMapper _mapper;
        private readonly PokemonRepository _pokemonRepository;

        public PokemonService(IMapper mapper, PokemonRepository pokemonRepository)
        {
            _mapper = mapper;
            _pokemonRepository = pokemonRepository;
        }

        public async Task<ICollection<Pokemon>> GetPokemons()
        {
            //var pokemons = await _pokemonRepository.GetPokemonsWithInclude();
            var pokemons =  await _pokemonRepository.GetAll()
                .Include(p => p.Reviews)
                .Include(p => p.PokemonCategories).ThenInclude(c => c.Category)
                .ToListAsync();

            return  pokemons;
        }
    }
}
