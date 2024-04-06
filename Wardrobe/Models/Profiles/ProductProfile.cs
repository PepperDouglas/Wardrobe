using AutoMapper;
using Wardrobe.Models.DTO;
using Wardrobe.Models.Entities;

namespace Wardrobe.Models.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() {

            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.Productname,
                option => option.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description,
                option => option.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price,
                option => option.MapFrom(src => src.Price))
                .ForMember(dest => dest.Category, opt => opt.Ignore());

        }
    }
}
