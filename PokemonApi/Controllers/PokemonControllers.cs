namespace PokemonApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using PokemonApi.Filters;

[ApiController]
[Route("[controller]")]

public class PokemonController : ControllerBase
{

    HttpClient _client;
    ILogger<PokemonController> _logger;

    public PokemonController(HttpClient client, ILogger<PokemonController> logger)
    {
        _client = client;
        _logger = logger;
    }

    [HttpGet("{name}")]
    [MyActionFilter]
    public async Task<ActionResult> GetPokemon(string name)
    {
        var response = await _client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{name}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("Pokemon retrivied: {name}", name);
            return Content(content, "application/json");
        }
        else
        {
            _logger.LogWarning("Error: Pokemon not found: {name}", name);
            return NotFound("Pokemon not found");
        }
    }
}