using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StatementWebApp.Core.Exception;

namespace StatementWebApp.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BadRequestException badRequestException)
        {
            context.Result = new BadRequestObjectResult(new { message = badRequestException.Message });
            context.ExceptionHandled = true;
        }
        else if (context.Exception is NotFoundException notFoundException)
        {
            context.Result = new NotFoundObjectResult(new { message = notFoundException.Message });
            context.ExceptionHandled = true;
        }
        else
        {
            context.Result = new ObjectResult(new { message = "Internal Server Error" })
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}