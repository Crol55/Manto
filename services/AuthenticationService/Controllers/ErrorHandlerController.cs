
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Errors;

namespace AuthenticationService.Controllers
{
    public class ErrorHandlerController: ControllerBase
    {
        [NonAction]
        [Route("/error")]
        public IActionResult GlobalErrorHandler()
        {
            Exception? exception =  HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            
            var (statusCode, errorMessage) = exception switch
            {
                IServiceException Iexception => ((int)Iexception.StatusCode, Iexception.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An error occurred on the server")
            };

            return Problem(title: errorMessage, statusCode: statusCode);
        }
    }
}
