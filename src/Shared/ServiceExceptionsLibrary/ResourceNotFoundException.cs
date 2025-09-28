using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceExceptionsLibrary
{
    public class ResourceNotFoundException: Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
        public string ErrorMessage { get; }

        public ResourceNotFoundException(string message) : base(message) 
        {
            this.ErrorMessage = message;
        }

    }
}
