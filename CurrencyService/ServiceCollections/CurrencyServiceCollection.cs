using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyService.Services;
using CurrencyService.Services.External;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyService.ServiceCollections
{
    public static class CurrencyServiceCollection
    {
        public static IServiceCollection AddCurrencyServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyService, SweaCurrencyService>();
            services.AddScoped<ICurrencyConversionService, CurrencyConversionService>();

            return services;
        }
    }
}
