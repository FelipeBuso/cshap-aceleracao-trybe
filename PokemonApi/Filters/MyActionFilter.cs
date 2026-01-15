namespace PokemonApi.Filters;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class MyActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("Antes");
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("Depois");

    }
}
