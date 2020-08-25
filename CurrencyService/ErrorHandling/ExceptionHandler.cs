using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CurrencyService.ErrorHandling
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly IEnumerable<IExceptionHandler> _exceptionHandlers;

        public ExceptionHandler(IEnumerable<IExceptionHandler> exceptionHandlers)
        {
            _exceptionHandlers = exceptionHandlers ?? throw new ArgumentNullException(nameof(exceptionHandlers));
        }

        public async Task<bool> HandleAsync(Exception exception, HttpContext context)
        {
            foreach (var handler in _exceptionHandlers)
            {
                var handled = await handler.HandleAsync(exception, context);

                if (handled)
                {
                    return true;
                }
            }

            return false;
        }

        public static ExceptionHandler Create()
        {
            var handlers = new IExceptionHandler[]
            {
                new SweaCurrencyConversionExceptionHandler(),
            };

            return new ExceptionHandler(handlers);
        }
    }
}
