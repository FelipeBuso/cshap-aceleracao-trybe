namespace PokemonApi.Services;

public interface IApiService
{
    public Task<object> GetPokemonByName(string name);
}