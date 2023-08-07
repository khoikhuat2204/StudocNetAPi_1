using AutoMapper;
using StudocNetAPi_1.Models;
using StudocNetAPi_1.Models.ResponseModels;

namespace StudocNetAPi_1.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            MapPokemon();
        }

        private void MapPokemon()
        {
            CreateMap<Pokemon, PokemonResponse>().
                ReverseMap();
        }
    }
}
