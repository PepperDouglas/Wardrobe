using AutoMapper;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Wardrobe.Core.Interfaces;
using Wardrobe.Data.Interfaces;
using Wardrobe.Helpers;
using Wardrobe.Models.DTO;
using Wardrobe.Models.Entities;

namespace Wardrobe.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepo, IMapper mapper) {
            _userRepo = userRepo;
            _mapper = mapper;
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

        public async Task<UserDTO> ReadUserById(int id) {
            var domainuser = await _userRepo.ReadUserById(id);
            var persondto = _mapper.Map<UserDTO>(domainuser);
            return persondto;
        }

        public async Task<UserDTO> ReadUserByName(string username) {
            var domainuser = await _userRepo.ReadUserByName(username);
            var persondto = _mapper.Map<UserDTO>(domainuser);
            return persondto;
        }

        public async Task<ResultFlag> UpdateUser(User user) {
            ResultFlag resultFlag = new ResultFlag(false, "Couldnt delete user");
            resultFlag.Success = await _userRepo.UpdateUser(user);
            if (resultFlag.Success) {
                resultFlag.Message = "User updated";
            }
            return resultFlag;
        }

        public void Logout() {
            UserLogger.IsLogged = false;
            UserLogger.UserId = 0;
            UserLogger.Cookie = "";
        }

        public async Task<ResultFlag> Login(UserCredentials credentials) {
            ResultFlag flag = new ResultFlag(false, "Something went wrong");
            var user = await _userRepo.ReadUserByName(credentials.Name);
            if (user == null) {
                flag.Message = "No such user";
                return flag;
            }
            if (user.Password == credentials.Password) {
                //from demo
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, "User"));

                //Generate JWToken, secret, creds, toptions
                //Kod bör hanteras med ex Azure keyvault
                var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecretKey12345!#123456789101112"));
                var signInCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5185/",
                    audience: "http://localhost:5185/",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: signInCredentials

                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                //end of demo
                flag.Success = true;
                flag.Message = tokenString;
                UserLogger.IsLogged = true;
                UserLogger.UserId = user.UserId;
                return flag;
            }
            return flag;
        }
    }
}
