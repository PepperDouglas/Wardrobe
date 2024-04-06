using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Wardrobe.Data.Contexts;
using Wardrobe.Data.Interfaces;
using Wardrobe.Models.Entities;

namespace Wardrobe.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly WardrobeContext _context;

        public UserRepo(WardrobeContext context) {
            _context = context;
        }

        public async Task CreateUser(User user) {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteUser(User user) {
            var potuser = await _context.Users.FindAsync(user.UserId);
            if (potuser != null) {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Order>> GetUserOrders(int userId) {
            var orders = new List<Order>();
            return orders;
        }

        public async Task<User> ReadUserById(int id) {
            return await _context.Users.Include(u => u.Orders)
                .ThenInclude(o => o.ProductOrders)
                .SingleOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> ReadUserByName(string username) {
            return await _context.Users.Include(u => u.Orders)
                .SingleOrDefaultAsync(u => u.Username == username);
        }

        public async Task<bool> UpdateUser(User user) {
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.UserId == user.UserId);
            if (existingUser != null) {
                _context.Entry(existingUser).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
