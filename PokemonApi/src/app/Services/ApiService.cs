namespace PokemonApi.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _client;

    public ApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<object> GetPokemonByName(string name)
    {
        var response = await _client.GetAsync(name);
        if (!response.IsSuccessStatusCode)
        {
            return default(Object)!;
        }
        var result = await response.Content.ReadFromJsonAsync<object>();
        return result!;
    }

}