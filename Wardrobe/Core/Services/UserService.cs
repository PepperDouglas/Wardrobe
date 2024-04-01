using Microsoft.Identity.Client;
using Wardrobe.Core.Interfaces;
using Wardrobe.Data.Interfaces;
using Wardrobe.Helpers;
using Wardrobe.Models.Entities;

namespace Wardrobe.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo) {
            _userRepo = userRepo;
        }

        public async Task CreateUser(User user) {
            await _userRepo.CreateUser(user);
        }

        public async Task<ResultFlag> DeleteUser(User user) {
            ResultFlag resultFlag = new ResultFlag(false, "Couldnt delete user");
            resultFlag.Success = await _userRepo.DeleteUser(user);
            if (resultFlag.Success) {
                resultFlag.Message = "User deleted";
            }
            return resultFlag;
        }

        public async Task<User> ReadUserById(int id) {
            return await _userRepo.ReadUserById(id);
        }

        public async Task<User> ReadUserByName(string username) {
            return await _userRepo.ReadUserByName(username);
        }

        public async Task<ResultFlag> UpdateUser(User user) {
            ResultFlag resultFlag = new ResultFlag(false, "Couldnt delete user");
            resultFlag.Success = await _userRepo.UpdateUser(user);
            if (resultFlag.Success) {
                resultFlag.Message = "User updated";
            }
            return resultFlag;
        }
    }
}
