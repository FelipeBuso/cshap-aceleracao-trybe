namespace PetShop.Controllers;

using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Services;

[Controller]
[Route("[controller]")]
public class PetController : ControllerBase
{

    private IPetService _service;

    public PetController(IPetService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetPets()
    {

        return Ok(_service.GetPets());
    }

    [HttpPost]
    public IActionResult PostPet([FromBody] Pet newPet)
    {

        return Created("", _service.PosPet(newPet));
    }

    [HttpPut("{PetId:int}")]
    public IActionResult PutPet(int PetId, [FromBody] Pet updatedPet)
    {
        try
        {

            return Ok(_service.PutPet(PetId, updatedPet));
        }
        catch (Exception err)
        {

            return NotFound(new { Message = err.Message });
        }

    }

    [HttpDelete("{PetId:int}")]
    public IActionResult DeletePet(int PetId)
    {
        try
        {
            _service.DeletePet(PetId);
            return NoContent();

        }
        catch (Exception err)
        {

            return NotFound(new { Message = err.Message });
        }
    }

}