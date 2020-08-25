using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyService.Controllers.Models;
using CurrencyService.Controllers.Models.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyService.ServiceCollections
{
    public static class ModelValidatorServiceCollection
    {
        public static IServiceCollection AddModelValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CurrencyConversionRequest>, CurrencyConversationValidator>();
            return services;
        }
    }
}
