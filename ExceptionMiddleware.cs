using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DeaDXoxoton;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ProblemDetailsFactory _problemDetailsFactory;

    public ExceptionMiddleware(RequestDelegate next, ProblemDetailsFactory problemDetailsFactory)
    {
        _next = next;
        _problemDetailsFactory = problemDetailsFactory;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var actionContext = new ActionContext { HttpContext = context };

            const int statusCode = StatusCodes.Status500InternalServerError;

            var problemDetails = _problemDetailsFactory.CreateProblemDetails(context,
                statusCode,
                exception.Message,
                exception.GetType().Name,
                instance: Guid.NewGuid().ToString());

            var problemResult = new ObjectResult(problemDetails) { StatusCode = statusCode };

            await problemResult.ExecuteResultAsync(actionContext);
        }
    }
}