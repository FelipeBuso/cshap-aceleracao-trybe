using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace Aula7.Filters;

public class CacheResourceFilter : Attribute, IResourceFilter
{
    private readonly IMemoryCache _cache;
    public CacheResourceFilter(IMemoryCache cache)
    {
        _cache = cache;
    }
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        //Gera chave de cache a partir do path da requisição
        string cacheKey = context.HttpContext.Request.Path.ToString();

        //Checa se existe resposta em cache
        if (_cache.TryGetValue(cacheKey, out IActionResult cachedResponse))
        {
            context.Result = cachedResponse;
        }
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        if (context.HttpContext.Response.StatusCode == StatusCodes.Status200OK)
        {
            //Gera chave de cache a partir do path da requisição
            string cacheKey = context.HttpContext.Request.Path.ToString();

            //Cache de resposta por 1 minuto
            _cache.Set(cacheKey, context.Result, TimeSpan.FromMinutes(1));
        }
    }
}