using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyService.Services.Models;

namespace CurrencyService.Services
{
    public interface ICurrencyService
    {
        public Task<decimal> GetCurrencyRate(CurrencyConversion currencyConversion);
    }
}
