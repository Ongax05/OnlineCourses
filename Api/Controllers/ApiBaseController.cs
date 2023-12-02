using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "User")]
public class ApiBaseController : ControllerBase
{

}
