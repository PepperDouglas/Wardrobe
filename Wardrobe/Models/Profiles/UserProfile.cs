using AutoMapper;
using Wardrobe.Models.DTO;
using Wardrobe.Models.Entities;

namespace Wardrobe.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {

            CreateMap<User, UserDTO>()
                .ForMember(des => des.Name,
                option => option.MapFrom(src => src.Username))
                .ForMember(des => des.Orders,
                option => option.MapFrom(src => src.Orders));

            CreateMap<Order, OrderDTO>()
        .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
        .ForMember(dest => dest.ProductOrders, opt => opt.MapFrom(src => src.ProductOrders));
            // Add mapping for ProductOrder to ProductOrderDTO if necessary

            CreateMap<ProductOrder, ProductOrderDTO>()
    
    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
    
    .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
            // If you need to map more details about the Product, consider using a ProductDTO
        }
    }
}
