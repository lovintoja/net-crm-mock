using Microsoft.AspNetCore.Mvc;

namespace WSB_API.Controllers;

[ApiController]
public class ProductManagementController : Controller
{
    [Route("productManagement")]
    [HttpGet]
    public IActionResult GetProductProperties(int productId)
    {
        return Ok(2);
    }
}