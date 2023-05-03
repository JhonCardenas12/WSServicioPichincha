using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WSServicioPichincha.Domain.Exceptions
{
    public static class PichinchaStatusCode
    {
        private static Dictionary<Type, HttpStatusCode> exeptionStatusCodes = new Dictionary<Type, HttpStatusCode>
        {
            {typeof(PichinchaException), HttpStatusCode.BadRequest }
        };

        public static HttpStatusCode GetExceptionStatusCode(Exception exception)
        {
            bool exceptionFound = exeptionStatusCodes.TryGetValue(exception.GetType(), out HttpStatusCode statusCode);
            return exceptionFound ? statusCode : HttpStatusCode.InternalServerError;
        }

    }
}
