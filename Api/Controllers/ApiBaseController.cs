using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("api/[controller]")]

// This class is currently empty, serving as a base for other API controllers.
// It includes attributes [ApiController] to enable common API behaviors
// and [Route("api/[controller]")] to define a base route for derived controllers.
public class ApiBaseController : ControllerBase
{

}
