using System.Net;

namespace ServiceExceptionsLibrary
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
