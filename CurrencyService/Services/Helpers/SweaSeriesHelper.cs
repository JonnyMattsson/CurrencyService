using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyService.Services.Models;

namespace CurrencyService.Services.Helpers
{
    public class SweaSeriesHelper
    {
        public string GetSeriesId(Currency inputCurrency, Currency outputCurrency)
        {
            //Rate is always a value related to SEK
            var secondCurrency = (new List<Currency>() { inputCurrency, outputCurrency }).First(p => p != Currency.SEK);

            return $"SEK{secondCurrency}PMI";
        }
    }
}
