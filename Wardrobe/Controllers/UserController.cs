using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wardrobe.Core.Interfaces;
using Wardrobe.Models.Entities;

namespace Wardrobe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetUserByName(string name) {
            try {
                var user = await _userService.ReadUserByName(name);
                if (user == null) {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetUserById(int id) {
            try {
                var user = await _userService.ReadUserById(id);
                if (user == null) {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user) {
            try {
                await _userService.CreateUser(user);
                return Ok(user);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User user) {
            try {
                var result = await _userService.UpdateUser(user);
                if (result.Success) {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(User user) {
            try {
                var result = await _userService.DeleteUser(user);
                if (result.Success) {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }



        /*
         Task CreateUser(User user);

        Task<User> ReadUserByName(string username);

        Task<User> ReadUserById(int id);

        Task<ResultFlag> UpdateUser(User user);

        Task<ResultFlag> DeleteUser(User user);
         
         
         
         
         */
    }
}
