using AutoMapper;
using Wardrobe.Models.DTO;
using Wardrobe.Models.Entities;

namespace Wardrobe.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {

            CreateMap<User, UserDTO>()
                .ForMember(des => des.Orders,
                option => option.MapFrom(src => src.Username))
                .ForMember(des => des.Orders,
                option => option.MapFrom(src => src.Orders));
        
        }
    }
}
