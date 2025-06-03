using System.Net;

namespace AuthenticationService.Errors
{
    public class ValidationException: Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public string ErrorMessage { get; }

        public ValidationException(string message): base(message)
        {
            ErrorMessage = message;
        }
    }
}
