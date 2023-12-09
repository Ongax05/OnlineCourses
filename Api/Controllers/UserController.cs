using Api.Controllers;
using Api.Dtos;
using API.Dtos;
using API.Services;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // Controller for handling user-related actions
    public class UserController : ApiBaseController
    {
        // Field for dependency injection
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        // Constructor to initialize the controller with dependencies
        public UserController(IUserService userService, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteUserById")]
        public async Task<ActionResult<string>> DeleteCourseById([FromQuery]string UserName)
        {
            //Get User entity by its name
            var User = await _unitOfWork.Users.GetByUsernameAsync(UserName);

            if (User == null)
            {
                // Return a 404 Not Found response if the User with the given ID is not found
                return NotFound($"User with ID {UserName} not found");
            }

            _unitOfWork.Users.Remove(User);
            await _unitOfWork.SaveAsync();

            // Return a 200 OK response with a message indicating that the User has been deleted
            return Ok($"User with ID {UserName} has been deleted");
        }

        // POST action to add a role to a user (accessible only to "Admin" role)
        [Authorize(Roles = "Admin")]
        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync(AddRoleDto model)
        {
            // Call the UserService to add a role to a user
            var result = await _userService.AddRoleAsync(model);

            // Return the result as an Ok response
            return Ok(result);
        }
        // GET action to retrieve all Users and just for "Admins"
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBasicInformation>>> Get1_1()
        {
            // Retrieve all Users from the repository
            var registers = await _unitOfWork.Users.GetAllAsync();

            // Map the retrieved Users to UserBasicInformation
            var CourseListDto = _mapper.Map<List<UserBasicInformation>>(registers);

            // Return the mapped UserBasicInformation list
            return CourseListDto;
        }
    }
}
