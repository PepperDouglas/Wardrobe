using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Wardrobe.Helpers;
using Wardrobe.Models.Entities;

namespace Wardrobe.Data.Interfaces
{
    public interface IOrderRepo
    {
        Task<Order> GetOrder(int orderId);

        Task<bool> CreateOrder(Order order);

        Task<bool> DeleteOrder(int orderId);

        Task<bool> UpdateOrder(Order order);
    }
}
