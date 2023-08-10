using AutoMapper;
using StudocNetAPi_1.Models;
using StudocNetAPi_1.Models.RequestModels;
using StudocNetAPi_1.Models.ResponseModels;

namespace StudocNetAPi_1.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            MapPokemon();
            MapOwner();
            MapCategory();
            MapReview();
        }

        private void MapReview()
        {
            CreateMap<Review, ReviewResponse>().ReverseMap();
        }

        private void MapCategory()
        {
            CreateMap<Category, CategoryResponse>().ReverseMap();
        }

        private void MapPokemon()
        {
            CreateMap<Pokemon, PokemonResponse>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.PokemonCategories.Select(sc => sc.Category)));

        }

        private void MapOwner()
        {
            CreateMap<Owner, OwnerResponse>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
            CreateMap<OwnerRequest, Owner>()
                .ReverseMap();
        }
    }
}
