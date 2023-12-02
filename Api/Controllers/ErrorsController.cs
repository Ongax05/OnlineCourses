using API.Helpers;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

public class ErrorsController:ApiBaseController
{
    [HttpGet]
    public IActionResult Error(int code)
    {
        return new ObjectResult(new ApiResponse(code));
    }
}
