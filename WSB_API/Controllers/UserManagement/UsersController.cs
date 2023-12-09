using Microsoft.AspNetCore.Mvc;

namespace WSB_API.Controllers.UserManagement;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
    [Route(users)]
    public IActionResult Index()
    {
        return Ok();
    }
}