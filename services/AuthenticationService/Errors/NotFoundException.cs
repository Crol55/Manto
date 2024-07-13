using System.Net;

namespace AuthenticationService.Errors
{
    public class NotFoundException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public string ErrorMessage {get; }

        public NotFoundException(string message) { 
            ErrorMessage = message;
        }
    }
}
