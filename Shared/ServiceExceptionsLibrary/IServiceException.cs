using System.Net;

namespace ServiceExceptionsLibrary
{
    public interface IServiceException
    {
        public HttpStatusCode StatusCode { get; }

        string ErrorMessage { get; }

    }
}
