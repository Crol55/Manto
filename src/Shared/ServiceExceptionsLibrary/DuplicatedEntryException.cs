using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceExceptionsLibrary
{
    public class DuplicatedEntryException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string ErrorMessage { get; }

        public DuplicatedEntryException(string message):base(message)
        { 
            ErrorMessage = message;
        }
    }
}
