using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyService.ErrorHandling
{
    public class ExceptionResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string InnerMessage { get; set; }
    }
}
