using Aula7.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aula7.Filters;

public class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {

        if (string.IsNullOrEmpty(context.HttpContext.Request.Headers["Authorization"]))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}