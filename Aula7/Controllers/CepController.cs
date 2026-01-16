
using Aula7.Filters;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CepController : ControllerBase
{
    private readonly IHttpClientFactory _factory;

    public CepController(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    [HttpGet("{cep}")]
    [ServiceFilter(typeof(CacheResourceFilter))]
    public async Task<IActionResult> GetCep(string cep)
    {
        var client = _factory.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://viacep.com.br/ws/{cep}/json/");
        request.Headers.Add("Accept", "application/json");
        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<object>();
            return Ok(result);
        }
        return NotFound("Cep not found");
    }
}