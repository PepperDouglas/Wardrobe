using Wardrobe.Helpers;
using Wardrobe.Models.DTO;
using Wardrobe.Models.Entities;

namespace Wardrobe.Core.Interfaces
{
    public interface IOrderService
    {
        Task<Order> GetOrder(int orderId);

        Task<ResultFlag> CreateOrder(List<ProductOrderDTO> productOrders);

        Task<ResultFlag> DeleteOrder(int orderId);

        
    }
}
