using Wardrobe.Helpers;
using Wardrobe.Models.Entities;

namespace Wardrobe.Core.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(User user);

        Task<User> ReadUserByName(string username);

        Task<User> ReadUserById(int id);

        Task<ResultFlag> UpdateUser(User user);

        Task<ResultFlag> DeleteUser(User user);
    }
}
