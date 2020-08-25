using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyService.ErrorHandling.Exceptions
{
    public class SweaCurrencyConversionException : Exception
    {
        public SweaCurrencyConversionException(string message) : base(message) { }
        public SweaCurrencyConversionException(string message, Exception inner)
            : base(message, inner) { }
    }
}
