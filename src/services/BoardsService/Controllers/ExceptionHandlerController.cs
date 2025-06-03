using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ServiceExceptionsLibrary;

namespace BoardsService.Controllers
{
    public class ExceptionHandlerController : ControllerBase
    {
        [Route("/error")]
        public IActionResult GlobalExceptionHandler() {

            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            (int statusCode, string errorMessage) = exception switch
            {
                IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "Unhandled error has occurred on the server")
            };

            return Problem(title: errorMessage, statusCode: statusCode);
        }
    }
}
