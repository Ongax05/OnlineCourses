using Api.Controllers;
using API.Dtos;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // Controller for handling user-related actions
    public class UserController : ApiBaseController
    {
        // Field for dependency injection
        private readonly IUserService _userService;

        // Constructor to initialize the controller with dependencies
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST action to register a new user (accessible only to "Instructor" role)
        [Authorize(Roles = "Instructor")]
        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterDto model)
        {
            // Call the UserService to register a new user
            var result = await _userService.RegisterAsync(model);

            // Return the result as an Ok response
            return Ok(result);
        }

        // POST action to get a token for authentication
        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync(LoginDto model)
        {
            // Call the UserService to get a token for authentication
            var result = await _userService.GetTokenAsync(model);

            // Return the result as an Ok response
            return Ok(result);
        }

        // POST action to add a role to a user (accessible only to "Instructor" role)
        [Authorize(Roles = "Instructor")]
        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync(AddRoleDto model)
        {
            // Call the UserService to add a role to a user
            var result = await _userService.AddRoleAsync(model);

            // Return the result as an Ok response
            return Ok(result);
        }

        // POST action to refresh an authentication token (accessible to "User" and "Instructor" roles)
        [Authorize(Roles = "User,Instructor")]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromQuery]string refreshToken)
        {
            // Call the UserService to refresh an authentication token
            var response = await _userService.RefreshTokenAsync(refreshToken);

            // Return the response as an Ok response
            return Ok(response);
        }
    }
}
