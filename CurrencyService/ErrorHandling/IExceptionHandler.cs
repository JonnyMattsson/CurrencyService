using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CurrencyService.ErrorHandling
{
    public interface IExceptionHandler
    {
        Task<bool> HandleAsync(Exception exception, HttpContext context);
    }
}
