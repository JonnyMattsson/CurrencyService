using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyService.Controllers.Models
{
    public class CurrencyConversionRequest
    {
        public string InputCurrency { get; set; }
        public string OutputCurrency { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExchangeRateDate { get; set; }
    }
}
