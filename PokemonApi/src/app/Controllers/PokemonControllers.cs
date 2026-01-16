namespace PokemonApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using PokemonApi.Filters;
using PokemonApi.Services;

[ApiController]
[Route("[controller]")]

public class PokemonController : ControllerBase
{

    private readonly IApiService _api;
    ILogger<PokemonController> _logger;

    public PokemonController(IApiService api, ILogger<PokemonController> logger)
    {
        _api = api;
        _logger = logger;
    }

    [HttpGet("{name}")]
    [MyActionFilter]
    public async Task<ActionResult> GetPokemon(string name)
    {
        var pokemon = await _api.GetPokemonByName(name);
        if (pokemon != null)
        {

            _logger.LogInformation("Pokemon retrivied: {name}", name);
            return Ok(pokemon);
        }
        else
        {
            _logger.LogWarning("Error: Pokemon not found: {name}", name);
            return NotFound("Pokemon not found");
        }
    }
}