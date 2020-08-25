using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CurrencyService.ErrorHandling
{
    public static class ExceptionWriter
    {
        public static async Task WriteAsync<TException>(TException exception, HttpContext context, Func<TException, ExceptionResponse> formatter) where TException : Exception
        {
            if (exception == null) throw new ArgumentNullException(nameof(exception));
            if (formatter == null) throw new ArgumentNullException(nameof(formatter));

            var response = formatter(exception);

            context.Response.StatusCode = response.StatusCode;

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
