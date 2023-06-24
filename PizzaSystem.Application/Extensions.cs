using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PizzaSystem.Core.Exceptions;

namespace PizzaSystem.Application;

public static class ControllerExtensions
{
    public static void AddErrorHandling(this ApiBehaviorOptions apiBehaviorOptions) => ErrorHandlingAction(apiBehaviorOptions);
    private static void ErrorHandlingAction(ApiBehaviorOptions apiBehaviorOptions)
    {
        apiBehaviorOptions.InvalidModelStateResponseFactory = context =>
        {
            if (context.ModelState.ErrorCount > 0)
            {
                var errorMessages = context.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                                           .ToArray();

                return new BadRequestObjectResult(errorMessages);
            }

            var exceptionType = context.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error?.GetType();

            if (exceptionType == typeof(EntityDoesNotExistException)) return new NotFoundResult();

            return new ObjectResult("An unexpected error occurred.")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        };
    }
}