using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyService.ErrorHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace CurrencyService.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger<Startup> logger)
        {
            var exceptionHandler = ExceptionHandler.Create();

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature == null)
                    {
                        return;
                    }

                    logger.LogError(contextFeature.Error.ToString());

                    await exceptionHandler.HandleAsync(contextFeature.Error, context);
                });
            });
        }
    }
}
