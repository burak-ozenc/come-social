using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace ComeSocial.Api.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    // GET
    protected IActionResult Problem(List<Error> errors)
    {
        HttpContext.Items["errors"] = errors;
        var firstError = errors[0];

        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => (int)StatusCodes.Status409Conflict,
            ErrorType.Validation => (int)StatusCodes.Status400BadRequest,
            ErrorType.NotFound => (int)StatusCodes.Status404NotFound,
            _ => (int)StatusCodes.Status500InternalServerError
        };
        return Problem();
    }
}