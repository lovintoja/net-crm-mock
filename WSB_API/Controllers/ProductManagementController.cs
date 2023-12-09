using Microsoft.AspNetCore.Mvc;

namespace WSB_API.Controllers;

[Route("productManagement")]
[ApiController]
public class ProductManagementController : Controller
{
    [HttpGet]
    public IActionResult GetProductProperties(int productId)
    {
        return Ok(2);
    }
}