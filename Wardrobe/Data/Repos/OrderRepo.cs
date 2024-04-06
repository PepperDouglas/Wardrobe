using Microsoft.EntityFrameworkCore;
using Wardrobe.Data.Contexts;
using Wardrobe.Data.Interfaces;
using Wardrobe.Helpers;
using Wardrobe.Models.Entities;

namespace Wardrobe.Data.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private readonly WardrobeContext _context;

        public OrderRepo(WardrobeContext context) {
            _context = context;
        }

        public async Task<bool> CreateOrder(Order order) {
            try {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public async Task<bool> DeleteOrder(int orderId) {
            var order = await GetOrder(orderId);
            if (order == null) {
                return false;
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        
        public async Task<Order> GetOrder(int orderId) {
            return await _context.Orders.Include(o => o.ProductOrders).FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<bool> UpdateOrder(Order order) {
            try {
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
                return true;    

            }
            catch (Exception) {
                return false;
            }
        }
    }
}
