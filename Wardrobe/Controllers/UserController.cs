﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wardrobe.Core.Interfaces;
using Wardrobe.Helpers;
using Wardrobe.Models.DTO;
using Wardrobe.Models.Entities;

namespace Wardrobe.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase {
        private readonly IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet]
        [Route("api/login")]
        [AllowAnonymous]
        public async Task<IActionResult> UserLogin(UserCredentials credentials) {
            try {
                var result = await _userService.Login(credentials);
                if (result.Success == false) {
                    return BadRequest(result.Message);
                }
                return Ok(new
                {
                    Token = result.Message
                }); ;
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/logout")]
        [AllowAnonymous]
        public async Task<IActionResult> UserLogout() {
            _userService.Logout();
            return Ok("Logged out");
        }

        [HttpGet]
        [Route("api/username/{name}")]
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

        [HttpGet]
        [Route("api/userid/{id}")]
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
        [Route("api/create-user")]
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
        [Route("api/update-user")]
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
        [Route("api/remove-user")]
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
