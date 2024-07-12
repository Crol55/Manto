using System.Net;

namespace AuthenticationService.Errors
{
    public interface IServiceException
    {
        public HttpStatusCode StatusCode { get; }

        public string ErrorMessage { get; }
    }
}
