namespace PokemonApi.Filters;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class MyActionFilter : ActionFilterAttribute
{
    // Roda ANTES da Action: Usamos ActionExecutingContext
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            Console.WriteLine("Executando: ModelState Inválido");
            // Interrompe o fluxo e retorna 422
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }
    }

    // Roda DEPOIS da Action: Usamos ActionExecutedContext
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("Executado: Passou pela Action");
    }
}