using AutoMapper;
using BeerShop.Domains.EntitiesDB;
using BeerShop.ViewModels;

namespace BeerShop.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Beer, BeerVM>()
                .ForMember(dest => dest.Brouwernaam,
                opt => opt.MapFrom(
                    src => src.BrouwernrNavigation != null
                    ? src.BrouwernrNavigation.Naam : string.Empty))
                .ForMember(dest => dest.Soortnaam,
                opt => opt.MapFrom(
                    src => src.SoortnrNavigation != null
                    ? src.SoortnrNavigation.Soortnaam : string.Empty));
            CreateMap<Brewery, BreweryVM>();
            CreateMap<Beer, BeerBaseCRUD>();
            CreateMap<BeerBaseCRUD, Beer>();
        }
    }
}
