using Microsoft.AspNetCore.Mvc;

namespace Order.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{


    [HttpGet]
    public IActionResult GetStatus()
    {
        return Ok(new { message = "Api Order online" });
    }
}
