using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyService.ErrorHandling.Exceptions;
using Microsoft.AspNetCore.Http;

namespace CurrencyService.ErrorHandling
{
    public class SweaCurrencyConversionExceptionHandler : IExceptionHandler
    {
        public async Task<bool> HandleAsync(Exception exception, HttpContext context)
        {
            var sweaCurrencyConversionException = exception as SweaCurrencyConversionException;

            if (sweaCurrencyConversionException != null)
            {
                await ExceptionWriter.WriteAsync(sweaCurrencyConversionException, context, (ex) =>
                    ExceptionResponseFormatter.InternalServerError(sweaCurrencyConversionException, sweaCurrencyConversionException.Message));
            }

            return sweaCurrencyConversionException != null;
        }
    }
}
