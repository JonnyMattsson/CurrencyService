using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CurrencyService.ErrorHandling
{
    public static class ExceptionResponseFormatter
    {
        public static ExceptionResponse InternalServerError(Exception exception, string message)
        {
#if DEBUG
            var innerMessage = exception.ToString();
#else
            string innerMessage = message;
#endif
            return Format("Internal Server Error", innerMessage);
        }
        
        public static ExceptionResponse Format(string message, string innerMessage = null, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return new ExceptionResponse
            {
                Message = message,
                InnerMessage = innerMessage,
                StatusCode = (int)statusCode
            };
        }
    }
}
