using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceExceptionsLibrary
{
    public class ForbiddenAccessException: Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Forbidden;

        public string ErrorMessage { get; }

        public ForbiddenAccessException(string message) 
        {
            ErrorMessage = message;
        }
    }
}
