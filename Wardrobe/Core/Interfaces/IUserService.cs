using Wardrobe.Helpers;
using Wardrobe.Models.DTO;
using Wardrobe.Models.Entities;

namespace Wardrobe.Core.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(User user);

        Task<UserDTO> ReadUserByName(string username);

        Task<UserDTO> ReadUserById(int id);

        Task<ResultFlag> UpdateUser(User user);

        Task<ResultFlag> DeleteUser(User user);
        void Logout();
        Task<ResultFlag> Login(UserCredentials credentials);
    }
}
