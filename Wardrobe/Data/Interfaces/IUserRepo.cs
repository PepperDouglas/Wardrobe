using Wardrobe.Models.Entities;

namespace Wardrobe.Data.Interfaces
{
    public interface IUserRepo
    {
        Task CreateUser(User user);

        Task<User> ReadUserByName(string username);

        Task<User> ReadUserById(int id);

        Task<bool> UpdateUser(User user);

        Task<bool> DeleteUser(User user);
    }
}
