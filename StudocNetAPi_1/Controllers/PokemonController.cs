using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudocNetAPi_1.Models.ResponseModels;
using StudocNetAPi_1.Repositories;
using StudocNetAPi_1.Services;

namespace StudocNetAPi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonService pokemonService, IMapper mapper)
        {
            _pokemonService = pokemonService;
            _mapper = mapper;
        }

        [HttpGet("pokemons")]
        public async Task<IActionResult> GetPokemons()
        {
            var result = await _pokemonService.GetPokemons();
            return Ok(_mapper.Map<List<PokemonResponse>>(result));
        }

    }
}
