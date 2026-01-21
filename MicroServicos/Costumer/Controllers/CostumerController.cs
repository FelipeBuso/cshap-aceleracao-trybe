using Microsoft.AspNetCore.Mvc;

namespace Costumer.Controllers;

[ApiController]
[Route("[controller]")]
public class CostumerController : ControllerBase
{


    [HttpGet]
    public IActionResult GetStatus()
    {
        return Ok(new { message = "Api Costumer online" });
    }
}
