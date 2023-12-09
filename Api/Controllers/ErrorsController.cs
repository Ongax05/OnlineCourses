using Api.Controllers;
using API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // Controller for handling error responses
    public class ErrorsController : ApiBaseController
    {
        // GET action to handle errors and return an ApiResponse with the specified code
        [HttpGet]
        public IActionResult Error(int code)
        {
            // Return an ObjectResult containing an ApiResponse with the specified code
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
