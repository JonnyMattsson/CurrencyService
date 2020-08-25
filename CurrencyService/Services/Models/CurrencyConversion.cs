using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyService.Services.Models
{
    public class CurrencyConversion
    {
        public Currency InputCurrency { get; set; }
        public Currency OutputCurrency { get; set; }
        public decimal Amount { get; set; }
        public decimal ConvertedAmount { get; set; }
        public DateTime ExchangeRateDate { get; set; }
    }
}
