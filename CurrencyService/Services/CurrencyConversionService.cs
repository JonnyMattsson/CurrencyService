using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyService.Services.Models;

namespace CurrencyService.Services
{
    public class CurrencyConversionService : ICurrencyConversionService
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyConversionService(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        public async Task<CurrencyConversion> Convert(CurrencyConversion currencyConversion)
        {
            var currencyRate = await _currencyService.GetCurrencyRate(currencyConversion);

            if (currencyConversion.InputCurrency == Currency.SEK)
                currencyConversion.ConvertedAmount = currencyConversion.Amount / currencyRate;
            else currencyConversion.ConvertedAmount = currencyConversion.Amount * currencyRate;

            return currencyConversion;
        }
    }
}
